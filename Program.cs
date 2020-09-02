using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Csml {

    public class Application {

        static Application() {
            var customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            System.Globalization.CultureInfo.DefaultThreadCurrentCulture = customCulture;

            Csml.Language.All = new Language[] {
                new Language("en", "English"),
                new Language("ru", "Русский"),
                //new Language("zh","中文")
            };


    }

    static void Main(string[] args) {
            CSharpScript.ExecuteCommandLineArguments<Application>(args);
            //DeveloperBuild(@"D:\Antilatency.com.Generated");
        }

        private static string GetProjectRootDirectory() {
            return Path.GetFullPath("..", Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location));
        }

        public static void DeployToGithubIoWorkingCopy(string workingCopyDirectory) {
            Log.Info.Here($"DeployToGithubIoWorkingCopy({workingCopyDirectory})");

            var wwwRootUri = new Uri("https://" + Path.GetFileName(workingCopyDirectory) + "/");

            CsmlApplication.ReleaseBuild(GetProjectRootDirectory(), workingCopyDirectory, wwwRootUri);

            //Add comment with website files build date to index.html => force github.io to update website
            var indexHtmlPath = Path.Combine(workingCopyDirectory, "index.html");
            if (File.Exists(indexHtmlPath)) {
                string startTag = "<!--BuildDate:";
                string endTag = "-->";
                string tag = startTag + DateTime.Now.ToString() + endTag;

                var lines = File.ReadAllLines(indexHtmlPath);
                if (lines.Length == 0 || !lines[0].StartsWith(startTag)) {
                    lines = lines.Prepend(tag).ToArray();
                } else {
                    lines[0] = tag;
                }
                File.WriteAllLines(indexHtmlPath, lines);
            }
        }
        public static void DeveloperBuildWatchJsCss(string outputDirectory) {
            DeveloperBuild(outputDirectory,true);
        }

        public static void DeveloperBuild(string outputDirectory, bool watch = false) {
            Log.Info.Here($"DeveloperBuild({outputDirectory},{watch})");
            CsmlApplication.DeveloperBuild(GetProjectRootDirectory(), outputDirectory, new Uri(outputDirectory + "/"), watch);
        }

        public static void WatchJsCssWithoutBuild(string outputDirectory)  {
            CsmlApplication.WatchJsCssWithoutBuild(GetProjectRootDirectory(), outputDirectory, new Uri(outputDirectory + "/"));
        }

        public static void WebServer(string outputDirectory, params string[] args) {
            Log.Info.Here($"WEB server mode");
            CsmlApplication.ProjectRootDirectory = GetProjectRootDirectory();
            CsmlApplication.WwwRootDirectory = outputDirectory;
            CsmlApplication.WwwRootUri = new Uri("http://localhost");
            CsmlApplication.IsDeveloperMode = false;
            CsmlApplication.SiteMapMaterials = new List<IMaterial>();
            GitHub.RepositoryBranch.IgnorePinning = true;
            ToDo.Enabled = true;

            Log.Info.Here($"WebServer: Enable Scope Properties Caching");
            ScopeHelper.EnableGetOnce();
            Log.Info.Here($"WebServer: Setup Cache");
            CsmlApplication.SetupCache();
            //Log.Info.Here($"WebServer: Cleanup Output Directory");
            //CleanupOutputDirectory();
            Log.Info.Here($"WebServer: Fonts;Sass;Javascript");
            CsmlApplication.CopyFonts();
            CsmlApplication.CreateFileProcessors();

            Log.Info.Here($"WebServer: Build Done!");
            Server.Server.Run(args);
        }
    }
}
