using Csml;

partial class Tutorials : Scope {
    public static LanguageSelector<IMaterial> Antilatency_Ip_Tracking_Demo_Provider_RaspberryPi => new LanguageSelector<IMaterial>();

    public partial class Antilatency_Ip_Tracking_Demo_Provider_RaspberryPi_Assets : Scope {
        public static Image TitleImage => new Image("./TitleImage.jpg");        
        public static Code TrackingDemoOutput => new Code(
            @"/opt/antilatency/bin/AntilatencyIpTrackingDemoProvider -v
[15:27:31.905][000741][info] Start factory creation
Polling Thread Id 1982088240
[15:27:31.909][000741][info] Device / sys / bus / usb / devices / 1 - 1 / init completed.
...
[15:27:33.219][000741][info] Launched task a6c07d30-e3cf-44ed-b996-5f96998392e2 on 2 Node
id: rand706031805; c_time: 6649237; error: ; gpio: 001000011111000111100100
        tag: Head; err: None; posX: 0; posY: 0; posZ: 0; rotX: 0; rotY: 0; rotZ: 0; rotW: 1
id: rand706031805; c_time: 6649438; error: ; gpio: 001000011111000111100100
        tag: Head; err: None; posX: 0.000280265; posY: -0.000177345; posZ: -2.28101e-05; rotX: -2.59319e-05; rotY: -2.59936e-06; rotZ: 1.15174e-05; rotW: 1
id: rand706031805; c_time: 6649639; error: ; gpio: 001000011111000111100100
        tag: Head; err: None; posX: 0; posY: 1.68; posZ: 0; rotX: 0.0440574; rotY: -5.36158e-06; rotZ: 0.52934; rotW: 0.847265"
            , ProgrammingLanguage.PowerShell
        );

        public static Code ProviderConf => new Code(
            @"# Multicast group
--receivers=239.255.111.111

# UnityUdpTrackingReceiver port
--port=56789

# DevKit
--environment=AAVSaWdpZBcABnllbGxvdwQEBAABAQMBAQEDAAEAAD_W

# ~60 FPS
--wait-time=16

# Set GPIO pins default state
--gpio=25:output:high"
            , ProgrammingLanguage.PowerShell
        );

    }
}