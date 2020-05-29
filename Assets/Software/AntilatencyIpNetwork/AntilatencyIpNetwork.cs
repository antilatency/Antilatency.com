using Csml;

partial class Software : Scope {
    public static LanguageSelector<IMaterial> AntilatencyIpNetwork => new LanguageSelector<IMaterial>();

    public partial class AntilatencyIpNetwork_Assets : Scope {
        


        public static Code ApiDesc => new Code(
            @"namespace Antilatency.IpNetwork {

    [Documentation.Summary(""Library constants"")]
    public class Constants
        {
            public int MajorVersion = 1;
            public int MinorVersion = 1;
            public int PatchVersion = 0;
            public string DefaultIfaceAddress = ""0.0.0.0"";
            public string DefaultTargetAddress = ""239.255.111.2"";
            public int DefaultTrackingPort = 56789;
            public int DefaultCommandPort = 8889;
        }

        [Documentation.Summary(""CommandName:CommandValue pair interface"")]
        public enum CommandKey : byte
        {
            None = 0,
            Custom,
            SetEnvinromentCode,
            SetSendingRate,
        }

        [Guid(""F413ABA1-5C2F-41F1-B1B0-7309676A6C4A"")]
        [Documentation.Summary(""CommandName:CommandValue pair interface"")]
        public interface ICommandMessage : Antilatency.InterfaceContract.IInterface
        {
            string id();
            string ipAddress();
            string error();
            long timeStamp();
            CommandKey key();
            string value();
        }


        [Guid(""2C31F909-8B65-48B8-838F-E7EC389AAA29"")]
        [Documentation.Summary(""Command queue"")]
        public interface IConstCommandList : Antilatency.InterfaceContract.IInterface
        {
            uint size();
            ICommandMessage get(uint index);
        }

        [Documentation.Summary(""Standard error codes"")]
        public enum ErrorType : byte
        {
            None = 0,
            Unknown,
            AdnLibraryLoad,
            AltTrackingLibraryLoad,
            TrackingNodeNotFound,
            TrackingNodeNotReady,
            CotaskConstructor,
            TrackingTaskRestartMessage,
            TrakingCotaskConstructFailed,
            AltEnvironmentArbitrary2D,
            ReadTagProperty,
            ReadSerialNumber,
            StartTrackingTaskFailed,
            GetTrackerStateFailed,
            SetupGpio,
        }

        [Documentation.Summary(""UTF8 32 bytes length string representation"")]
        public struct RawString32
        {
            public Antilatency.InterfaceContract.Memory.Memory32 data;
        }

        [Documentation.Summary(""Fixed size structure for tracking information"")]
        public struct StateMessage
        {
            public RawString32 rawTag;
            public float positionX;
            public float positionY;
            public float positionZ;
            public float rotationX;
            public float rotationY;
            public float rotationZ;
            public float rotationW;
            public ErrorType trackerError;
        }

        public struct GpioPinState
        {
            int number;
            int value;
        }

        [Guid(""CC3466E2-1D33-4564-8754-476D9D53C3D2"")]
        [Documentation.Summary(""Network enabled device information"")]
        public interface IDeviceState : Antilatency.InterfaceContract.IInterface
        {
            string id();
            string sessionId();
            string ipAddress();
            string deviceError();
            bool newState();
            long packetNumber();
            long timeStamp();
            long latency();
            GpioPinState[] gpioState();
            StateMessage[] lastStates();
        }

        [Guid(""259DB783-92F1-4F4D-BD35-05355423332F"")]
        [Documentation.Summary(""All devices in network"")]
        public interface IConstDeviceList : Antilatency.InterfaceContract.IInterface
        {
            uint size();
            IDeviceState get(uint index);
        }

        [Guid(""95416322-9E28-49DC-8850-1665AB4B081E"")]
        [Documentation.Summary(""Network exchange implementer"")]
        public interface INetworkServer : Antilatency.InterfaceContract.IInterface
        {
            void sendStateMessages(StateMessage[] stateMessages, GpioPinState[] gpioPins, string deviceError);
            void sendCommand(CommandKey command, string value);

            void startMessageListening();
            void startCommandListening();

            IConstDeviceList getDeviceList();
            IConstCommandList getCommands();
        }

        [Guid(""96B0C448-6AE2-4361-AA16-A670033D644A"")]
        [Documentation.Summary(""Main library interface"")]
        public interface ILibrary : Antilatency.InterfaceContract.IInterface
        {
            INetworkServer getNetworkServer(
                                string serverId,
                                string ifaceAddress,
                                string targetAddress,
                                int trackingPort,
                                int commandPort
                                );

            long getCurrentTime();

            string getTagFromRawTag(RawString32 rawString);
            RawString32 getRawTagFromString(string tag);

            string getVersion();
        }

    }"
            , ProgrammingLanguage.CSharp
        );



