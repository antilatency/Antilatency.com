using Csml;
using static Terms.Antilatency_Hardware_Extension_Interface_Assets;
using static Hardware.ExtensionBoard_Assets;

partial class Terms : Scope {
    static Material Antilatency_Hardware_Extension_Interface_ru => new Material(null, null,
    $"Вы можете управлять внешними устройствами, используя GPIO {Hardware.HMD_Radio_Socket}. Получить доступ к GPIO можно с помощью {Hardware.ExtensionBoard} и {Software.Antilatency_Hardware_Extension_Interface_Library}.")
    

            [new Section("Схема подключения платы","")
            [Hardware.ExtensionBoard_Assets.Connection]]
            [$"\nЧтобы подключить питание, используйте кабель `USB Type-C`. \nЧтобы подключить Socket, используйте `USB 3.1 Type-C`."]
            [new Info($"Обратите внимание на ориентацию коннекторов. При подключении Socket к плате сигнальные линии не должны перекрещиваться.")]
        
        
            [new ToDo("move to troubleshooting", true)]
               /* move : troubleshooting 
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
                ]*/
                    
    ;   


}