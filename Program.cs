using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;

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
            CommandLineScript.ExecuteCommandLineArguments<Application>(args);
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
            if(File.Exists(indexHtmlPath)) {
                string startTag = "<!--BuildDate:";
                string endTag = "-->";
                string tag = startTag + DateTime.Now.ToString() + endTag;

                var lines = File.ReadAllLines(indexHtmlPath);
                if(lines.Length == 0 || !lines[0].StartsWith(startTag)) {
                    lines = lines.Prepend(tag).ToArray();
                } else {
                    lines[0] = tag;
                }
                File.WriteAllLines(indexHtmlPath, lines);
            }
        }
        public static void DeveloperBuildWatchJsCss(string outputDirectory) {
            DeveloperBuild(outputDirectory, true);
        }

        public static void DeveloperBuild(string outputDirectory, bool watch = false) {
            Log.Info.Here($"DeveloperBuild({outputDirectory},{watch})");
            CsmlApplication.DeveloperBuild(GetProjectRootDirectory(), outputDirectory, new Uri(outputDirectory + "/"), watch);
        }

        public static void WatchJsCssWithoutBuild(string outputDirectory) {
            CsmlApplication.WatchJsCssWithoutBuild(GetProjectRootDirectory(), outputDirectory, new Uri(outputDirectory + "/"));
        }

        private static string _url;

        public static string GetUrlFromEnviroment() {
            if(!string.IsNullOrEmpty(_url)) {
                return _url;
            }
            _url = Environment.GetEnvironmentVariable("DOTNET_URLS");
            if(string.IsNullOrEmpty(_url) || !Uri.IsWellFormedUriString(_url, UriKind.RelativeOrAbsolute)) {
                Log.Warning.Here("Empty or invalid URL, replaced with localhost:");
                _url = @"http://localhost";
            } else if(_url.Contains("0.0.0.0")) {
                _url = $"http://{AddressSelector()}";
            }
            return _url;
        }

        private static string AddressSelector() {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            var adresses = new List<string>();
            foreach(var ip in host.AddressList) {
                if(ip.AddressFamily == AddressFamily.InterNetwork) {
                    adresses.Add(ip.ToString());
                }
            }
            if (adresses.Count > 1) {
                Console.WriteLine($"{adresses.Count} adresses has been found. Enter the number of adrees whitch you prefer:");
                for (int i = 0; i < adresses.Count; i++) {
                    Console.WriteLine($"{i}) {adresses[i]}");
                }
                var enteredValue = Console.ReadLine();
                int result;
                while(!int.TryParse(enteredValue, out result) || result >= adresses.Count) {
                    Console.WriteLine($"Invalid number try again");
                    enteredValue = Console.ReadLine();
                }
                return adresses[result];
            } else if (adresses.Count == 0){
                Log.Warning.Here("No adapters found, url set to localhost:");
                return "localhost";
            } else {
                return adresses.First();
            }
        }

        public static void WebServer(string outputDirectory, params string[] args) {
            Log.Info.Here($"WEB server mode");
            CsmlApplication.ProjectRootDirectory = GetProjectRootDirectory();
            CsmlApplication.WwwRootDirectory = outputDirectory;
            CsmlApplication.WwwRootUri = new Uri(GetUrlFromEnviroment());
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
            //CsmlApplication.CreateFileProcessors();

            CsmlApplication.SassProcessor = new SassProcessor(true, CsmlApplication.ProjectRootDirectory, CsmlApplication.WwwRootDirectory, "Style.scss");
            CsmlApplication.JavascriptProcessor = new JavascriptProcessor(true, CsmlApplication.ProjectRootDirectory, CsmlApplication.WwwRootDirectory);

            Log.Info.Here($"WebServer: Build Done!");
            Server.FilesWatcher.Start();
            Server.Server.Run(args);
            Server.FilesWatcher.Stop();
        }
    }
}