        public static Code ExampleHeaders => new Code(
            @"#include <vector>
#include <thread>
#include <chrono>
#include <iostream>
#include <Antilatency.Api.h>
#include <AntilatencyLibraryLoader/Antilatency.InterfaceContract.LibraryLoader.h>

int main(int argc, char *argv[]) {"
            , ProgrammingLanguage.Cpp
        );



        public static Code ExampleLoadLibs => new Code(
            @"#ifdef __linux__
        Antilatency::IpNetwork::ILibrary netServiceLibrary = Antilatency::InterfaceContract::getLibraryInterface
                <Antilatency::IpNetwork::ILibrary>(""/opt/antilatency/lib/libAntilatencyIpNetwork.so"");
#elif defined(_WIN32)
        Antilatency::IpNetwork::ILibrary netServiceLibrary = Antilatency::InterfaceContract::getLibraryInterface
                <Antilatency::IpNetwork::ILibrary>(""AntilatencyIpNetwork"");
#endif"
            , ProgrammingLanguage.Cpp
        );



        public static Code ExampleSetupNetworkServer => new Code(
            @"Antilatency::IpNetwork::INetworkServer netServer 
    = netServiceLibrary.getNetworkServer(
        ""MAC_ADDR"",
        Antilatency::IpNetwork::Constants::DefaultIfaceAddress,
        Antilatency::IpNetwork::Constants::DefaultTargetAddress,
        Antilatency::IpNetwork::Constants::DefaultTrackingPort
        );

        netServer.startMessageListening();
netServer.startCommandListening();"
            , ProgrammingLanguage.Cpp
        );



        public static Code ExampleMainLoop => new Code(
            @"while (true) {
    std::this_thread::sleep_for(std::chrono::milliseconds(16));
    
    std::vector<Antilatency::IpNetwork::StateMessage> messages{};
    Antilatency::IpNetwork::StateMessage emptyMessage{};
    messages.push_back(emptyMessage);
    
    std::vector<Antilatency::IpNetwork::GpioPinState> pins{{25, 1}};
   
    netServer.sendStateMessages(messages, pins, "");
    
    auto providers = netServer.getDeviceList();
    size_t size = providers.size();
    for (std::size_t index = 0; index < size; index++) {
        auto provider = providers.get(index);
        std::cout << ""id: "" << provider.id()
                  << ""; ip: "" << provider.ipAddress()
                  << ""; c_time: "" << netServiceLibrary.getCurrentTime()
                  << ""; error: "" << provider.deviceError();
                  << std::endl;
    }

    auto commands = netServer.getCommands();
    for (std::size_t index = 0; index<commands.size(); index++) {
        auto command = commands.get(index);
    std::cout << ""id: "" << command.id()
                  << ""; ip: "" << command.ipAddress()
                  << ""; c_time: "" << netServiceLibrary.getCurrentTime()
                  << ""; error: "" << command.error()
                  << ""; r_time: "" << command.timeStamp()
                  << ""; key: "" << Antilatency::enumToString(command.key())
                  << ""; value: "" << command.value()
                  << std::endl;
    }
}

return 0;
} //end of main()"
            , ProgrammingLanguage.Cpp
        );



    }
}