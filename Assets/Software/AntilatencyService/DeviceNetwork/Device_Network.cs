using Csml;

public partial class Software : Scope {
    public partial class AntilatencyService : Scope {
        public partial class Device_Network : Scope {
            public static LanguageSelector<IMaterial> Material => new LanguageSelector<IMaterial>();

            public static Image Title = new Image("./Images/DeviceNetworkTitle.jpg");
        }
    }
}