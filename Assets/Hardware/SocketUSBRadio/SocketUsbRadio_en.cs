using Csml;

partial class Hardware : Scope {

    public static Material SocketUsbRadio_en => new Material(
            "HMD Radio Socket",
            SocketUsbRadio_Assets.SocketUsbRadioProduct0,
             $"The {Hardware.SocketUsbRadio} is a wireless {Terms.Socket} that supports both data reception from wireless devices via the {Terms.Antilatency_Radio_Protocol} and tracking data transmission when placed on the objects being tracked.")

            [new Section("A universal data receiver via a radio protocol")
                [@$"When the {Terms.Antilatency_Radio_Protocol} is running, as a rule, the {Hardware.SocketUsbRadio} serves as a data receiver from transmitters. In this case the USB type-C port is used to power the {Hardware.SocketUsbRadio} and send data to the {Terms.Host} via USB. 
                    For other modes of operation, please see {Hardware.SocketUsbRadio}.
                "]
            ]
            
            [new Section("Operating as a data transmitter")
                [$"Using the “Mode” property, you can configure the {Hardware.SocketUsbRadio} to work as a data transmitter via a radio protocol. In this case the {Hardware.SocketUsbRadio} is powered by an external power bank."] 
            ]

            [new Section("External power source")
                [$"You can power the {Hardware.SocketUsbRadio} from an external power bank via the USB type-C port. In this case the {Hardware.SocketUsbRadio} functions as a transmitter, similarly to the {Hardware.Tag}"] 
            ]

            [new Section("Extension board support")
                [@$"The {Hardware.SocketUsbRadio} supports the {Hardware.ExtensionBoard}. The {Hardware.ExtensionBoard} connects to the {Hardware.SocketUsbRadio} through the USB type-C port to transmit data about external triggers and response control (vibration, etc.). The {Hardware.SocketUsbRadio} sends these data, along with tracking data, to its receiver. 
                    For more details, please see {Terms.Antilatency_Hardware_Extension_Interface}. 
                "] 
            ]

            [new Section("Modular design")
                [@$"The {Hardware.SocketUsbRadio} can be used to track objects instead of the {Hardware.Tag} if the tracked object has its own battery or an external battery can be fitted inside or outside the object's casing. In this case the {Hardware.SocketUsbRadio} has smaller dimensions than the {Hardware.Tag} and gets its power from an external power bank. 
                    The {Hardware.SocketUsbRadio} can be attached with double-sided adhesive tape or using its mounting holes for a secure fit (TODO for more information, please see the file with a model of the casing).
                "] 
            ]

            [new Section("Technical specifications")
                [new Table(2)
                    [$"Connectivity"][@$"2.4GHz Proprietary radio protocol (Master and Slave modes)
                                        USB 2.0 Full Speed"]
                    [$"Ports"][$"Usb Type-C port for Power and Data Transfer"]
                    [$"Battery"][@$"No built in battery
                                    External power banks are supported "]
                    [$"Antilatency Hardware Extension Interface support "][$"Yes"]
                    [$"Power supply"][$"USB 5V"]
                    [$"Current consumption"][@$"Without {Hardware.Alt}: 15mA@5V
                                                With {Hardware.Alt}: 115mA@5V"]
                    [$"Indication"][@$"RGB LED
                                       For LED signals see table below TODO"]
                    [$"Dimensions"][$"9.1x18.2x32.1 mm"]
                    [$"Weight"][$"7.2 g"]
                ]
            ]

            [new Section("LED signals") 
                [new Table("Led signal","Socket state")
                    [$"Blinking green light (on/off)"][$"Radio is disabled (Connection limit is 0)"]
                    [$"Green to blue cyclic change"][$"Searching for a free radio channel or the radio channel is set to a specific value and this channel is occupied by another device"]
                    [$"Blinking <color> (on/off)"][$"{Hardware.SocketUsbRadio} found a channel to work with and now waits for wireless sockets. <color> is the channel identification, different channels will have different colors"]
                    [$"Smoothly blinking <color>"][$"{Hardware.SocketUsbRadio} has at least one other wireless socket connected to it, <color> will be equal on these devices"]
                    [$"Bright red to pale red cyclic change"][$"Bootloader mode"]
                    [$"Constant red light"][$"Device error, it will be restarted in a few seconds"]
                    [$"Red blinking (on/off) for N times"][$"Hardware error, N – error code"]
                ]
            ]

        ;
}