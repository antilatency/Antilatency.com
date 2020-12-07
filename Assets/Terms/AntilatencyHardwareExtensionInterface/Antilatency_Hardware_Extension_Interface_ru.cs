using Csml;
using static Terms.Antilatency_Hardware_Extension_Interface_Assets;

partial class Terms : Scope {
    static Material Antilatency_Hardware_Extension_Interface_ru => new Material(null, null,
    $"Интерфейс для управления внешними устройствами через GPIO {Hardware.HMD_Radio_Socket}. С его помощью можно, например, считывать внешние триггеры или управлять яркостью светодиодов. ")

        [$"Чтобы получить доступ к GPIO, используйте {Hardware.ExtensionBoard} или {Hardware.ExtensionModule} и библиотеку {Software.Antilatency_Hardware_Extension_Interface_Library}. На основе этой технологии можно собрать контроллер в виде любого предмета, существующего в реальном мире."]

        [$"Мы в Antilatency разработали демонстрационную модель огнетушителя. Её корпус в точности повторяет размеры настоящего огнетушителя. Нажмите на рычаг устройства в реальном мире - оно заработает в виртуальном, создавая единство визуальных и тактильных ощущений."]

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