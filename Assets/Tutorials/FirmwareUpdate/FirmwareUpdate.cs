using Csml;


partial class Tutorials : Scope {
    public static LanguageSelector<IMaterial> Firmware_Update => new LanguageSelector<IMaterial>();
    public partial class Firmware_Update_Assets : Scope {
        public static Image TitleImage => new Image("./TitleImage.jpg");
        
        public static YoutubeVideo TitleVideo => new YoutubeVideo("zq3w-tXyk4w");

        public static Image Step2 = new Image("./Images/Step2.png");
        public static Image Step4 = new Image("./Images/Step4.png");
        public static Image Step5 = new Image("./Images/Step5.png");
        public static Image Step6 = new Image("./Images/Step6.png");

    }
    }
    