using System.Runtime.InteropServices; //GuidAttribute
using System;

namespace Antilatency {
    namespace DeviceNetwork {
        namespace Tasks {
            namespace Alt {
                namespace Calibration {
                    public class Constants {
                        public static Guid TaskID = new Guid("d54bdb73-b17a-4c41-86ff-63c0b3aba5bd");
                    }

                    public struct OpticalPoint {
						public ulong xNumerator;
						public ulong yNumerator;
						public ulong xSquareNumerator;
						public ulong ySquareNumerator;
						public uint denominator;
						public float temperature;
					}

					public struct AccumulatedImuSample {
						public Antilatency.Math.long3 value;
						public float temperature;
						public uint count;
					}

                    [Guid("D2E59751-B6B5-4B1A-9E3B-BD073B9AE8ED")]
                    public interface IHostToDevice : Antilatency.InterfaceContract.IInterface {
                        [PacketId(1), BarrieredByItself]
                        void exposure([InRef]uint rows);

                        [PacketId(2), BarrieredByItself]
                        void captureOpticalPoint([InRef]uint framesCount);

                        [PacketId(3), BarrieredByItself]
                        void captureAccelerometer([InRef]uint framesCount);

                        [PacketId(4), BarrieredByItself]
                        void captureGyroscope([InRef]uint framesCount);

                        [PacketId(5), BarrieredByItself]
                        void beginCaptureGyroscope();

                        [PacketId(6), BarrieredByItself]
                        void endCaptureGyroscope();

                        [PacketId(10), BarrieredByItself]
                        void captureImage();

                        [PacketId(12), BarrieredByItself]
                        void imageThreshold([InRef]byte value);
                    }

                    [Guid("5170E2A4-73D3-4988-8472-993BA61BBBB6")]
                    public interface IDeviceToHost : Antilatency.InterfaceContract.IInterface {
                        [PacketId(1), BarrieredByItself]
                        void temperature([InRef]float value);

                        [PacketId(2), BarrieredByItself]
                        void opticalPoint([InRef]OpticalPoint value);

                        [PacketId(3), BarrieredByItself]
                        void frameEnd();

                        [PacketId(4), BarrieredByItself]
                        void accelerometer([InRef]AccumulatedImuSample value);

                        [PacketId(5), BarrieredByItself]
                        void gyroscope([InRef]AccumulatedImuSample value);

                        [PacketId(6), BarrieredByItself]
                        void gyroscopeBeginCapture();

                        [PacketId(7), BarrieredByItself]
                        void gyroscopeEndCapture([InRef]AccumulatedImuSample value);

                        [PacketId(10), BarrieredByItself]
                        void imageDataFull([InRef]Interop.BigPacket.FullBlock value);

                        [PacketId(11), BarrieredByItself]
                        void imageDataPartial([InRef]Interop.BigPacket.PartialBlock value);

                        [PacketId(18), BarrieredByItself]
                        void debugString([InRef]Antilatency.DeviceNetwork.Tasks.Alt.DebugString block);
                    }
                }
            }
        }
    }
}
 
 