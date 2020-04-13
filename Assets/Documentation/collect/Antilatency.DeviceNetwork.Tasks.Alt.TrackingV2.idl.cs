using System.Runtime.InteropServices; //GuidAttribute
using System;

namespace Antilatency {
    namespace DeviceNetwork {
        namespace Tasks {
            namespace Alt {
                namespace TrackingV2 {
                    public class Constants {
                        public static Guid TaskID = new Guid("be2b5e32-8cd3-48ba-99ce-60669ff08d38");
                    }

                    public struct InertialLeapWithoutMatrices {
                        public float timeLeap;
                        public Antilatency.Math.float3 positionLeap;
                        public Antilatency.Math.float3 velocityLeap;
                        public Antilatency.Math.floatQ rotationLeap;
                    }

                    public struct InertialLeapWithMatrices  {
                        public InertialLeapWithoutMatrices leap;
                        public Antilatency.Math.float3x3 positionByAccelerationCorrection;
                        public Antilatency.Math.float3x3 velocityByAccelerationCorrection;
                    }

                    public struct FrameData {
                        public InertialLeapWithMatrices completeLeap;
                        public Antilatency.Math.float3 nonNormalizedUp;
                    }

                    public struct MidspacePoint {
                        public Antilatency.Math.float2 point;
                        public uint intensity;
                    }

                    [Guid("1651BFB7-D4E6-4ACD-B31F-7978A51011D5")]
                    public interface IHostToDevice : Antilatency.InterfaceContract.IInterface {
                        [PacketId(10), BarrieredByItself]
                        void setExposure([InRef]uint value);

                        [PacketId(11), BarrieredByItself]
                        void setGyroscopeOffset([InRef]uint value);

                        [PacketId(12), BarrieredByItself]
                        void setImageThreshold([InRef]uint value);
                    }

                    [Guid("14AB678C-4FBF-4C69-A19F-612D1359D640")]
                    public interface IDeviceToHost : Antilatency.InterfaceContract.IInterface {

                        [PacketId(1), BarrieredByItself]
                        void fisheyeSphere([InRef]float value);

                        [PacketId(2), BarrieredByItself]
                        void frameStart([InRef]FrameData value);

                        [PacketId(3), BarrieredByItself]
                        void midspacePoint([InRef]MidspacePoint value);

                        [PacketId(4), BarrieredByItself]
                        void incompleteLeap([InRef]InertialLeapWithoutMatrices value);
                    }
                }
            }
        }
    }
}
 