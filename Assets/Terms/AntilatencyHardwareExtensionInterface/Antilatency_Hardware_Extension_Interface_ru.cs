using Csml;
using static Terms.Antilatency_Hardware_Extension_Interface_Assets;

partial class Terms : Scope {
    static Material Antilatency_Hardware_Extension_Interface_ru => new Material(null, null,
    $"Вы можете управлять внешними устройствами, используя GPIO {Hardware.HMD_Radio_Socket}. С помощью технологии Hardware Extension можно создать контроллер в виде любого предмета, существующего в реальном мире.")

        [$"Получить доступ к GPIO можно с помощью {Software.Antilatency_Hardware_Extension_Interface_Library} и {Hardware.ExtensionBoard} или {Hardware.ExtensionModule}."]

        [$"Мы в Antilatency разработали демонстрационную модель огнетушителя. Её корпус в точности повторяет размеры настоящего огнетушителя. Нажмите на рычаг устройства в реальном мире - оно заработает в виртуальном. Потрясающее сочетание тактильного и визуального восприятия."]

        [Video.GetPlayer()]
        
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