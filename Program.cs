using System;
using System.IO;

namespace Csml {

    public class Application {

        static Application() {
            var customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            System.Globalization.CultureInfo.DefaultThreadCurrentCulture = customCulture;
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
        }

        public static void DeveloperBuildWatchJsCss(string outputDirectory) {
            DeveloperBuild(outputDirectory,true);
        }

        public static void DeveloperBuild(string outputDirectory, bool watch = false) {
            Log.Info.Here($"DeveloperBuild({outputDirectory},{watch})");

            CsmlApplication.DeveloperBuild(GetProjectRootDirectory(), outputDirectory, new Uri(outputDirectory + "/"));
        }
    }
}
