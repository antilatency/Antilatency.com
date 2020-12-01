using Csml;
using static Api.Antilatency.DeviceNetwork;

partial class Terms : Scope {
    public static Material Antilatency_Device_Network_ru => new Material(null, null,
    $"Сеть устройств Antilatency, подключённых к одному {Terms.Host}. Коммуникация между устройствами осуществляется с помощью библиотеки {Api.Antilatency.DeviceNetwork.Material}.")

    [$"Графически Antilatency Device Network можно представить в виде {Terms.Device_Tree}, где корневой точкой будет выступать хост."]
    
        [new Section("Библиотека Antilatency Device Network")
        
            [$"Библиотека позволяет находить устройства среди подключенных, отслеживать подключение новых устройств, запускать задачи на устройствах, а также обновлять прошивку."]
            [$"Для начала работы с библиотекой нужно её загрузить и создать экземпляр {ILibrary.NameRefCode}"]
        ]
    
    ;
    
}