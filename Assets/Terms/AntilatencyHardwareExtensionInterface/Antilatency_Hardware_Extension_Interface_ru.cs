﻿using Csml;
using static Terms.Antilatency_Hardware_Extension_Interface_Assets;

partial class Terms : Scope {
    static Material Antilatency_Hardware_Extension_Interface_ru => new Material(null, null,
    $"Реализаци доступа к GPIO сокета через UsbTypeC разъём с помощью {Hardware.ExtensionBoard} и {Software.Antilatency_Hardware_Extension_Interface_Library}")
        [Video.GetPlayer()]
        [new Section("Поддерживаемые сокеты")
            [new UnorderedList()
                [$"*{Hardware.SocketUsbRadio}*(hardware version 2.0.0) - режим UsbRadioSocket и RadioSocket."]]]

        [new Section("Схема подключение")
            [$"Используется {Hardware.ExtensionBoard} 2.0.0."]
            [Hardware.ExtensionBoard_Assets.Connection]]

            [$"Сокет подключается к {Hardware.ExtensionBoard} при помощи Usb 3.1 Type-C кабеля, во второй разъём подключается питание с помощью любого Type-C кабеля. {Hardware.ExtensionBoard} позволяет подключать различные кнопки, концевики, потенциометры, светодиоды, вибромоторчики и т.д."]

                [new Section("Troubleshooting")
                    [new OrderedList()
                        [@$"{Hardware.ExtensionBoard} не реагирует на команды софта
                            {new UnorderedList()
                                [$"Не вызван {Api.Antilatency.HardwareExtensionInterface.ICotask.Methods.run.FullNameRefCode}"]
                                [$"{Api.Antilatency.HardwareExtensionInterface.ICotask.NameRefCode} запущен не на том сокете."]
                                [$"Для подключения использован неподходящий кабель. Если в описании есть ключевые слова `Usb 2.0`, `480 Mbit/s`, то с очень большой вероятностью, данный кабель не подходит."]
                                [$"Кабель подключен не к той стороне на {Hardware.ExtensionBoard}."]
                            }"]

                        [@$"Сигналы на пинах {Hardware.ExtensionBoard} перепутаны {
                                new UnorderedList()
                                [$"Кабель подключен не той ориентацией."]
                            }"]
                    ]
                ]
                    
    ;   


}