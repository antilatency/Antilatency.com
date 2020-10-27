using Csml;

public partial class Software : Scope {
    public partial class AntilatencyService : Scope{
        public static LanguageSelector<IMaterial> Material => new LanguageSelector<IMaterial>();
        public static Image Title = new Image("./Title.png");
        
        public static Image PlacementsTabScreenshot = new Image("./Placements/Images/Placements.png");
        public static Image EnvironmentsTabScreenshot = new Image("./Environments/Images/Environments.png");
        public static Image DeviceNetworkTabScreenshot = new Image("./DeviceNetwork/Images/Device_Network.png");
        public static Downloadable InstallFile = new Downloadable("AntilatencyService", "AntilatencyServiceBinaries", Downloadable.PathFragment.Version, Downloadable.PathFragment.Directory, Downloadable.PathFragment.Directory);

    }
}