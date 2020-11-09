using Csml;
public partial class Software : Scope {
    public partial class AntilatencyService : Scope {
        public partial class Device_Network {

    public static Material Material_en => new Material("Device Network",
    Title,
    $"Use this {AntilatencyService.Material} tab to look through the {Terms.Device_Tree}, to see the system and custom device properties, to see the firmware version of the connected devices and to update it.")

    [$"Use {AntilatencyService.Material} to read and write the device properties. Each property has its key(name) and value. To see the device properties choose its name in the {Terms.Device_Tree}."]
    [DeviceNetworkTabScreenshot]

    [new Section("System properties", $"")
            [$"The system properties contain the main information about the device. You can not change them."]
                 [new UnorderedList()
                    [$"sys/HardwareSerialNumber"]
                    [$"sys/FirmwareName"]
                    [$"sys/FirmwareVersion"]
                    [$"sys/HardwareName"]
                    [$"sys/HardwareVersion"]
                 ]
            [new Info($"Please, read here how to update the firmware: \n{Tutorials.Firmware_Update}")]
    ]
    
    [new Section("\nCustom properties", $"")
             [$"Use the custom properties to configure your device. For example, you can write the Tag `gun` for the specific VR gadget or `LeftHand` for the device on the left hand."]
    
     [new Info($"Please, read here how to set the custom properties: \n{Tutorials.Set_Device_Custom_Properties}")]
      ]
       ;
        }
    }
}