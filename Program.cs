using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using Csml;

namespace Csml {

    public class Application {
        public static string ExecutablePath;
        public static string ProjectRootDirectory;
        public static string OutputRootDirectory;
        public static Uri BaseUri;

        static SassProcessor sassProcessor;
        static JavascriptProcessor javascriptProcessor;

        public static string TitlePrefix { get; internal set; }

        static Application() {
            var customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            System.Globalization.CultureInfo.DefaultThreadCurrentCulture = customCulture;
            ScopeUtils.EnableGetOnce();

            ExecutablePath = System.Reflection.Assembly.GetEntryAssembly().Location;
            ProjectRootDirectory = Path.GetFullPath("..", Path.GetDirectoryName(ExecutablePath));
            GitHub.FileCache.RootDirectory = Path.Combine(ProjectRootDirectory, ".cache/gitHubFileCache");
        }

        static void Main(string[] args) {
            var scriptWarmUp = CommandLineScript.WarmUpAsync();

            /*using (new Stopwatch("Verify")) {
                ScopeUtils.All.ForEach(x => x.Verify());
            }*/

            scriptWarmUp.Wait();
            CommandLineScript.ExecuteCommandLineArguments<Application>(args);
        }

        //private static CopyFonts

        public static void DeployToGithubIoWorkingCopy(string workingCopyDirectory) {
            Log.Info.Here($"DeployToGithubIoWorkingCopy({workingCopyDirectory})");
            
            OutputRootDirectory = workingCopyDirectory;
            BaseUri = new Uri("https://" +Path.GetFileName(workingCopyDirectory)+"/");            
            
            ImageCache.RootDirectory = Path.Combine(OutputRootDirectory, "Images");
            ImageCache.RootUri = new Uri(BaseUri, "Images/");
            YoutubeVideoCache.RootDirectory = Path.Combine(OutputRootDirectory, "Videos");
            YoutubeVideoCache.RootUri = new Uri(BaseUri, "Videos/");
            DownloadableCache.RootDirectory = Path.Combine(OutputRootDirectory, "Downloads");
            DownloadableCache.RootUri = new Uri(BaseUri, "Downloads/");

            CleanUpGitHubIoWorkingCopy(OutputRootDirectory);

            Log.Info.Here($"DeployToGithubIoWorkingCopy: Fonts;Sass;Javascript");
            CopyFonts();
            BeginSass();
            BeginJavascript();

            Log.Info.Here($"DeployToGithubIoWorkingCopy: Generate...");
            Context context = new Context();
            ScopeUtils.All.ForEach(x => {
                x.Generate(context);
            });
        }

        public static void DeveloperBuildWatchJsCss(string outputDirectory) {
            DeveloperBuild(outputDirectory,true);
        }

        public static void DeveloperBuild(string outputDirectory, bool watch = false) {
            Log.Info.Here($"DeveloperBuild({outputDirectory},{watch})");
            OutputRootDirectory = outputDirectory;
            BaseUri = new Uri(OutputRootDirectory + "/");

            ImageCache.RootDirectory = Path.Combine(ProjectRootDirectory, ".cache/images");
            YoutubeVideoCache.RootDirectory = Path.Combine(ProjectRootDirectory, ".cache/videos");
            DownloadableCache.RootDirectory = Path.Combine(ProjectRootDirectory, ".cache/downloadable");
            GitHub.RepositoryBranch.IgnorePinning = true;


            CleanUpDirectory(OutputRootDirectory);

            if (watch) {
                TitlePrefix = F5.Prefix;
            }

            Log.Info.Here($"DeveloperBuild: Fonts;Sass;Javascript");
            CopyFonts();
            BeginSass();
            BeginJavascript();

            Log.Info.Here($"DeveloperBuild: Generate...");
            
            Context context = new Context();
            ScopeUtils.All.ForEach(x => {
                x.Generate(context);
            });
            Log.Info.Here($"DeveloperBuild: Done!");

            if (watch) {
                Log.Info.Here($"DeveloperBuild: Watching for file change (*.scss, *.js)...");
                Watch();
            } else {
                F5.Send();
            }

        }

        public static void CleanUpGitHubIoWorkingCopy(string directory) {
            CleanUpDirectory(directory, (path) => {
                if (directory+"\\index.html" == path) return false;
                var name = Path.GetFileName(path);
                if (name.StartsWith(".")) return false;
                return true;
            });

        }

        public static void CleanUpDirectory(string directory, Func<string,bool> conditionToDelete) {
            if (!Directory.Exists(directory)) {
                Utils.CreateDirectory(directory);
                return;
            }
            foreach (var d in Directory.GetDirectories(directory)) {                
                if (conditionToDelete(d))
                    Utils.DeleteDirectory(d);            
            }
            foreach (var f in Directory.GetFiles(directory)) {
                if (conditionToDelete(f))
                    File.Delete(f);
            }
        }

        public static void CleanUpDirectory(string directory) {
            if (!Directory.Exists(directory)) {
                Utils.CreateDirectory(directory);
                return;
            }
            foreach (var d in Directory.GetDirectories(directory)) {
                Utils.DeleteDirectory(d);
            }
            foreach (var f in Directory.GetFiles(directory)) {
                File.Delete(f);
            }
        }


