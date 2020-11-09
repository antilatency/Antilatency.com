using Csml;

partial class Hardware : Scope {

    public static Material PicoG2Socket_en => new Material(
            "Pico G2 Socket",
            PicoG2Socket_Assets.PicoG2SocketProduct0,
             $"The Pico G2 Socket is a wireless {Terms.Socket} designed to track the PicoG2 headset and receive data from wireless devices via the {Terms.Antilatency_Radio_Protocol}.")

            [new Section("Design for the Pico G2 headset")
                [$"The Pico G2 Socket has been custom-designed to fit the shape of the Pico G2 headset. The Pico G2 Socket tracks with the help of a USB type-C port on the headset and locks securely in place on the headset."]
            ]
            
            [new Section("Receiving data from wireless devices via a radio protocol")
                [$"When the {Terms.Antilatency_Radio_Protocol} is running, the Pico G2 Socket acts as a data receiver from the transmitters. The Pico G2 Socket collects data from wireless devices that are connected to it and forwards them to the headset through USB, along with the data from its own tracker."] 
            ]

            [new Section("An extra USB type-C Female port")
                [$"Apart from a USB type-C Male port to connect to the headset, the Pico G2 Socket has a USB type-C Female port. When a cable is connected to the USB type-C Female port, the Pico G2 Socket begins to work as a USB-adapter for charging and a USB data interface with the headset. Therefore, if you plug the Pico G2 Socket into the headset once and lock it in place, you will not need to disconnect and remove it. The headset will charge and install applications via USB using the USB type-C Female port we discussed earlier."] 
                [new Info()
                    [$"The Pico G2 Socket operates in two mutually exclusive modes: either as a USB device channeling tracking data into the headset or as a USB-adapter."]
                ]                
            ]


            [new Section("Technical specifications")
                [new Table(2)
                    [$"Connectivity"][@$"2.4GHz Proprietary radio protocol (Master only)
                                        USB 2.0 Full Speed"]
                    [$"Ports"][@$"Usb Type-C Male connector for connection between Pico G2 Socket and headset
                                  Usb Type-C Female connector for charging and connection between headset and PC"]
                    [$"Power supply"][$"USB 5V"]
                    [$"Current consumption"][@$"Without {Hardware.Alt}: 15mA@5V
                                                With {Hardware.Alt}: 115mA@5V"]
                    [$"Indication"][@$"RGB LED
                                       For LED signals see table below TODO"]
                    [$"Dimensions"][$"44.1×21×36 mm"]
                    [$"Weight"][$"12 g"]
                ]
            ]

            [new Section("LED signals") 
                [PicoG2Socket_Assets.IndicationTable_en]
            ]

        ;
}