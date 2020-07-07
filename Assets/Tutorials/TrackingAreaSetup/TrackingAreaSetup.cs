using Csml;


partial class Tutorials : Scope {
    public static LanguageSelector<IMaterial> Tracking_Area_Setup => new LanguageSelector<IMaterial>();
    public partial class Tracking_Area_Setup_Assets : Scope {
        public static Image TitleImage => new Image("./TitleImage.jpg");
        public static Image AntilatencyServiceScreen => new Image("./AntilatencyServiceScreen.jpg");
        public static Image EnvironmentEditorSelectRouting => new Image("./EnvironmentEditor - Routing select.jpg");
        public static Image ConnectionScheme => new Image("./ConnectionScheme.jpg");
        public static Image EnvironmentEditorScreen => new Image("./EnvironmentEditorScreen.jpg");
        public static Image RoutingScreen => new Image("./RoutingScreen.png");
    }
    }
    