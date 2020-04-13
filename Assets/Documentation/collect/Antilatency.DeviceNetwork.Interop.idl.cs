using System;
using System.Runtime.InteropServices; //GuidAttribute

namespace Antilatency {
    namespace DeviceNetwork{
        namespace Interop {

            public class Constants {
                public string SoftwareNameKey = "sys/SoftwareName";
                public string SoftwareVersionKey = "sys/SoftwareVersion";
                public string HardwareNameKey = "sys/HardwareName";
                public string HardwareVersionKey = "sys/HardwareVersion";                
                public string HardwareSerialNumberKey = "sys/HardwareSerialNumber";
            }

            namespace Memory {
                public struct Memory2 {
                    public byte m0;
                    public byte m1;
                }
                public struct Memory4 {
                    public Memory2 m0;
                    public Memory2 m1;
                }
                public struct Memory8 {
                    public Memory4 m0;
                    public Memory4 m1;
                }
                public struct Memory16 {
                    public Memory8 m0;
                    public Memory8 m1;
                }
                public struct Memory32 {
                    public Memory16 m0;
                    public Memory16 m1;
                }
                public struct Memory62 {
                    public Memory32 m0;
                    public Memory16 m1;
                    public Memory8 m2;
                    public Memory4 m3;
                    public Memory2 m5;
                }
                public struct Memory63 {
                    public Memory32 m0;
                    public Memory16 m1;
                    public Memory8 m2;
                    public Memory4 m3;
                    public Memory2 m5;
                    public byte m6;
                }

                public struct Memory64 {
                    public Memory32 m0;
                    public Memory32 m1;
                }

                public struct Memory128
                {
                    public Memory64 m0;
                    public Memory64 m1;
                }

                public struct Memory255
                {
                    public Memory128 m0;
                    public Memory64 m1;
                    public Memory63 m2;
                }
            }

            public struct String16 {
                public Memory.Memory16 data;
            }

            namespace BigPacket {
                public struct FullBlock {
                    public Memory.Memory63 payload;
                }

                public struct PartialBlock {
                    public byte payloadSize;
                    public Memory.Memory63 payload;
                }
            }


            class WriteBufferOverflowException : Exception {}


            [Documentation.Summary("Task stream packet.")]
            public struct Packet {
                [Documentation.Summary("Packet ID")]
                public byte id;
                [Documentation.Summary("Pointer to packet data.")]
                public ConstPtr data;
                [Documentation.Summary("Packet data size.")]
                public uint size;
            }

            public struct PacketDescription {
                public byte id;
                public byte size;
                public uint barrierFor;
            }

            [Guid("76C77B7E-5BAE-4C3A-88E6-40795557103F")]
            public interface ITaskSignature : Antilatency.InterfaceContract.IInterface {
                Guid getGuid();

                //uint getWritePacketDescriptionsCount();
                PacketDescription getWritePacketDescription(uint index);

                //uint getReadPacketDescriptionsCount();
                PacketDescription getReadPacketDescription(uint index);
            }

            [Guid("D86EF57E-603E-4D3D-9FFE-B145ABD9C0AA")]
            [Documentation.Summary("Data receiver")]
            public interface IDataReceiver : Antilatency.InterfaceContract.IInterface {
                [Documentation.Summary("Write packet to data receiver")]
                [Documentation.Parameter("packet", "Packet with data")]
                void packet(Packet packet);
            }

            [Guid("D1761312-D6EB-41F6-9733-9388D7906238")]
            public interface IConnection : IDataReceiver {
                void setDataReceiver(IDataReceiver dataReceiver);
            }

        }
    }
}