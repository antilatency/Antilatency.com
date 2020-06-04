using Csml;
partial class Tutorials {
    public static Material ConfiguringRadioDevices_ru => new Material("Конфигурация беспроводных устройств",
    ConfiguringRadioDevices_Assets.TitleImage, 
    $"")
        [new Section("Базовый набор действий")
            [$"Для получения данных с беспроводных устройств на хосте необходимо выполнить набор действий:"]
            [new OrderedList()
                [$"Конфигурация приемника"]
                [$"Конфигурация передатчика (или Pair передатчика и приемника)"]
            ]
        ]
        [new Section("Конфигурация приемника")
            [$"Ниже описана конфигурация приемника на примере {Hardware.SocketUsbRadio}."]
            [new OrderedList()
                [$"Connect the {Hardware.SocketUsbRadio} to the {Terms.Host}"]
                [$"Run the {Software.Antilatency_Service} application"]
                [$"Open Device Network tab"]
                [@$"Set “RadioChannel” property.
                    The default value is -1 – in this case the socket will choose the first free radio channel from the list: 42 = 2402 MHz, 66 = 2426 MHz, 92 = 2452 MHz, 114 = 2474 MHz, 120 = 2480 MHz.
                    You can set a specific channel in the range of 0 - 140, that will be used. To know how the channel id is mapped to a radio frequency, см. {Terms.Antilatency_Radio_Protocol:channels}
                "]
                [@$"Set a connection limit by applying the corresponding value to the “ConnLimit” property. 
                    If you don’t need to use radio on this socket, set the value to 0. 
                    If you plan to use only 1 wireless device, set it to 1. 
                    If you plan to connect 2 wireless devices to this socket, set it to 2. 
                    You can keep this setting at 2 while using only one wireless device, but some of the radio traffic will be used searching for a 2nd device."]
            ]            
        ]

        [new Section("Конфигурация передатчика")
            [@$"Можно сконфигурировать передатчик, чтобы он подключался только к конкретному приемнику, используя свойство MasterSN (Подробнее о MasterSN См. {Terms.Antilatency_Radio_Protocol:MasterSN})
            Существует 2 способа, чтобы задать свойство MasterSN.
            Перед тем как запарить передатчик и приемник нужно удостовериться, что у передатчика еще не выставлено значение свойства MasterSN. См. Check and reset MasterSN property. 
            "]
        ]

        [new Section("Check MasterSN property")
            [$"Для проверки того, что у передатчика уже установлен Master сокет, который он ищет для подключения нужно включить передатчик и посмотреть на LED после включения и обратить внимание на скорость мигания светодиода:"]
            [new Table("Led signal","Socket state")
                [$"Green to blue cyclic change"][$"Wireless socket is trying to find any receiver to connect"]
                [$"Green to blue quick cyclic change"][$"Wireless socket is trying to find a specific receiver (“MasterSN” property is not empty)"]
            ]
            [$"Если же после включения светодиод начинает плавно моргать каким-либо цветом, значит он уже подключился к приемнику."]    
            [$"For more info see Wireless socket LED signals."]    
        ]

        [new Section("Reset MasterSN property") 
            [$"Power up the wireless socket and press the power button for 5 seconds, after that the wireless socket will be restarted and the “MasterSN” property will be erased."]
        ]

        [new Section($"Pair передатчика и приемника, используя {Software.Antilatency_Service}")
            [$"Ниже описана конфигурация, где приемником выступает {Hardware.SocketUsbRadio}."]
            [new OrderedList()
                [$"Connect the {Hardware.SocketUsbRadio} to the {Terms.Host}"]
                [$"Power up the wireless socket by the single-click power on button"]
                [$"Run {Software.Antilatency_Service} application"]
                [$"Open Device Network tab"]
                [$"Click on the {Hardware.SocketUsbRadio} node in the Device Network tab"]
                [$"Select the “sys/HardwareSerialNumber” property value and press Ctrl+C"]
                [$"Click on the wireless radio socket node in the Device Network tab"]
                [$"Select the “MasterSN” property value, press Ctrl+V, and click on the Set button"]
            ]
        ]

        [new Section($"Pair передатчика и приемника, используя wireless socket's power button")
            [$"Ниже описана конфигурация, где приемником выступает {Hardware.SocketUsbRadio}."]
            [new OrderedList()
                [$"Connect the {Hardware.SocketUsbRadio} to the {Terms.Host}"]
                [$"Power up the wireless socket by the single-click power on button"]
                [$"Check that the wireless socket is connected to the {Hardware.SocketUsbRadio} (both device LEDs will be blinking smoothly with the same color)"]
                [$"Press and hold the power button on the wireless socket for about 5 seconds, after that the wireless socket will be restarted and save the {Hardware.SocketUsbRadio}’s hardware serial number in the “MasterSN” property."]
            ]
        ]

        
    ;
    


}