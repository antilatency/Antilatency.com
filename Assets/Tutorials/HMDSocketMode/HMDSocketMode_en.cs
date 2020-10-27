using Csml;
public partial class Tutorials : Scope {

    public static Material HMDSocketMode_en => new Material("HMD Socket Modes",
    null, 
    $"The {Hardware.SocketUsbRadio} has two modes: wired and wireless. Use the {Software.AntilatencyService.Material} to configure the mode for any attached Socket. Each mode defines the device properties depending on its functions.")

    [$"From the firmware version 1.3.0, the SocketUsbRadio has two modes:"]

        [new UnorderedList()
            [$"wired, or radio master - any wireless {Terms.Socket} can connect to this one; radio master transfer the data via USB;"]
            [$"wireless, or radio slave - such device can connect to SocketUsbRadio device and transfer the data via radiochannel."]
        ]

    [@$"
    If you need to change the mode use the tab {Software.AntilatencyService.Device_Network.Material} of the AntilatencyService. Set to the Mode property one of the following values: {new UnorderedList() 
    [$"UsbRadioSocket (wired)"] 
    [$"RadioSocket (wireless)"]}"] 
    [new Warning($"You can update the Socket firmware *ONLY* in UsbRadioSocket mode.")]
    [$"\nThe device in each mode has an independent bunch of properties. The custom properties, for example, Tag, are the same for all the modes."]
    [new Info($"Please, read here to learn more about the device properties: {Tutorials.ConfiguringRadioDevices}.")]

    [new Section("UsbRadioSocket")

        [UsbRadioSocket]

        [new Section("Special properties","")]
        
        [new UnorderedList()
                [new Paragraph(@$"`RadioChannel` - by default, the receiver chooses one random radiochannel from the five available. Please, read here to learn more about the radio protocol: {Terms.Antilatency_Radio_Protocol:channels}")]

                [$"`ConnLimit` - the max of the Sockets you can connect to this receiver."]
        ]
                [new Info($"We highly recommend setting the exact amount of the devices you are going to connect. Either, you may waste the traffic on searching for the new devices.")]
                
        ]
    

    [new Section("RadioSocket")


        [$"From the firmware version 5.0.0 the wireless {Hardware.SocketUsbRadio} appears in the {Terms.Device_Tree} as the additional node *AltHmdRadioSocketShadow*. But firstly, you need to connect the device via USB. \nYou can also configure its properties: set the channel mask, the MasterSN or change the Socket mode."]
            [new Info($"If you connect the wireless Socket via USB and at the same time - to the wired Socket, it will be displayed in the Device Tree twice under different names.")]
        [RadioSocket]
        [RadioSocket1]

        [new Section("Special properties","")]

        [new UnorderedList()
            [$"`MasterSN` - defines the serial number of the master device (receiver);"]
            [$"`ChannelsMask` - defines the channel mask used to find the receiver to connect to."]
        ]
    
    ]
;
}
