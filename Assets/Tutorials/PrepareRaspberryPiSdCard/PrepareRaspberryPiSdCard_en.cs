using Csml;
using static Tutorials.PrepareRaspberryPiSdCard_Assets;

public partial class Tutorials : Scope {

    public static Material PrepareRaspberryPiSdCard_en => new Material("Prepare SD card image for Raspberry Pi", TitleImage, $"")
        [new Section("Prepared SDcard image")
            [$"You can {new ExternalReference("https://yadi.sk/d/wWYRHLgcPli9FQ", "download")} Rasperry Pi 3+ image with installed Antilatency software:"]
            [new UnorderedList()
                [$"{Tutorials.Antilatency_Ip_Tracking_Demo_Provider_RaspberryPi}"]
                [$"{new ExternalReference("https://github.com/antilatency/Antilatency.RaspberryPiSdk.Cpp", "Antilatency Raspberry Pi SDK: C++ bindings")}"]
            ]
        ]

        [new Section("Raspbian")
            [$"{new ExternalReference("https://www.raspbian.org/", "Raspbian")} is the Raspberry Pi Foundation’s official supported operation system based on Debian GNU/Linux."]
            [$"Images:"]
            [new UnorderedList()
                [$"{new ExternalReference("https://downloads.raspberrypi.org/raspbian_lite_latest", "Raspbian Lite")} - minimal image with command line interface."]
                [$"{new ExternalReference("https://downloads.raspberrypi.org/raspbian_latest", "Raspbian Desktop ")} - Raspbian Lite + graphical user interface: {new ExternalReference("https://www.raspberrypi.org/blog/introducing-pixel/", "PIXEL desktop environment")}"]
            ]
            [$"Download preferred type of image and {new ExternalReference("https://www.raspberrypi.org/documentation/installation/installing-images/README.md", "write it to microSD card")} (you can install or remove GUI apps later)."]
        ]

        [new Section("Wireless setup")
            [$"You need to write WiFi network name / password to the Raspberry Pi SD card and enable SSH server before you can get remote access."]
            [$"Insert microSD card to your PC card reader then create two files `wpa_supplicant.conf` and `ssh` in the `boot` folder on the SD card."]

            [$"See {new ExternalReference("https://www.raspberrypi.org/documentation/configuration/wireless/headless.md", "headless setup")} manual for details."]
        ]

        [new Section("Update installed software")
            [AptUpdate]
        ]

        [new Section($"Power button")
            [$"Add support for {Terms.AntilatencyRPiSocket} power button."]
            [$"Enable software shutdown via GPIO:"]
            [$"See more {new ExternalReference("https://www.stderr.nl/Blog/Hardware/RaspberryPi/PowerButton.html", "PowerButton")}"]
            [GpioShutdown]

            [$"Install WiringPi:"]
            [$"{new ExternalReference("https://pinout.xyz/pinout/wiringpi","WiringPi", "“WiringPi is an attempt to bring Arduino-wiring-like simplicity to the Raspberry Pi. The goal is to have a single common platform and set of functions for accessing the Raspberry Pi GPIO across multiple languages.”")}"]
            [$"`sudo apt update && sudo apt install wiringpi`"]

            [$"Set `RPI_OS_OK GPIO` pin to `HIGH` state:"]
            [RcLocal]
            [$"Add lines:"]
            [RpiOsOkGpioPinRcLocal]
            [$"before `exit 0` line. Then press `Ctrl+o` then press Enter for saving result. Press `Ctrl+x` for exit."]

            [$"Setup `RPI_OFF_OK` GPIO pin:"]
            [RpiOffOkGpioPinSystemD]
        ]

        [new Section($"Prepare installation directory")
            [$"Create package directories for Antilatency software and change owner:"]
            [CreateOptAntilatencyDir]           

            [$"Add rule for Antilatency USB devices:"]
            [AntilatencyUdevRules]
            
        ]
        ;

    

}