using Csml;


partial class Tutorials : Scope {
    public static LanguageSelector<IMaterial> Tracking_Area_Setup => new LanguageSelector<IMaterial>();
    public partial class Tracking_Area_Setup_Assets : Scope {
        public static Image TitleImage => new Image("./Images/TitleImage.jpg");
        
        public static Image ConnectionScheme => new Image("./Images/ConnectionScheme.jpg");
        public static Image OpenEnvironmentEditor => new Image ("./Images/OpenEnvironmentEditor.gif");
        public static Image RoutingTab => new Image ("./Images/RoutingTab.png");
        public static Image LoadRouting => new Image ("./Images/LoadRouting.png");
        public static Image SocketPlacementModeOn => new Image ("./Images/SocketPlacementModeOn.gif");
        public static Image SocketPlacementModeOff => new Image ("./Images/SocketPlacementModeOn.gif");
        public static Image Evaluate => new Image ("./Images/Evaluate.gif");
        public static Image SaveRouting => new Image ("./Images/SaveRouting.png");

    }
    }
    