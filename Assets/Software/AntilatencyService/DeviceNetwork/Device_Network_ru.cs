using Csml;
public partial class Software : Scope {
    public partial class AntilatencyService : Scope {
        public partial class Device_Network {

    public static Material Material_ru => new Material("Device Network",
    Title,
    $"Вкладка {AntilatencyService.Material}, где вы можете посмотреть дерево устройств Antilatency, их системные и пользовательские свойства, а также узнать и обновить прошивку подключённых устройств.")

    [$"Используя Device Network, пользователь может читать и писать свойства устройств. Каждое свойство состоит из ключа (имени) и значения. Чтобы посмотреть данные о конкретном устройстве, нажмите на его имя в {Terms.Device_Tree}."]

    [DeviceNetworkTabScreenshot]

    [new Section("Системные свойства", $"")
            [$"Обязательные свойства содержат основную информацию об устройстве и не могут быть изменены пользователем:"]
                 [new UnorderedList()
                    [$"sys/HardwareSerialNumber - серийный номер устройства"]
                    [$"sys/FirmwareName - имя прошивки"]
                    [$"sys/FirmwareVersion - версия прошивки"]
                    [$"sys/HardwareName - имя устройства"]
                    [$"sys/HardwareVersion - версия устройства"]
                 ]
            [new Info($"О том, как обновить прошивку устройства, читайте тут: \n{Tutorials.Firmware_Update}")]
    ]
    
    [new Section("\nПользовательские свойства", $"")
             [$"Используя кастомные свойства, пользователь может вносить на устройства свои данные."]
    
     [new Info($"Более подробная информация о пользовательских настройках: \n{Tutorials.Set_Device_Custom_Properties}")]
      ]
       ;
        }
    }
}