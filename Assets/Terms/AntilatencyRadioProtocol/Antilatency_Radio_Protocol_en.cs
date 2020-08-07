using Csml;
using static Terms.Antilatency_Radio_Protocol_Assets;

partial class Terms {
    public static Material Antilatency_Radio_Protocol_en => new Material(null, null,
    $"Antilatency devices use a proprietory radio protocol to transmit data. The protocol operates on the 2.4GHz frequency. This radio protocol is optimized for real time performance and has a low latency while transmitting data.")
        [new Section("Devices supporting Antilatency Radio Protocol")
            [$"Receiver list"]
            [new UnorderedList()
                [$"{Hardware.SocketUsbRadio}"]
                [$"{Hardware.PicoG2Socket}"]
            ]

            [$"Transmitter list"]
            [new UnorderedList()
                [$"{Hardware.Tag}"]
                [$"{Hardware.Bracer}"]
            ]
        ]
        [new Section("Radio channel network topology")
            [$"In the {Terms.Antilatency_Radio_Protocol} we can single out two types of devices: "]
            [new OrderedList()
                [$"Receiver (Master)"]
                [$"Transmitter (Slave)"]
            ]
            [@$"Transmitters connect to a receiver and transmit their data to it. 
                The task of a receiver is to collect data from all transmitters, add its own data and send the resulting batch to the {Terms.Host} using a different interface (for instance, via a USB connection).
                For example, you can have a {Hardware.SocketUsbRadio} or a {Hardware.PicoG2Socket} working as receivers. 
                Possible options for transmitters are, for instance, a {Hardware.Tag} or a {Hardware.Bracer}.
            "]
            [new Info()
                [$"The {Hardware.SocketUsbRadio} can act both as a receiver and a transmitter, depending on configuration. "]
            ]
            [$"So, a standard networking connection to the {Terms.Host} through a radio protocol looks as follows:"]
            [new OrderedList()
                [$"Connecting a receiver to the {Terms.Host} via USB."]
                [$"Connecting transmitters to a receiver via a radio protocol"]
            ]
            [AntilatencyRadioProtocolTopology]
            [$"To configure devices supporting the {Terms.Antilatency_Radio_Protocol} please see section {Tutorials.ConfiguringRadioDevices}"]
        ]


        [new Section("Available channels", "channels")
            [$"For data transmission you can set a receiver to work on any of 141 radio channels ranging from 2360 to 2500 MHz."]
            [new Warning()
                [$"Some countries license some of the channels from this range (for example, 2360-2400 MHz, 2488-2500 MHz). Check with the local regulations before using a channel from this frequency band."]
            ]
            [@$"Software settings to choose a radio channel match indices with certain radio frequencies. For example, index 0 corresponds to 2360 MHz and index 140 represents 2500 MHz.
                If you have not set a specific radio channel, the receiver will randomly choose the first available channel from the list:
            "]
            [new UnorderedList()
                [$"42 = 2402 MHz"]
                [$"66 = 2426 MHz"]
                [$"92 = 2452 MHz"]
                [$"114 = 2474 MHz"]
                [$"120 = 2480 MHz"]
            ]
            [$"This radio channel list is organized for your convenience below."]
            [RadioChannelsImage]
            [new Info()
                [$"When a receiver chooses one of the channels listed above, it will illuminate its LED in the color that corresponds to a certain channel on the list."]
            ]
        ]


        [new Section("Connecting transmitters to a specified receiver: using MasterSN and ChannelsMask", "MasterSN")
            [@$"When set to default, transmitters will try to connect to the nearest receiver. This scenario is simple and useful for local testing when there is only one receiver working in the room.
                You can configure your transmitter to connect to a specific receiver (for more information, please see {Tutorials.ConfiguringRadioDevices}).
                Besides, to speed up the connection you can specify a channel mask for the transmitter to look for and connect to a receiver. If you use the full mask that includes all 141 channels, searching for a receiver will take quite a long time. However, if you limit the search to specific channels, the connection may take approximately 100 milliseconds.
            "]
        ]

        [new Section("Connecting several devices to one receiver")
            [@$"You can connect several transmitters to one receiver. The receiver will take turns querying the transmitters connected to it to get data from them.
                The bandwidth of the receiver's radio channel will be divided among all the transmitters connected to it. 
                The overall bandwidth capacity of the receiver's radio channel is 1.6Mbit/s. 
                Therefore, the bandwidth capacity between the receiver and transmitters, depending on your setup, will be:
            "]
            [new UnorderedList()
                [$"1 receiver - 1 transmitter at 1.6 Mbit/s"]
                [$"1 receiver - 2 transmitters at 0.8 Mbit/s each"]
                [$"1 receiver - 3 transmitters at 0.53 Mbit/s each"]
            ]
            [new Warning()
                [$"We do not recommend connecting more than four transmitters with trackers to one receiver"]
            ]
            [new Error()
                [$"TODO: In case of an unstable radio connection caused by the distance between the USB socket and the wireless socket, look for obstacles between these sockets, or suspect additional radio noise on this channel from other emitters. In this case, some packets from the wireless socket may be lost, which will lead to tracking task being restarted on the Alt tracker that connected to the wireless socket."]
            ]
        ]

        [new Section("Operating several receivers in one room")
            [$"Several receivers can work in one room. You can even connect several receivers to one host. If this is the case, you should set the receivers operating in one room to different channels."]
            [MultipleChannelsImage]
            [$"The following factors influence multiple receiver performance in one room:"]
            [new UnorderedList()
                [@$"outside factors, such as background radio noise on the premises.
                    The presence and configuration of wireless networks in the room may impact the performance of radio devices. The Antilatency Radio Protocol operates at 2.4 gHz. 
                    You are advised to scan the 2.4 gHz band in the room before choosing your channels.
                {new Info()[$"If you have access to the wireless network settings on the premises, you must configure your wireless devices to operate in the 5 gHz band. "]}"]

                [@$"Distance between channels set for receivers.
                    The closer the channels are to each other, the more interference you will get for devices working on neighboring channels. Therefore, you need to adjust the minimal distance between the channels depending on your operating conditions.  
                    A six-channel distance will exclude virtually all interference at a half-a-meter distance between the receivers. 
                    A distance of fewer than six channels may negatively affect the stability of multiple transmitters connected to one receiver. You will be well-advised to reduce the number of transmitters connected to one receiver to improve stability and network response.
                {new Warning() [$"To avoid significant network interference, we strongly advise not to use a distance of four channels or less. "]}"]
                
                [@$"Physical distance between receivers.
                    Receivers should not be located in close physical proximity to each other even if they work on different channels. The closer the receivers are to one another, the more mutual interference they will create. 
                {new Warning()[$"To prevent interference we recommend placing receivers no closer than 0.5 meters from each other."]}"]            
            ]
        ]
    ;
    


}