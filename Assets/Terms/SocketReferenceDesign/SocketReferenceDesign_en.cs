using Csml;

using static Terms.SocketReferenceDesignDeploying_Assets;

partial class Terms {
    public static Material SocketReferenceDesign_en => new Material(null, TopView,
    @$"A development board for {Terms.Socket}.")
        [new Section("Main components")
            [new UnorderedList()
                [$"nRF52840 module"]
                [$"SWD connector"]
                [$"USB connector"]
                [$"DC/DC 3V"]
                [$"{Hardware.Alt} connector"]
                [$"RGB status led"]
                [$@"{Terms.Antilatency_Hardware_Extension_Interface} components(optional):
                    {new UnorderedList()
                    [$"LEDs"]
                    [$"buttons"]
                    [$"trimmers"]}"
                ]

            ]
        ]

        [new Section("Recommendations for the board")
            [new UnorderedList()
                [$"2mm height - to install the magnet correctly."]
                [$"Immersion gold plating - to provide the throwing power, the high-wearing feature, and the stable connection of the {Hardware.Alt} pogo pins and the board."]
            ]
        ]

        [new Section("nRF52840 module")
            [$"We highly recommend using nRF52840 module instead of nRF52840 microcontroller with its external required components. Using the module gives some benefits:"]

            [new UnorderedList()
                [$"The module is certified that accelerates the arrival on the market."]
                [$"The BOM reduction makes the board assembly process easier providing fewer mistakes."]
                [$"All the external required components are already installed that prevents the incorrect assembly."]
                [$"Commonly, the market offers a range of the modules with different antennas or connectors for all tastes. "]
                [$"Some manufacturers offer to preinstall the firmware/bootloader."]
        
            ]
            [new Warning($"You can use nRF52840 microcontroller with its external required components and RF instead of a module. But this decision has its consequences.")
        ]

        [new Section("Power Supply")
            [$" The controller and {Hardware.Alt} require a 3V power supply, an average consumption is about 200mA in operating mode. You need a regulator with at least a 250-300mA current limit. We use DC/DC NCP1529MUTBG."]
            [new Info($"USB module requires 5V power supply. This input powers only the USB module (less than 1mA)")]
            [new Info($"Using VCC3V jumper, you can turn off 3.0V output and connect external power supply.")]
        ]

        [new Section("USB connector")
            [$"USB provides 5V power supply and connection with the controller to transfer the data, to update the firmware and to set up the device properties."]
             [new Info($"Use USB5V jumper to connect your power supply. When you don't need USB, for example, when Socket works in wireless mode, any voltage in the range of 3V - 5.5V can be applied to the VBUS input.")]
        ]

        [new Section("SWD connector")
            [$"You need an SWD connector only for the first bootloader setup. For further firmware uploading or updating, you can use {Terms.AntilatencyService}."]
            [$"The board has two similar connectors: MicroMatch FOB.06P и Pls-4. You can use any of them for your board."]
            [new Info($"You don't need the connector if your module has preinstalled firmware.")]
        ]

        [new Section($"{Hardware.Alt} connector")
            [$"{Hardware.Alt} connector has 8 contact areas and a hole for the magnet in the center. Alt frame installation requires the holes. Read here to learn more: {Tutorials.SocketReferenceDesignDeploying:mechanics}"]
        ]

        [new Section("RGD status LED")
            [$"RGB LED allows user to see the Socket state. This LED has different display modes. We highly recommend you not to remove it and use the same LED on your board."]
            [new Info($"You can choose other LED but make sure their colors correspond.")]
        ]

        [new Section($"{Terms.Antilatency_Hardware_Extension_Interface} components")
            [$"Optional. If you don't need {Terms.Antilatency_Hardware_Extension_Interface}, then just don't use its components and let the controller's pins free."]
            [$"We set 2 buttons, 2 	potentiometer trimmers, and 4 LEDs on the board. Each component is connected by jumper so you can turn it off on the board and put the external power supply."]
        ]
        ]

    ;
}
