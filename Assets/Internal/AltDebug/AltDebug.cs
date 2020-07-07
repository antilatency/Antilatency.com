using Csml;

partial class Internal : Scope {
    public static LanguageSelector<IMaterial> Alt_Debug => new LanguageSelector<IMaterial>();

    public partial class Alt_Debug_Assets : Scope {
        public static Image TitleImage => new Image("Images/TitleImage.png");

        public static Image DeviceTree => new Image("Images/DeviceTree.png");
        public static Image DeviceTree_SelectImage => new Image("Images/DeviceTree_SelectImage.png");
        public static Image Icon_NoTrackers => new Image("Images/Icon_NoTrackers.png");
        public static Image Image_Tab => new Image("Images/Image_Tab.png");
        public static Image Image_AutoImage => new Image("Images/Image_AutoImage.png");
        public static Image Image_AutoPoints => new Image("Images/Image_AutoPoints.png");
        public static Image Image_AutoImagePoints => new Image("Images/Image_AutoImagePoints.png");
        public static Image Image_DeviceTree => new Image("Images/Image_DeviceTree.png");
        public static Image Image_Rows => new Image("Images/Image_Rows.png");
        public static Image Startup => new Image("Images/Startup.png");
        public static Downloadable AltDebugLink => new Downloadable("AltDebug", "AltDebug/sdk2/Windows/x64");
    }
}