using System;

namespace Csml {
    public partial class Language {
        public static Language en = new Language("en");
        public static Language ru = new Language("ru");
    }
}


class Program {
    static void Main(/*string[] args*/) {



        Csml.Preprocessor.Process<Root>();
        /*Csml.Log.Error.Here("a", 0);


        Console.Error.WriteLine("D:/Antilatency.com/Program.cs (10): error CSML0000: message");
        throw new Exception("99");*/

        
    }
}

