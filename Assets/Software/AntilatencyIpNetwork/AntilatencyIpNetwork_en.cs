using Csml;
using static Software.AntilatencyIpNetwork_Assets;

partial class Software : Scope {

    public static Material AntilatencyIpNetwork_en => new Material("AntilatencyIpNetwork", null, $"AntilatencyIpNetwork is a cross-platform C++ library with AntilatencyApi interface. The main purpose is to exchange position data from Antilatency Trackers ({Hardware.Alt}) between devices, in the same local network (LAN). It supports Windows, Linux (desktop and Raspberry Pi) and Android OS.")

        [new Section("API")
            [$"Library interface build around NetworkServer object. NetworkServer can send and receive states (positions, errors, GPIO etc) of network devices in the same multicast group."]
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
            [$"Headers:"]
            [ExampleHeaders]
            [$"Load libraries:"]
            [ExampleLoadLibs]
            [$"Setup NetworkServer:"]
            [ExampleSetupNetworkServer]
            [$"Main loop:"]
            [ExampleMainLoop]
        ]

        ;

    

}