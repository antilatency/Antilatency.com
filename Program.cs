using System;
using System.IO;

namespace Csml {
    public partial class Language {
        public static Language en = new Language("en");
        public static Language ru = new Language("ru");
    }
}

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
    
class Program {

    static string ThisFilePath([System.Runtime.CompilerServices.CallerFilePath] string sourceFilePath = "") {
        return sourceFilePath;
    }


    static void Main(string[] args ) {

        Csml.GeneratorContext.ContentDirectory = Path.Combine( Path.GetDirectoryName(ThisFilePath()), "Src");

        Csml.Preprocessor.Process<Root>();


        if (args.Length == 1) {
            var outputDirectory = args[0];
            //Path.Combine(Environment.CurrentDirectory, "output")
            new Csml.HtmlGenerator<Root>().Generate(outputDirectory);
        }

        



        /*Csml.Log.Error.Here("a", 0);


        Console.Error.WriteLine("D:/Antilatency.com/Program.cs (10): error CSML0000: message");
        throw new Exception("99");*/


    }
}

