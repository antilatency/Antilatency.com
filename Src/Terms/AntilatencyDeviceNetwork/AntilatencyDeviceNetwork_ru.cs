using Csml;

public partial class Root {

    public partial class Antilatency_Device_Network : Name<Antilatency_Device_Network> {



        public static Material ru = new Material(Title, null,
        $"Библиотека для комуникации с устройствами Antilatency. Позволяет находить устройства среди подключенных, отслеживать подключение новых устройств, запускать задачи на устройствах, а также обновлять прошивку.")
            
            [new Section("Инициализация")
                [$"Для начала работы с {Reference} нужно загрузить библиотеку и создать экземпляр `ILibrary`"]
            ]

            [new Section("Nodes")
                [@$"При подключении к сети каждое устройство получает идентификатор `NodeHandle`.
                    Идентификаторы не повторяются в процессе работы одного экземпляра сети.
                
                "]
            ]
            [FirmwareUpdateWarning.Reference]
        ;
    }
}