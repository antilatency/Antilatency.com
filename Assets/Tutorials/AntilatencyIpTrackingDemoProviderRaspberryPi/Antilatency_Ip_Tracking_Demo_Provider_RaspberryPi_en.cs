using Csml;
using static Tutorials.Antilatency_Ip_Tracking_Demo_Provider_RaspberryPi_Assets;

partial class Tutorials : Scope {

    public static Material Antilatency_Ip_Tracking_Demo_Provider_RaspberryPi_en => new Material("Antilatency.IpTrackingDemo.Provider.RaspberryPi", Antilatency_Ip_Tracking_Demo_Provider_RaspberryPi_Assets.TitleImage, $"{new ExternalReference("https://github.com/antilatency/Antilatency.IpTrackingDemo.Provider.RaspberryPi", "Antilatency.IpTrackingDemo.Provider.RaspberryPi")} is a demo application that provides data from Antilatency Tracker ({Hardware.Alt}) connected to Raspberry Pi single board computer to network hosts.")

        [new Section("Preparation")
            [new UnorderedList()
                [$"Get Raspberry Pi 3 or 4 single board computer (RPi)."]
                [$"Prepare microSD card with modified OS image ({Tutorials.PrepareRaspberryPiSdCard})."]
                [$"Get fast WiFi router. {new ExternalReference("https://en.wikipedia.org/wiki/IEEE_802.11ac", "802.11ac 5 GHz mode")} support is highly recommended."]
                [$"Power on RPi then {new ExternalReference("https://www.raspberrypistarterkits.com/how-to/find-raspberry-pi-ip-address/", "find out")} board IP address."]
                [$"{new ExternalReference("https://github.com/antilatency/Antilatency.IpTrackingDemo.Provider.RaspberryPi/blob/master/BUILD.md", "Build and deploy")} AntilatencyIpTrackingDemoProvider app or just download binaries from GitHub release pages (place {new ExternalReference("https://github.com/antilatency/Antilatency.IpTrackingDemo.Provider.RaspberryPi/releases", "app")} to `/opt/antilatency/bin`, {new ExternalReference("https://github.com/antilatency/Antilatency.RaspberryPiSdk.Cpp/releases", "libs")} to `/opt/antilatency/lib`)."]
            ]
        ]

        [new Section("Send position and rotation to network hosts")
            [$"It is possible to place tens of Antilatency trackers ({Hardware.Alt}) with corresponding amount of RPi’s in the same tracking area. Each RPi can communicate with Alt through USB connection, compute actual position from raw sensors data then send the position to remote hosts via built-in WiFi module. There is the {Software.AntilatencyIpNetwork} (AIP) library which simplified network communication setup."]
        ]

        [new Section("Getting it all together")
            [$"{new ExternalReference("https://github.com/antilatency/Antilatency.IpTrackingDemo.Provider.RaspberryPi", "Antilatency.IpTrackingDemo.Provider.RaspberryPi")} demo shows how to obtain tracking data and GPIO state from RPi board, send it via network connection, detect USB reconnection, handle errors. Then you need to setup receiver using the same multicast group address to obtain tracking data from remote AntilatencyIpTrackingDemoProvider app."]
            [$"Start demo app (verbose output):"]
            [TrackingDemoOutput]
            [$"You can set:"]
            [new UnorderedList()
                [$"receiver IP (multicast group, see {Software.AntilatencyIpNetwork}) and port (default: `--receiver=239.255.111.X --port=56789`),"]
                [$"sending rate (default: `--wait-time=16` milliseconds, approximate 60 FPS),"]
                [$"tracking area (default: `--environment-code=AAVSaWdpZBcABnllbGxvdwQEBAABAQMBAQEDAAEAAD_W` {new ExternalReference ("https://antilatency.com/getting-started/latest/area#content", "DevKit")},"]
                [$"device ID (default: `--identifier=MAC_ADDR`),"]
                [$"GPIO pins state (for example: `--gpio=25:output:high` - sets {new ExternalReference("https://pinout.xyz/pinout/wiringpi", "WiringPi pin 25")} to output digital UP output mode)"]
                [$"path to a configuration file (for example: `--config=/etc/opt/antilatency/provider.conf`)."]
            ]
            [$"`/etc/opt/antilatency/provider.conf` example:"]
            [ProviderConf]
        ]

        [new Section("See also")
            [new UnorderedList()
                [$"{new ExternalReference("https://github.com/antilatency/Antilatency.IpTrackingDemo.Provider.RaspberryPi/blob/master/BUILD.md", "Build instruction")}."]
                [$"{Tutorials.PrepareRaspberryPiSdCard} - raspbian OS image modification."]
                [$"{Software.AntilatencyIpNetwork} library API reference."]
                [$"{new ExternalReference("https://www.youtube.com/watch?v=1VfFXoJiGFU", "Practical usage demonstration")}."]
            ]
        ]

        ;

    

}