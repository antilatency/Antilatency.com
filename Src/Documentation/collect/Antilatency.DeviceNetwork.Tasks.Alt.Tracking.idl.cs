using System.Runtime.InteropServices; //GuidAttribute
using System;

namespace Antilatency {
    namespace DeviceNetwork {
        namespace Tasks {
            namespace Alt {
                namespace Tracking {
                    public class Constants {
                        public static Guid TaskID = new Guid("B38EA03E-4DCE-4CB7-8EA8-9389F18A0F90");
                    }

                    [Guid("A4C0C780-BB99-4DE9-B7E5-A783A9E8144B")]
                    public interface IHostToDevice : Antilatency.InterfaceContract.IInterface {
                        [PacketId(9),  BarrieredByItself]
                        void exposure([InRef]uint value);

                        [PacketId(10), BarrieredByItself]
                        void gyroscopeOffset([InRef]uint value);

                        [PacketId(13), BarrieredByItself]
                        void imageThreshold([InRef]byte value);
                    }

                    [Guid("4F33136A-310D-423D-89B8-9FF7F46E51FF")]
                    public interface IDeviceToHost : Antilatency.InterfaceContract.IInterface {
                        [PacketId(1), BarrieredByItself]
                        void frameStart([InRef]ulong time); 

                        [PacketId(2), BarrieredByItself]
                        void opticalPoint([InRef]OpticalPoint value);

                        [PacketId(3), BarrieredByItself]
                        void temperature([InRef]float value);

                        [PacketId(8), BarrieredByItself]
                        void gyroscope([InRef]Antilatency.Math.short3 value); 

                        [PacketId(4), BarrieredByItself]
                        void accelerometer2([InRef]Antilatency.Math.short3 value);

                        [PacketId(5), BarrieredByItself]
                        void accelerometer4([InRef]Antilatency.Math.short3 value);

                        [PacketId(6), BarrieredByItself]
                        void accelerometer8([InRef]Antilatency.Math.short3 value);

                        [PacketId(7), BarrieredByItself]
                        void accelerometer16([InRef]Antilatency.Math.short3 value);
                    }
                }
            }
        }
    }
}
 