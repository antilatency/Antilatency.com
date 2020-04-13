using System.Runtime.InteropServices; //GuidAttribute
using System;

namespace Antilatency {
    namespace DeviceNetwork {
        namespace Tasks {
            namespace Alt {
                namespace Debug {
                    public class Constants {
                        public static Guid TaskID = new Guid("2AD83E54-9F90-4C8F-9E40-34231CB5F898");
                    }

                    public enum ConfigType : int {
                        FpgaPixelThreshold,
                        FpgaBrightnessTableItem,
                        ImuAccelerometerRange,
                        CameraRegister,
                        CameraExposure,
                        CameraExposurePulseLength,
                        CameraExposurePulseOffset
                    }

                    public struct Config {
                        public ConfigType type;
                        public uint address;
                        public uint value;
                    }

                    [Guid("5AA0953F-DB1A-4FF3-B2C6-4B6AD769CD2E")]
                    public interface IHostToDevice : Antilatency.InterfaceContract.IInterface {
                        [PacketId(1), BarrieredByItself]
                        void setImageStreamEnabled([InRef]bool enabled);

                        [PacketId(2), BarrieredByItself]
                        void setPointStreamEnabled([InRef]bool enabled);

                        [PacketId(3), BarrieredByItself]
                        void setImuStreamEnabled([InRef]bool enabled);

                        [PacketId(4), BarrieredByItself]
                        void config([InRef]Config config);

                        [PacketId(5), BarrieredByItself]
                        void requestConfig([InRef]Config config);

                        [PacketId(12), BarrieredByItself]
                        void captureImage();

                        [PacketId(13), BarrieredByItself]
                        void capturePoints();

                        [PacketId(17), BarrieredByItself]
                        void capturePointsData();

                        [PacketId(19), BarrieredByItself]
                        void deleteFile([InRef]Antilatency.DeviceNetwork.Interop.String16 name);
                    }

                    [Guid("C7149641-4EA3-48CB-AF5F-5DAF73C1E89F")]
                    public interface IDeviceToHost : Antilatency.InterfaceContract.IInterface {

                        [PacketId(4), BarrieredByItself]
                        void config([InRef]Config value);

                        [PacketId(8), BarrieredByItself]
                        void imageDataFull([InRef]Interop.BigPacket.FullBlock value);

                        [PacketId(9), BarrieredByItself]
                        void imageDataPartial([InRef]Interop.BigPacket.PartialBlock value);

                        [PacketId(10), BarrieredByItself]
                        void opticalPoint([InRef]OpticalPoint value);

                        [PacketId(11), BarrieredByItself]
                        void frameEnd();

                        [PacketId(15), BarrieredByItself]
                        void opticalPointsDataFull([InRef]Interop.BigPacket.FullBlock value);

                        [PacketId(16), BarrieredByItself]
                        void opticalPointsDataPartial([InRef]Interop.BigPacket.PartialBlock value);

                        [PacketId(22), BarrieredByItself]
                        void accelerometer2G([InRef]Antilatency.Math.short3 value);

                        [PacketId(23), BarrieredByItself]
                        void gyroscope([InRef]Antilatency.Math.short3 value);

                        [PacketId(24), BarrieredByItself]
                        void temperature([InRef]float value);

                        [PacketId(25), BarrieredByItself]
                        void accelerometer4G([InRef]Antilatency.Math.short3 value);

                        [PacketId(26), BarrieredByItself]
                        void accelerometer8G([InRef]Antilatency.Math.short3 value);

                        [PacketId(27), BarrieredByItself]
                        void accelerometer16G([InRef]Antilatency.Math.short3 value);

                        [PacketId(29), BarrieredByItself]
                        void debugString([InRef]DebugString value);
                    }
                }
            }
        }
    }
}
