using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;



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
    public class Lazy<T> where T : class {
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

    }

}



static class Program {

    static string ThisFilePath([System.Runtime.CompilerServices.CallerFilePath] string sourceFilePath = "") {
        return sourceFilePath;
    }


    static void Main(string[] args) {
        

        Csml.Engine.Process<Root>();



        var c = Csml.Context.Current;
        c.SourceRootDirectory = Path.Combine(Path.GetDirectoryName(ThisFilePath()), "Src");
        c.AutoReload = false;

        if (args.Length == 1) {
            c.OutputRootDirectory = args[0];
            Csml.Engine.Generate<Root>();
        }



    }
}

