using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using Csml;

/*public class Lazy<T> {
    Func<T> func;
    public Lazy(Func<T> func) {
        this.func = func;
    }
    public T Value {
        get => func();
    }
}
public partial class Root {
    public static Lazy<T> MakeLazy<T>(Func<T> func) {
        return new Lazy<T>(func);
    }
}*/


namespace Csml {
    /*public class Lazy<T> where T : class {
        public T value;
        public bool HasValue => value != null;
        private Func<T> func;
        //public IEnumerable<T> 

        public Lazy(T value) {
            this.value = value;
        }

        public Lazy(Func<T> func) {
            this.func = func;
        }

        public T GetValue() {
            if (!HasValue) {
                value = func();
            }
            if (HasValue) {
                return value;
            }
            throw new NullReferenceException();
        }

        public static implicit operator T(Lazy<T> x) {
            return x.GetValue();
        }

        public static implicit operator Lazy<T>(T x) {
            return new Lazy<T>(x);
        }
        public static implicit operator Lazy<T>(Func<T> x) {
            return new Lazy<T>(x);
        }

    }*/

}


namespace Csml {
    static class Program {
        static void Main(string[] args) {
            #region CsmlEngineMain

            
            DocumentationGenerator documentationGenerator = new DocumentationGenerator(
                typeof(Antilatency.DeviceNetwork.ILibrary),
                typeof(Antilatency.Alt.Tracking.ILibrary)
                );
            documentationGenerator.Generate();
            


            //return;

            //Engine.Process<Root>();
            //var root = new Root();
            
            Scope.All.ForEach(x => x.Verify());
            
            var context = new Csml.Context {
                SourceRootDirectory = Path.Combine(Path.GetDirectoryName(Utils.ThisFilePath()), "Src")
            };

            Directory.GetFiles(Path.Combine(context.SourceRootDirectory, "Css"), "*.*", SearchOption.AllDirectories)
                .ForEach(x => context.AssetsToCopy.Add(x));
                


            context.AutoReload = false;

            if (args.Length == 1) {
                context.OutputRootDirectory = args[0];

                context.BaseUri = new Uri(context.OutputRootDirectory + "/");
                context.CleanOutputRootDirectory();
                context.CopyAssets();
                Scope.All.ForEach(x => {
                    Log.Info.Here($"Generation Scope {x.GetType().Name}");
                    x.Generate(context);
                    
                    });
                //Root.Instance.Generate(context, true);
            }
            #endregion
        }
    }
}
