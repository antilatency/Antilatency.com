using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using Microsoft.Extensions.FileSystemGlobbing;
using Newtonsoft.Json;

namespace Csml {

    public class Application {

        static Application() {
            var customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            System.Globalization.CultureInfo.DefaultThreadCurrentCulture = customCulture;
            ScopeHelper.EnableGetOnce();
        }

        static void Main(string[] args) {
            var scriptWarmUp = CSharpScript.WarmUpAsync();

            scriptWarmUp.Wait();
            CSharpScript.ExecuteCommandLineArguments<Application>(args);
        }

        private static string GetProjectRootDirectory() {
            return Path.GetFullPath("..", Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location));
        }

        public static void DeployToGithubIoWorkingCopy(string workingCopyDirectory) {
            Log.Info.Here($"DeployToGithubIoWorkingCopy({workingCopyDirectory})");

            var wwwRootUri = new Uri("https://" + Path.GetFileName(workingCopyDirectory) + "/");

            CsmlBuilder.Create(GetProjectRootDirectory(), workingCopyDirectory, wwwRootUri)
                .SetDeveloperMode(false)
                .SetPageTitlePrefix(string.Empty)
                .SetCleanupMatcher(GetGithubIoWorkingCopyCleanupMatcher(workingCopyDirectory))
                .Build();   
        }

        private static Matcher GetGithubIoWorkingCopyCleanupMatcher(string directory) { 
            var csmlDoNotDeleteFileName = "csmlDoNotDelete.json";
            var csmlDoNotDeletePath = Path.Combine(directory, csmlDoNotDeleteFileName);
            /*var ignoreList = new string[] { "index.html", ".git", ".gitattributes", ".gitignore" };
            */
            var matcher = new Matcher();
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

            return matcher;
        }

        public static void DeveloperBuildWatchJsCss(string outputDirectory) {
            DeveloperBuild(outputDirectory,true);
        }

        public static void DeveloperBuild(string outputDirectory, bool watch = false) {
            Log.Info.Here($"DeveloperBuild({outputDirectory},{watch})");

            GitHub.RepositoryBranch.IgnorePinning = true;
            ToDo.Enabled = true;

            var builder = CsmlBuilder.Create(GetProjectRootDirectory(), outputDirectory, new Uri(outputDirectory + "/"))
                .SetDeveloperMode(true)
                .SetPageTitlePrefix(F5.Prefix)
                .SetCleanupMatcher(null);

            builder.Build();


            if (watch) {
                Log.Info.Here($"DeveloperBuild: Watching for file change (*.scss, *.js)...");
                Watch(builder.Workspace);
            } else {
                F5.Send();
            }
        }



        static void Watch(CsmlWorkspace ws) {
            bool reloadRequired = true;
            string ScssError = null;
            while (Console.KeyAvailable == false) {
                if (reloadRequired) {
                    F5.Send();
                    reloadRequired = false;
                }
                if (ws.SassProcessor.Error != ScssError) {
                    ScssError = ws.SassProcessor.Error;
                    Console.Clear();
                    if (ScssError != null) {
                        Console.WriteLine("Scss:" + ScssError);
                    }
                }
                Thread.Sleep(250);
                reloadRequired |= ws.SassProcessor.UpdateIfChanged();
                reloadRequired |= ws.JavascriptProcessor.UpdateIfChanged();
            }
        }
    }
}
