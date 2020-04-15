using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using Csml;






namespace Csml {
    
    static class Program {

        

        static void Main(string[] args) {
            #region CsmlEngineMain
            Scope.EnableGetOnce();
            GitHub.RepositoryBranch.IgnorePinning = true;

            using (new Stopwatch("DocumentationGenerator")) {
                DocumentationGenerator documentationGenerator = new DocumentationGenerator(
                    typeof(Antilatency.DeviceNetwork.ILibrary),
                    typeof(Antilatency.Alt.Tracking.ILibrary)
                    );
                documentationGenerator.Generate();
            }



            var context = new Context {
                SourceRootDirectory = Path.GetDirectoryName(Utils.ThisFilePath()),
                Watch = true
            };
            Cache.RootDirectory = Path.Combine(context.SourceRootDirectory, "cache");

            using (new Stopwatch("Verify")) {
                Scope.All.ForEach(x => x.Verify());
            }


            Directory.GetFiles(context.SourceRootDirectory, "*.ttf", SearchOption.AllDirectories).ForEach(x => context.AssetsToCopy.Add(x));
            Directory.GetFiles(context.SourceRootDirectory, "*.woff", SearchOption.AllDirectories).ForEach(x => context.AssetsToCopy.Add(x));
            Directory.GetFiles(context.SourceRootDirectory, "*.woff2", SearchOption.AllDirectories).ForEach(x => context.AssetsToCopy.Add(x));
            Directory.GetFiles(context.SourceRootDirectory, "*.svg", SearchOption.AllDirectories).ForEach(x => context.AssetsToCopy.Add(x));





            context.AutoReload = false;

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


                Scope.All.ForEach(x => {
                    Log.Info.Here($"Generation Scope {x.GetType().Name}");
                    x.Generate(context);
                    
                    });

                if (context.Watch) {
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
                

            }
            #endregion
        }
    }
}
