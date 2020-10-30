using Csml;
using static Hardware.Tag_Assets;

partial class Hardware : Scope {

    public static Material Tag_en => new Material(
            "Tag",
            Tag_Assets.TagProduct0,
             @$"The {ThisDevice} is a wireless {Terms.Socket} that can be attached to an object or a part of the human body to track them. 
             The {ThisDevice} does not track its own position, but relays data from the {Hardware.Alt} fitted into it. 
             The {ThisDevice} can track material objects and custom controllers, for example dummy guns."
             )

            [new Section("Low latency radio protocol")
                [$"The {ThisDevice} relies on the {Terms.Antilatency_Radio_Protocol} to transmit data. The {ThisDevice} can act only as a transmitter."]
                [new Warning()
                    [$"In order to receive data the host must have a receiver, for example a {Hardware.SocketUsbRadio}. For more information, please see {Terms.Antilatency_Radio_Protocol}"]
                ]
            ]
            
            [new Section("Rechargeable battery")
                [$"The {ThisDevice} has a built-in 250 mAh rechargeable battery. The USB Type-C port is used only to charge the battery. The {ThisDevice} is fully functional while the battery is charging, including transmission of tracking data from the {Hardware.Alt}."] 
            ]

            [new Section("Compact design")
                [$"The {ThisDevice} is highly portable (8.5x18.2x65.7 mm) and weighs as little as 18 grams, so it can be attached even to small objects. You can secure the {ThisDevice} with double-sided adhesive tape or use the mounting holes for a tighter fit (please see the TODO file with a model of its casing)."] 
            ]

            [new Section("Technical specifications")
                [new Table(2)
                    [$"Connectivity"][$"2.4GHz Proprietary radio protocol (Slave mode only)"]
                    [$"Ports"][$"Usb Type-C port for charging only"]
                    [$"Battery"][$"250mAh internal LiPo rechargeable battery"]
                    [$"Charging mode"][@$"Fully functional while charging
                                         Current consumption by charging: 350mA@5V"]
                    [$"Indication"][@$"RGB LED
                                       For LED signals see table below TODO"]
                    [$"Dimensions"][$"8.5x18.2x65.7 mm"]
                    [$"Weight"][$"18 g"]
                ]
            ]

            [new Section("LED signals") 

            [IndicationTable_en]
            
            ]

        ;
}