        static void Watch() {
            bool reloadRequired = true;
            string ScssError = null;
            while (Console.KeyAvailable == false) {
                if (reloadRequired) {
                    F5.Send();
                    reloadRequired = false;
                }
                if (sassProcessor.Error != ScssError) {
                    ScssError = sassProcessor.Error;
                    Console.Clear();
                    if (ScssError != null) {
                        Console.WriteLine("Scss:" + ScssError);
                    }
                }
                Thread.Sleep(250);
                reloadRequired |= sassProcessor.UpdateIfChanged();
                reloadRequired |= javascriptProcessor.UpdateIfChanged();
            }
        }

        private static void CopyFonts() {
            var sourceDirectory = Path.Combine(ProjectRootDirectory, "Fonts");
            var destDirectory = Path.Combine(OutputRootDirectory, "Fonts");
            var files = Directory.GetFiles(sourceDirectory, "*", SearchOption.AllDirectories);

            List<string> extensions = new List<string>() { ".ttf", ".woff", ".woff2", ".svg", ".eot" };

            foreach (var f in files.Where(x => extensions.Contains(Path.GetExtension(x)))) {
                var relativePath = Path.GetRelativePath(sourceDirectory, f);
                var destPath = Path.Combine(destDirectory, relativePath);
                if (File.Exists(destPath)) continue;

                var subDirectory = Path.GetDirectoryName(relativePath);
                Utils.CreateDirectory(Path.Combine(destDirectory, subDirectory));
                File.Copy(f, destPath);
            }
        }

        private static void BeginSass() {
            sassProcessor = new SassProcessor(
                ProjectRootDirectory,
                OutputRootDirectory,
                "Style.scss");
        }
        private static void BeginJavascript() {
            javascriptProcessor = new JavascriptProcessor(
                ProjectRootDirectory,
                OutputRootDirectory);
        }


        static class DeveloperBuild_ {
            static async System.Threading.Tasks.Task Main(string[] args) {


                
                
                    
                try {


                    //Set dot decimal separator


                    


                    /*var context = new Context {
                        SourceRootDirectory = Path.GetDirectoryName(Utils.ThisFilePath()),
                        Watch = true
                    };
                    //Cache.RootDirectory = Path.Combine(context.SourceRootDirectory, "cache");

                    using (new Stopwatch("Verify")) {
                        ScopeUtils.All.ForEach(x => x.Verify());
                    }


                    context.AssetsToCopy = Directory.GetFiles(context.SourceRootDirectory, "*.ttf", SearchOption.AllDirectories)
                        .Concat(Directory.GetFiles(context.SourceRootDirectory, "*.woff", SearchOption.AllDirectories))
                        .Concat(Directory.GetFiles(context.SourceRootDirectory, "*.woff2", SearchOption.AllDirectories))
                        .Concat(Directory.GetFiles(context.SourceRootDirectory, "*.svg", SearchOption.AllDirectories))
                        .ToHashSet();*/

                    /*.ForEach(x => context.AssetsToCopy.Add(x));
                    .ForEach(x => context.AssetsToCopy.Add(x));
                    Directory.GetFiles(context.SourceRootDirectory, "*.svg", SearchOption.AllDirectories).ForEach(x => context.AssetsToCopy.Add(x));*/

                    /*
                    if (args.Length == 1) {


                        context.OutputRootDirectory = args[0];

                        context.BaseUri = new Uri(context.OutputRootDirectory + "/");
                        context.CleanOutputRootDirectory();
                        context.CopyAssets();

                        SassProcessor sassProcessor = new SassProcessor(
                            context.SourceRootDirectory,
                            context.OutputRootDirectory,
                            "Assets/style.scss");
                        JavascriptProcessor javascriptProcessor = new JavascriptProcessor(
                            context.SourceRootDirectory,
                            context.OutputRootDirectory);


                        ScopeUtils.All.ForEach(x => {
                            //Log.Info.Here($"Generation Scope {x.GetType().Name}");
                            x.Generate(context);

                        });

                        Console.WriteLine("All files generated!");
                        Console.WriteLine();

                        if (context.Watch) {
                            Console.WriteLine("Watching for file changes. Press any key to exit.");
                            bool reloadRequired = true;

                            string ScssError = null;
                            while (Console.KeyAvailable == false) {
                                if (reloadRequired) {
                                    F5.Send();
                                    reloadRequired = false;
                                }
                                if (sassProcessor.Error != ScssError) {
                                    ScssError = sassProcessor.Error;
                                    Console.Clear();
                                    if (ScssError != null) {
                                        Console.WriteLine("Scss:" + ScssError);
                                    }
                                }
                                Thread.Sleep(250);
                                reloadRequired |= sassProcessor.UpdateIfChanged();
                                reloadRequired |= javascriptProcessor.UpdateIfChanged();
                            }

                        }
                    }*/
                }
                catch {
                    Console.ReadLine();
                }
            }
        }
    }
}
