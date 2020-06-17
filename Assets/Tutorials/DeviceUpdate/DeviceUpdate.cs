using Csml;


partial class Tutorials : Scope {
    public static LanguageSelector<IMaterial> Device_Update => new LanguageSelector<IMaterial>();
    public partial class Device_Update_Assets : Scope {
        public static Image TitleImage => new Image("./TitleImage.jpg");
        
        public static Image DeviceTree => new Image("./DeviceTree.jpg");
        public static Image ReflashFirmware => new Image("./ReflashFirmware.jpg");
        public static Image SelectFirmware => new Image("./SelectFirmware.jpg");
        public static YoutubeVideo TitleVideo => new YoutubeVideo("zq3w-tXyk4w");
        
    }
    }
    