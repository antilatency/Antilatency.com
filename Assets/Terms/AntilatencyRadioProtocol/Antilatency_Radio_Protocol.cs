using Csml;

partial class Terms {
    public static LanguageSelector<IMaterial> Antilatency_Radio_Protocol => new LanguageSelector<IMaterial>();

    public partial class Antilatency_Radio_Protocol_Assets : Scope {

        public static Image AntilatencyRadioProtocolTopology => new Image("./RadioDevicesScheme01.jpg");
        public static Image RadioChannelsImage => new Image("./RadioChannels.jpg");
        public static Image MultipleChannelsImage => new Image("./MultipleChannels.jpg");
    }
}