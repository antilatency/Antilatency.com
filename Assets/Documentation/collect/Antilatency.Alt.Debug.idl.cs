using System.Runtime.InteropServices; //GuidAttribute
using System;
namespace Antilatency
{
    namespace Alt
    {

       /* public struct ImagePoint {
            public float x;
            public float y;
            public float r;
        }

        public enum FpgaConfigType : uint {
            PixelThreshold,
			BrightnessTableItem
        };

        public struct FpgaConfig {
            public FpgaConfigType type;
            public uint address;
            public uint value;
        };

        public struct FpgaSettings {
            public byte pixelThreshold;
        }


        [Guid("c657c3a2-d82c-446c-9a32-07b757fc8604")]
        public interface DebugTaskID : Antilatency.InterfaceContract.IUnsafe { }

    */
        

        namespace Debug {
            [Guid("D32CC4D7-E933-4CA7-8CE7-BC9AA9355570")]
            public interface ICotaskConstructor : Antilatency.DeviceNetwork.ICotaskConstructor {
                ICotask startTask(Antilatency.DeviceNetwork.INetwork network, Antilatency.DeviceNetwork.NodeHandle node);
            }

            [Guid("CCC0A06E-C39E-41E2-A7C1-5B58B865031D")]
            public interface ICotask : Antilatency.DeviceNetwork.ICotask {
                void setExposureRows(UInt32 rows);
                uint getExposureRows();
                float rowsToMilliseconds();
                uint readConfig(Antilatency.DeviceNetwork.Tasks.Alt.Debug.ConfigType type, uint address);
                void writeConfig(Antilatency.DeviceNetwork.Tasks.Alt.Debug.Config settings);
                IImage captureImage();
                Antilatency.DeviceNetwork.Tasks.Alt.OpticalPoint[] capturePoints();
            }
        }

        

        [Guid("5CC8C296-0DFC-49AE-93AC-3AE7C5A230DF")]
        public interface IImage : Antilatency.InterfaceContract.IInterface
        {
            byte[] getPixels(); //getWidth()*getHeight() pixels
            UInt16 getX(); //0 if full image
            UInt16 getY(); //0 if full image
            UInt16 getWidth(); //640 if full image
            UInt16 getHeight(); //480 if full image
        }
    }

}
