using Csml;


partial class Tutorials : Scope {
    public static LanguageSelector<IMaterial> Devkit_Tracking_Area_Setup => new LanguageSelector<IMaterial>();
    public partial class Devkit_Tracking_Area_Setup_Assets : Scope {
        public static Image TitleImage => new Image("./TitleImage.jpg");
     
        public static Image DevKitComplect => new Image("./DevKitComplect.jpg");
        public static Image MatsCovering => new Image("./MatsCovering.gif");
        public static Image BarsDirection => new Image("./BarsDirection.gif");
        public static Image PowerSupply => new Image("./PowerSupply.gif");
        public static Image Connectors => new Image("./Connectors.gif");
        public static YoutubeVideo TitleVideo => new YoutubeVideo("qbNUp-hHnS4");
        
    }
    }
    