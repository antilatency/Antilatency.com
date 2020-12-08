using Csml;
using static Software.AntilatencyIpNetwork_Assets;

partial class Software : Scope {

    public static Material AntilatencyIpNetwork_ru => new Material("AntilatencyIpNetwork", null, $"Кроссплатформенная C++ библиотека с интерфейсом AntilatencyApi, с помощью которой осуществляется обмен данными между устройствами Antilatency в пределах одной локальной сети (LAN).")

        [new Section("API")
            [$"Интерфейс библиотеки для объекта NetworkServer, который может отправлять и получать данные о состоянии устройств, подключённых к той же сети. Например, информацию о положении устройства в пространстве."]

            [$"Интерфейс INetworkServer наследует интерфейс ILibrary. INetworkServer может прослушивать сеть и получать сообщения от других устройств в локальной сети с помощью методов startMessageListening и getDeviceList. Кроме этого, он может отправлять данные о позиции со всех подключенных трекеров, используя метод sendStateMessages."]

            [$"StateMessage содержит в себе имя источника данных (32-байтовая строка UTF8), декартовы координаты (в метрах, с плавающей точкой), компоненты квартерниона вращения (с плавающей точкой) и код ошибки."]
           
            [$"Чтобы узнать фиксированный размер стандартной строки с именем источника данных (StateMessage.rawTag), используйте метод getRawTagFromString интерфейса ILibrary."]
            
            [ApiDesc]
        ]

        [new Section("Детали реализации")

        [$"Socket с {new ExternalReference("https://en.wikipedia.org/wiki/User_Datagram_Protocol", "UDP")} используется для обмена данными по сети. Пакеты данных передаются на IP-адрес мультикастной группы. Поэтому, чтобы получать данные, устройство должно быть частью многоадрессной группы."]

        [$"Мы рекомендуем использовать адрес мультикастной группы, установленный по умолчанию:"]
    
            [$"`Antilatency::IpNetwork::Constants::DefaultTargetAddress` - незарезервированная часть 239.255.0.0/16 локальной {new ExternalReference("https://tools.ietf.org/html/rfc2365", "административно-ограниченной многоадрессной группы")}."]
        ]

        [new Section("Пример")
            [$"Заголовочные файлы:"]
            [ExampleHeaders]
            [$"Загрузка библиотек:"]
            [ExampleLoadLibs]
            [$"Установка NetworkServer:"]
            [ExampleSetupNetworkServer]
            [$"Основной цикл:"]
            [ExampleMainLoop]
        ]

        ;

    

}
