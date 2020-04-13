using System.Runtime.InteropServices; //GuidAttribute
using System;

namespace Antilatency {
    namespace DeviceNetwork {
        namespace Tasks {
            namespace Alt {
                
                public struct OpticalPoint {
                    public uint intensity;
                    public float x;
                    public float y;
                }

                //TODO: move to ADN?
                public struct DebugString {
                    public Interop.Memory.Memory64 data;
                }
            }
        }
    }
}
