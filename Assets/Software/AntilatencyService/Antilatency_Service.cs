using Csml;

public partial class Software : Scope {
    public partial class Antilatency_Service : Scope{
        public static LanguageSelector<IMaterial> Material => new LanguageSelector<IMaterial>();
        public static Image Title = new Image("./Title.png");
        
        public static Image PlacementsTabScreenshot = new Image("./Placements/Placements.png");
        public static Image EnvironmentsTabScreenshot = new Image("./Environments/Environments.png");
        public static Image DeviceNetworkTabScreenshot = new Image("./DeviceNetwork/Device_Network.png");

    }
}