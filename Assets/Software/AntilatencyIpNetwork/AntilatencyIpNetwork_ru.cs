using Csml;
using static Software.AntilatencyIpNetwork_Assets;

partial class Software : Scope {

    public static Material AntilatencyIpNetwork_ru => new Material("AntilatencyIpNetwork", null, $"Кроссплатформенная C++ библиотека с интерфейсом AntilatencyApi, с помощью которой осуществляется обмен данными между устройствами Antilatency в пределах одной локальной сети (LAN).")

        [new Section("API")
            [$"Интерфейс библиотеки для объекта NetworkServer, который может отправлять и получать данные о состоянии устройств, подключённых к той же сети. Например, информацию о положении устройства в пространстве."]
            [$"ILibrary interface produces INetworkServer interface (getNetworkServer method). INetworkServer can “listen” the network to get messages from other devices in LAN (startMessageListening then getDeviceList methods). Also it can send message with data from all connected position trackers (sendStateMessages method)."]
            [$"StateMessage structure represents a tracking data: data source name (32 bytes UTF8 string), Cartesian coordinates (in meters, float), rotation quaternion components (float) and error code. To get fixed size representation of a standard string for the data source name (StateMessage.rawTag) you need to use getRawTagFromString method from ILibrary interface."]
            [ApiDesc]
        ]

        [new Section("Realization details")
            [$"A {new ExternalReference("https://en.wikipedia.org/wiki/User_Datagram_Protocol", "UDP")} socket is used for network exchange. All data is transmitted to an IP address of a {new ExternalReference("https://en.wikipedia.org/wiki/Multicast", "multicast group")}. The device should join the multicast group to receive data."]
            [$"We suggested to use the default multicast group address:"]
            [$"`Antilatency::IpNetwork::Constants::DefaultTargetAddress` - the one from unassigned part 239.255.0.0/16 of local {new ExternalReference("https://tools.ietf.org/html/rfc2365", "Administratively Scoped Multicast Space")}."]
        ]

        [new Section("Example")
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