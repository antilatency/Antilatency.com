using Csml;
public partial class Software : Scope {
    public partial class AntilatencyService : Scope {
        public partial class Device_Network {

    public static Material Material_en => new Material("Device Network",
    DeviceNetworkTabScreenshot,
    $"Use this {AntilatencyService.Material} tab to look through the {Terms.Device_Tree}, to see the system and custom device properties, to see the firmware version of the connected devices and to update it.")

    [$"Use {AntilatencyService.Material} to read and write the device properties. Each property has its key(name) and value. To see the device properties choose its name in the {Terms.Device_Tree}."]

    [new Section("Системные свойства", $"")
            [$"Обязательные свойства содержат основную информацию об устройстве и не могут быть изменены пользователем:"]
                 [new UnorderedList()
                    [$"sys/HardwareSerialNumber - серийный номер устройства"]
                    [$"sys/FirmwareName - имя прошивки"]
                    [$"sys/FirmwareVersion - версия прошивки"]
                    [$"sys/HardwareName - имя устройства"]
                    [$"sys/HardwareVersion - версия устройства"]
                 ]
            [new Info($"О том, как обновить прошивку устройства, читайте тут: \n{Tutorials.Device_Update}")]
    ]
    
    [new Section("\nПользовательские свойства", $"")
             [$"Используя кастомные свойства, пользователь может вносить на устройства свои данные."]
    
     [new Info($"Более подробная информация о пользовательских настройках: \n{Tutorials.Set_Device_Custom_Properties}")]
      ]
       ;
        }
    }
}