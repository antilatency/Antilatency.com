using Csml;
partial class Tutorials {
    public static Material ConfiguringRadioDevices_ru => new Material("Конфигурация беспроводных устройств",
    ConfiguringRadioDevices_Assets.TitleImage,
    $"В этом материале мы рассмотрим настройку и использование беспроводных устройств Antilatency. Данная настройка позволяет достичь максимальной производительности системы, а также повысить её стабильность. Особенно актуально для многопользовательских сценариев и сложных сетапов.")
        [new Section("Возможные опции")
            [new OrderedList()
                [$"Установить на *приёмнике* максимально возможное количество подключенных передатчиков(`ConnLimit`). Позволяет не тратить время на поиск устройств, тем самым увеличивается пропускная способность и снижается задержка."]
                [$"Установить конкретный канал(`RadioChannel`) на *приёмнике*. Позволяет поставить менее шумный канал или разнести несколько приёмников на разные частоты."]
                [$"Установить маску каналов(`ChannelsMask`) для *передатчика*. Позволяет гораздо быстрее искать нужный приёмник."]
                [$"Установить на приёмнике серийный номер(`MasterSN`) *передатчика*. Позволяет подключаться только к одному заданному приёмнику."]
            ]
            [new Info($"Само по себе свойство `MasterSN` также позволяет в некоторых случаях сократить время подключения устройств даже на большой маске. Так как поиск будет завершён сразу после обнаружения нужного приёмника. Если же это свойство не задано, поиск завершится только после сканирования всех доступных каналов.")]
        ]
        [new Section("Восстановление связи с передатчиком")
            [$"В случае неправильной конфигурации передатчик может не хотеть подключаться. А значит его было бы невозможно настроить. Однако существует способ восстановить связь с устройством."]
            [new UnorderedList()
                [@$"На передатчике установлен *серийный номер*(`MasterSN`) *неизвестного приёмника* или он утерян. Сбросить это свойство можно с помощью {ConfiguringRadioDevices:ResetMaster} "]                    
                [@$"На передатчике установлена *неизвестная маска каналов*(`ChannelsMask`). Для решения этой проблемы необходимо на передатчике установить `92` канал. Данный канал всегда активен для поиска и его невозможно сбросить."]]
        ]
        [new Info($"Сначала необходимо настроить передатчик, и только потом приёмник.")]

        [new Section("Свойства передатчика")
            [new UnorderedList()
                [@$"`MasterSN`
                    Данное свойство нужно, чтобы передатчик подключался только к конкретному приемнику. Получив Serial number приемника, его можно записать в свойство `MasterSN` передатчика, и теперь он будет подключаться только к приемнику с указанным Serial number.
                    Существует 2 способа, чтобы задать данное свойство(с помощью кнопки на сокете {ConfiguringRadioDevices:SetMasterSoft} и с помощью {Terms.AntilatencyService} см. {ConfiguringRadioDevices:SetMasterHard}). По индикации передатчика можно понять установлено это свойство или нет см. {Hardware.Tag:LED signals}. "]

                [$@"`ChannelsMask` 
                    задаёт маску каналов, по которой передатчик будет искать приемник для подключения.  
                    Это строка длиной 141 символ (по количеству доступных каналов) , состоящая из `0` и `1`, где `1` означает, что соответствующий канал будет использован при поиске приемника, а `0` - что канал будет проигнорирован. Первый символ в строке отвечает за последний(140) канал. 
                Маска для каналов по умолчанию выглядит следующим образом: 
                `000000000000000000001000001000000000000000000000100000000000000000000000001000000000000000000000001000000000000000000000000000000000000000000`
                Положение символов `1` в данной маске соответствует списку каналов по умолчанию(42, 66, 92, 114, 120).
                Для удобства существуют alias, которые можно отправлять вместо строковой маски: {new UnorderedList()
                        [$"`full` - для поиска активны все каналы"]
                        [$"`default` - для поиска активны только 5 каналов по умолчанию"]
                        [$"`N` - для поиска активен только канал `N`. Например, для `140` будет установлена маска `100....000`"]}"]
            ]
        ]

        [new Section("Свойства приемника")
            [new ToDo("Ссылка на статью про работу со свойствами.", true)]            
            [new OrderedList()
                [@$"`RadioChannel`
                    Значение по умолчанию `-1` – приемник случайно выберет первый свободный радиоканал из списка: 42 = 2402 MHz, 66 = 2426 MHz, 92 = 2452 MHz, 114 = 2474 MHz, 120 = 2480 MHz.
                    You can set a specific channel in the range of `0 - 140`, that will be used. To know how the channel id is mapped to a radio frequency, см. {Terms.Antilatency_Radio_Protocol:channels}
                "]
                [@$"`ConnLimit`
                    Это максимальное количество передатчиков, которые могу быть подключены к этому приёмнику. Значение `0` полностью отключает радио на устройстве.
                    Если значение больше, чем количество фактически подключённых устройств - часть траффика будет тратиться на поиск новых устройств. Поэтому желательно ставить ровно столько, сколько планируется подключать устройств."]
            ]
        ]

        [new Section("Reset MasterSN property by wireless socket's power button", "ResetMaster") 
            [$"Power up the wireless socket and press the power button for 5 seconds, after that the wireless socket will be restarted and the `MasterSN` property will be erased."]
        ]

        [new Section($"Set MasterSN property by wireless socket's power button", "SetMasterHard")
            [$"Ниже описана конфигурация, где приемником выступает {Hardware.SocketUsbRadio}."]
            [new OrderedList()
                [$"Connect the {Hardware.SocketUsbRadio} to the {Terms.Host}"]
                [$"Power up the wireless socket by the single-click power on button"]
                [$"Check that the wireless socket is connected to the {Hardware.SocketUsbRadio} (both device LEDs will be blinking smoothly with the same color)"]
                [$"Press and hold the power button on the wireless socket for about 5 seconds, after that the wireless socket will be restarted and save the {Hardware.SocketUsbRadio}’s hardware serial number in the `MasterSN` property."]
            ]
        ]

        [new Section($"Set MasterSN property by {Software.AntilatencyService.Material}", "SetMasterSoft")
            [$"Ниже описана конфигурация, где приемником выступает {Hardware.SocketUsbRadio}."]
            [new OrderedList()
                [$"Connect the {Hardware.SocketUsbRadio} to the {Terms.Host}"]
                [$"Power up the wireless socket by the single-click power on button"]
                [$"Run {Software.AntilatencyService.Material} application"]
                [$"Open Device Network tab"]
                [$"Click on the {Hardware.SocketUsbRadio} node in the Device Network tab"]
                [$"Select the `{Api.Antilatency.DeviceNetwork.Interop.Constants.Fields.HardwareSerialNumberKey.Value}` property value and press Ctrl+C"]
                [$"Click on the wireless radio socket node in the Device Network tab"]
                [$"Select the `MasterSN` property value, press Ctrl+V, and click on the Set button"]
            ]
        ]



        
    ;
    


}