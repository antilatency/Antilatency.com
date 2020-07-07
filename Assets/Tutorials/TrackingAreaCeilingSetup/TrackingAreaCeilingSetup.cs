using Csml;



partial class Tutorials: Scope {
    public static LanguageSelector<IMaterial> TrackingAreaCeilingSetup => new LanguageSelector<IMaterial>();
    public partial class TrackingAreaCeilingSetup_Assets : Scope {
        public static Image TrackingAreaCeilingSetup0 => new Image("./TrackingAreaCeilingSetup0.jpg");
        public static Image CeilingMarkerPinOut => new Image("./CeilingMarkerPinOut.jpg");
        public static Image CeilingMarkerView => new Image("./CeilingMarkerView.png");
        public static Image GridSystemView => new Image("./GridSystem.png");
        public static Image MarkerChainMax => new Image("./MarkerChainMax.jpg");
        public static Image WiresEnds => new Image("./WiresEnds.jpg");        

    }
}