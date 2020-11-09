using Csml;



partial class Hardware: Scope {
    public static LanguageSelector<IMaterial> TrackingAreaFloor => new LanguageSelector<IMaterial>();
    public partial class TrackingAreaFloor_Assets : Scope {
        public static Image TrackingAreaFloorProduct0 => new Image("./TrackingAreaFloorProduct0.jpg");

        public static string Dimensions = "70x30x63";
        public static string Weight = "10,3";

    }
}