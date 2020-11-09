using Csml;
using static Hardware.Bracer_Assets;

partial class Hardware : Scope {

    public static Material Bracer_en => new Material(
            "Bracer",
            Bracer_Assets.BracerProduct0,
             $"The Bracer is a wireless {Terms.Socket} to track the user's hands designed for an ergonomic fit. Unlike standard VR controllers, the Bracer adds on 6DoF hand tracking while keeping the user's hands free to interact with material objects."
             )

            [new Section("Low latency radio protocol")
                [$"The Bracer uses the {Terms.Antilatency_Radio_Protocol} to send data. The Bracer can act only as a transmitter."]
                [new Warning()
                    [$"The host must have a receiver to receive data (for example, a {Hardware.HMD_Radio_Socket}). For more information, please see {Terms.Antilatency_Radio_Protocol}"]
                ]
            ]
            
            [new Section("Rechargeable battery")
                [@$"The Bracer has a built-in 250 mAh rechargeable battery. 
                The Bracer is supplied with a battery charger module. It is inserted into the {Hardware.Alt} tracker slot. The Bracer will not function while charging. 
                "] 
            ]

            [new Section("Touch pad")
                [$"The Bracer includes a touch pad. When a Bracer is worn on one's hand, this pad fits on the palm. Thanks to this pad, the Bracer can detect grasp and release gestures in VR."] 
            ]

            [new Section("Haptic feedback")
                [$"The Bracer has a built-in haptic response unit that allows for tactile feedback from user actions. This unit is controlled from a user application with the help of an API"] 
                [new Error()
                    [$"TODO: Link to API "]
                ]
            ]

            [new Section("Designed for hands ")
                [$"The Bracer has been custom-designed to be worn on one's hand. The Bracer has a retainer strap that can be fixed in position to fit the size of the user's palm."] 
            ]

            [new Section("Technical specifications")
                [new Table(2)
                    [$"Connectivity"][$"2.4GHz Proprietary radio protocol (Slave mode only)"]
                    [$"Battery"][$"250mAh internal LiPo rechargeable battery"]
                    [$"Charging mode"][@$"Charging through the {Hardware.Alt} slot with a dedicated charger module
                                        Bracer cannot be used during charging.
                                        Current consumption by charging: 250mA@5V"]
                    [$"Haptic feedback "][$"LRA haptic feedback"]
                    [$"Touch sensing element"][$"worn on the palm"]
                    [$"Indication"][@$"RGB LED
                                       For LED signals see table below TODO"]
                    [$"Dimensions"][$"111х38х32.6 mm"]
                    [$"Weight"][$"35 g"]
                ]
            ]

            [new Section("LED signals") 
                [IndicationTable_en]
            ]

        ;
}