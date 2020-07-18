using Csml;
partial class Tutorials {
    public static Material ConfiguringRadioDevices_en => new Material("Wireless Devices Configuration",
    ConfiguringRadioDevices_Assets.TitleImage,
    $"In this tutorial we will look at configuring and using wireless devices in Antilatency. We will learn how to configure the system for top productivity and make it more stable. This is essential for multi-user scenarios and complex setups.")
        [new Section("Possible options")
            [new OrderedList()
                [$"Set the *receiver* to the maximum amount of connected transmitters(`ConnLimit`). You will save time looking for and connecting to available devices. This will increase network throughput and reduce latency."]
                [$"Set a specific channel(`RadioChannel`) on the *receiver*. You will thus select a less noisy channel and assign different frequencies to different receivers."]
                [$"Set a channel mask(`ChannelsMask`) for the *receiver*. The system will search for the right receiver much faster."]
                [$"Set a serial number  (`MasterSN`) on the  *receiver*. Your connection will work only with one specific receiver."]
            ]
            [new Info($"In some cases, setting a serial number `MasterSN` will also cut down on device connection time even for a large mask because the search will stop right after detecting a designated receiver. If you do not enable this setting, the search will stop only after scanning all available channels.")]
        ]
        [new Section("Reconnecting to the receiver")
            [$"The receiver will fail to connect if configured wrong. This means that configuring it would be impossible. However, there is a way to re-connect to the device."]
            [new UnorderedList()
                [@$"The *serial number*(`MasterSN`) on the receiver is set to an *unknown receiver* or lost. You can reset this with the help of {ConfiguringRadioDevices:ResetMaster} "]                    
                [@$"The receiver is set to an *unknown channel mask*(`ChannelsMask`). To solve this problem, set the receiver to Channel `92`. This channel is always active for search and it cannot be reset."]]
        ]
        [new Info($"First, you need to set up the transmitter and only then the receiver.")]

        [new Section("Transmitter properties")
            [new UnorderedList()
                [@$"`MasterSN`
                    This property enables the transmitter to connect only to a specific receiver. After receiving the serial number from the receiver, you can enter it into the `MasterSN` setting of the transmitter. It will then connect only to the receiver with this serial number.
                    You can set this up in two ways (by using a button on the socket {ConfiguringRadioDevices:SetMasterSoft} and with the help of {Terms.AntilatencyService}. For more information, please see {ConfiguringRadioDevices:SetMasterHard}). The receiver will display this setting as enabled or not, see {Hardware.Tag:LED signals}. "]

                [$@"`ChannelsMask` 
                    sets the channel mask for the transmitter to look for a receiver connection.  
                    This is a 141-symbol line (corresponds to the number of available channels) consisting of 0's and 1's where 1 denotes that the respective channel will be used while searching for a receiver while 0 implies that the channels will be ignored. The first symbol in the line is responsible for the last channel (140). 
                The default channel mask looks as follows: 
                `000000000000000000001000001000000000000000000000100000000000000000000000001000000000000000000000001000000000000000000000000000000000000000000`
                The location of 1's in this mask corresponds to the default channel list (42, 66, 92, 114, 120).
                For your convenience, you can use aliases that can be sent instead of a line mask: {new UnorderedList()
                        [$"`full` - all channels are active for search"]
                        [$"`default` - only five channels are active for search by default"]
                        [$"`N` - only channel 'N' is active for search. For example, for channel `140` a `100....000` mask will be set"]}"]
            ]
        ]

        [new Section("Receiver properties")
            [new ToDo("Link to the article on properties.", true)]            
            [new OrderedList()
                [@$"`RadioChannel`
                    The default setting is `-1`. The receiver will randomly select the first available radio channel from the list: 42 = 2402 MHz, 66 = 2426 MHz, 92 = 2452 MHz, 114 = 2474 MHz, 120 = 2480 MHz.
                    You can set a specific channel in the range of `0 - 140`, that will be used. To know how the channel id is mapped to a radio frequency, please see {Terms.Antilatency_Radio_Protocol:channels}
                "]
                [@$"`ConnLimit`
                    This is a maximum number of transmitters that that can connect to this receiver. The `0` value shuts down the radio on the device completely. If the value exceeds the number of connected devices, part of the traffic will go toward searching for new devices. Therefore, set this value to exactly match the number of the planned connections."]
            ]
        ]

        [new Section("Reset MasterSN property by wireless socket's power button", "ResetMaster") 
            [$"Power up the wireless socket and press the power button for 5 seconds, after that the wireless socket will be restarted and the `MasterSN` property will be erased."]
        ]

        [new Section($"Set MasterSN property by wireless socket's power button", "SetMasterHard")
            [$"Below is a configuration where {Hardware.SocketUsbRadio} serves as a receiver."]
            [new OrderedList()
                [$"Connect the {Hardware.SocketUsbRadio} to the {Terms.Host}"]
                [$"Power up the wireless socket by the single-click power on button"]
                [$"Check that the wireless socket is connected to the {Hardware.SocketUsbRadio} (both device LEDs will be blinking smoothly with the same color)"]
                [$"Press and hold the power button on the wireless socket for about 5 seconds, after that the wireless socket will be restarted and save the {Hardware.SocketUsbRadio}’s hardware serial number in the `MasterSN` property."]
            ]
        ]

        [new Section($"Set MasterSN property by {Software.Antilatency_Service}", "SetMasterSoft")
            [$"Below is a configuration where {Hardware.SocketUsbRadio}serves as a receiver."]
            [new OrderedList()
                [$"Connect the {Hardware.SocketUsbRadio} to the {Terms.Host}"]
                [$"Power up the wireless socket by the single-click power on button"]
                [$"Run {Software.Antilatency_Service} application"]
                [$"Open Device Network tab"]
                [$"Click on the {Hardware.SocketUsbRadio} node in the Device Network tab"]
                [$"Select the `{Api.Antilatency.DeviceNetwork.Interop.Constants.Fields.HardwareSerialNumberKey.Value}` property value and press Ctrl+C"]
                [$"Click on the wireless radio socket node in the Device Network tab"]
                [$"Select the `MasterSN` property value, press Ctrl+V, and click on the Set button"]
            ]
        ]



        
    ;
    


}