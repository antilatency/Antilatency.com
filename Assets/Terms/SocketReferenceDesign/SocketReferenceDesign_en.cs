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
                [$"RGB status LED"]
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
                [$"ENIG - to provide the throwing power, the high-wearing feature, and the stable connectivity of the {Hardware.Alt} pogo pins and the board."]
            ]
        ]

        [new Section("nRF52840 module")
            [$"We highly recommend using an nRF52840 module instead of an nRF52840 microcontroller with its external required components. Using the module gives some benefits:"]

            [new UnorderedList()
                [$"The module is certified that accelerates the arrival on the market."]
                [$"The BOM reduction makes the board assembly process easier, resulting in fewer mistakes."]
                [$"All the external required components are already installed thereby preventing incorrect assembly."]
                [$"The market normally offers a range of modules with different antennas or connectors for all tastes. "]
                [$"Some manufacturers offer to preinstall the firmware/bootloader."]
        
            ]
            [new Warning($"You can use an nRF52840 microcontroller with its external required components and a RF instead of a module. But this choice has its consequences.")
        ]

        [new Section("Power Supply")
            [$" The controller and {Hardware.Alt} require a 3V power supply. Average consumption is about 200mA when in operation. You need a regulator with at least a 250-300mA current limit. We use a DC/DC NCP1529MUTBG."]
            [new Info($"The USB module requires a 5V power supply. This input powers only the USB module (less than 1mA)")]
            [new Info($"When using the VCC3V jumper, you can turn off the 3.0V output and connect an external power supply.")]
        ]

        [new Section("USB connector")
            [$"The USB connector provides a 5V power supply and a connection to the controller to transfer the data, to update the firmware and to set up the device properties."]
             [new Info($"Use the USB5V jumper to connect your power supply. When you have no need for USB, for example, when the Socket works in wireless mode, any voltage in the range of 3V - 5.5V can be applied to the VBUS input.")]
        ]

        [new Section("SWD connector")
            [$"You need an SWD connector only for the first bootloader setup. For further uploading or updating of the firmware, you can use {Terms.AntilatencyService}."]
            [$"The board has two similar connectors: a MicroMatch FOB.06P and a Pls-4. You can use either of them with your board."]
            [new Info($"You don't need the connector if your module has preinstalled firmware.")]
        ]

        [new Section($"{Hardware.Alt} connector")
            [$"The {Hardware.Alt} connector has 8 contacts and a hole for the magnet in the center. Alt frame installation also requires the holes. Read here to learn more: {Tutorials.SocketReferenceDesignDeploying:mechanics}"]
        ]

        [new Section("RGB status LED")
            [$"The RGB LED allows users to see the state of the Socket. This LED has different display modes. We highly recommend that you do not remove it and use the same LED on your board."]
            [new Info($"You can choose another LED but make sure their colors correspond.")]
        ]

        [new Section($"{Terms.Antilatency_Hardware_Extension_Interface} components")
            [$"Optional. If you don't need the {Terms.Antilatency_Hardware_Extension_Interface}, then just don't use its components and leave the controller's pins free."]
            [$"There are 2 buttons, 2 	potentiometer trimmers, and 4 LEDs on the board. Each component is connected by jumper so you can turn it off on the board and put the external power supply."]
        ]
        ]

    ;
}
