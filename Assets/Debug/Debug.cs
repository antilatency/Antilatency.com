using Csml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public partial class Internal : Scope {
    public static LanguageSelector<IMaterial> Debug => new LanguageSelector<IMaterial>();

    public partial class Debug_Assets : Scope {
        public static Image ExtensionBoard => new Image("ExtensionBoard.jpg");
        public static Image SmallImage => new Image("SmallImage.png");
        public static Image AltAndUsbSocket0 => new Image("./AltAndUsbSocket0.jpg");
        public static Image Input => new Image("Input.png");

        public static Downloadable DownloadableFolderTest => new Downloadable("DownloadableDirTest", DownloadableIcon.Cloud);
        public static Downloadable DownloadableFolderTestWithoutPng => new Downloadable("DownloadableDirTest", DownloadableIcon.Zip, packToArchivePredicate: x => Path.GetExtension(x) != ".png");
        public static Downloadable DownloadableFolderTestWithoutTxt => new Downloadable("DownloadableDirTest", DownloadableIcon.Zip, packToArchivePredicate: x => Path.GetExtension(x) != ".txt");
        public static Downloadable DownloadableFileTest => new Downloadable("Test.json");

        public static List<Image> AltAndUsbSocketAll => typeof(Debug_Assets).GetPropertiesAll()
            .Where(x => x.PropertyType == typeof(Image))
            .Where(x => x.Name.StartsWith("AltAndUsbSocket"))
            .Select(x => x.GetValue(null) as Image).ToList();

        public static Code TestXml => Code.FromFile("Test.xml");

        public static Code TestJson => Code.FromFile("Test.json");

        public static LanguageSelector WikipediaCSharp => new LanguageSelector();
        public static ExternalReference WikipediaCSharp_ru => new ExternalReference("https://ru.wikipedia.org/wiki/C_Sharp", "C#");
        public static ExternalReference WikipediaCSharp_en => new ExternalReference("https://en.wikipedia.org/wiki/C_Sharp_(programming_language)", "C#");
        public static ExternalReference WikipediaCSharp_zh => new ExternalReference("https://zh.wikipedia.org/wiki/C%E2%99%AF", "C#");
    }
}