using Csml;
using static Api.Antilatency.DeviceNetwork;

partial class Terms : Scope {
    public static Material Antilatency_Device_Network_ru => new Material(null, null,
    $"Библиотека для коммуникации с устройствами Antilatency. Позволяет находить устройства среди подключенных, отслеживать подключение новых устройств, запускать задачи на устройствах, а также обновлять прошивку.")
        [new Section("Инициализация")
            [$"Для начала работы с {Antilatency_Device_Network} нужно загрузить библиотеку и создать экземпляр {ILibrary.NameRefCode}"]
        ]
    
    ;
    


}