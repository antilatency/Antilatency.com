using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using Csml;
using Microsoft.Extensions.FileSystemGlobbing;
using Newtonsoft.Json;

namespace Csml {



    public class Application {
        public static string ExecutablePath;
        public static string ProjectRootDirectory;
        public static string OutputRootDirectory;
        public static Uri BaseUri;

        static SassProcessor sassProcessor;
        static JavascriptProcessor javascriptProcessor;

        public static string TitlePrefix { get; internal set; }

        public static Uri CssUri => new Uri(BaseUri, sassProcessor.OutputFileName);
        public static Uri JsUri => new Uri(BaseUri, javascriptProcessor.OutputFileName);

        public static List<IMaterial> SiteMap = new List<IMaterial>();

        static Application() {
            var customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            System.Globalization.CultureInfo.DefaultThreadCurrentCulture = customCulture;
            ScopeHelper.EnableGetOnce();

            ExecutablePath = System.Reflection.Assembly.GetEntryAssembly().Location;
            ProjectRootDirectory = Path.GetFullPath("..", Path.GetDirectoryName(ExecutablePath));
            GitHub.FileCache.RootDirectory = Path.Combine(ProjectRootDirectory, ".cache/gitHubFileCache");
        }

        static void Main(string[] args) {
            var scriptWarmUp = CSharpScript.WarmUpAsync();

            /*using (new Stopwatch("Verify")) {
                ScopeUtils.All.ForEach(x => x.Verify());
            }*/

            scriptWarmUp.Wait();
            CSharpScript.ExecuteCommandLineArguments<Application>(args);
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
            BeginSass(false);
            BeginJavascript(false);

            Log.Info.Here($"DeployToGithubIoWorkingCopy: Generate...");
            Context context = new Context();
            ScopeHelper.All.ForEach(x => {
                x.Generate(context);
            });
            SaveSiteMap();
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
            ToDo.Enabled = true;

            CleanUpDirectory(OutputRootDirectory);

            
            TitlePrefix = F5.Prefix;
            

            Log.Info.Here($"DeveloperBuild: Fonts;Sass;Javascript");
            CopyFonts();
            BeginSass(true);
            BeginJavascript(true);

            Log.Info.Here($"DeveloperBuild: Generate...");
            
            Context context = new Context();
            ScopeHelper.All.ForEach(x => {
                x.Generate(context);
            });

            SaveSiteMap();
            Log.Info.Here($"DeveloperBuild: Done!");

            if (watch) {
                Log.Info.Here($"DeveloperBuild: Watching for file change (*.scss, *.js)...");
                Watch();
            } else {
                F5.Send();
            }

        }

        public static void CleanUpGitHubIoWorkingCopy(string directory) {
            var csmlDoNotDeleteFileName = "csmlDoNotDelete.json";
            var csmlDoNotDeletePath = Path.Combine(directory, csmlDoNotDeleteFileName);
            /*var ignoreList = new string[] { "index.html", ".git", ".gitattributes", ".gitignore" };
            */
            Matcher matcher = new Matcher();
            matcher.AddInclude("**/*");
            matcher.AddExclude("index.html");
            matcher.AddExclude("**/.*");
            matcher.AddExclude(csmlDoNotDeleteFileName);

            if (File.Exists(csmlDoNotDeletePath)) {
                var customIgnoreList = JsonConvert.DeserializeObject<string[]>(Utils.ReadAllText(csmlDoNotDeletePath));
                if (customIgnoreList != null) {
                    foreach (var i in customIgnoreList) {
                        matcher.AddExclude(i);
                    }
                }
            }


            var filesToDelete = matcher.GetResultsInFullPath(directory);

            foreach (var f in filesToDelete) {
                File.Delete(f);
            }

            Utils.DeleteEmptySubdirectories(directory);

                /*CleanUpDirectory(directory, (path) => {
                    if (directory+"\\index.html" == path) return false;
                    var name = Path.GetFileName(path);
                    if (name.StartsWith(".")) return false;
                    return true;
                });*/
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

        private static void BeginSass(bool developerMode) {
            sassProcessor = new SassProcessor(
                developerMode,
                ProjectRootDirectory,
                OutputRootDirectory,
                "Style.scss");
        }
        private static void BeginJavascript(bool developerMode) {
            javascriptProcessor = new JavascriptProcessor(
                developerMode,
                ProjectRootDirectory,
                OutputRootDirectory);
        }


        public static void SaveSiteMap(string path = null) {
            if (string.IsNullOrEmpty(path)) {
                path = Path.Combine(OutputRootDirectory, "SiteMap.xml");
            }

            StringBuilder result = new StringBuilder();
            result.AppendLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            result.AppendLine("<urlset xmlns=\"http://www.sitemaps.org/schemas/sitemap/0.9\" xmlns:xhtml=\"http://www.w3.org/1999/xhtml\">");

            foreach (var m in SiteMap) {
                foreach (var l in Language.All) {
                    result.AppendLine("\t<url>");
                    result.AppendLine($"\t<loc>{m.GetUri(l)}</loc>");
                    foreach (var l2 in Language.All) {
                        result.AppendLine($"\t\t<xhtml:link rel=\"alternate\" hreflang=\"{l2.Name}\" href=\"{m.GetUri(l2)}\"/>");
                    }
                    result.AppendLine("\t</url>");
                }
            }
            result.AppendLine("</urlset>");
            File.WriteAllText(path, result.ToString());
        }



    }
}
