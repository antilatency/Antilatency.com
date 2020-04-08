using System;
using System.Runtime.InteropServices; //GuidAttribute

namespace Antilatency.DeviceNetwork {

    [Guid("9ECFA909-D13C-4C29-A87E-8925B7846638")]
    public interface ICotaskConstructor : Antilatency.InterfaceContract.IInterface {
        bool isSupported(INetwork network, NodeHandle node);
        NodeHandle[] findSupportedNodes(INetwork network);
    }

    [Guid("FD95F649-562A-4819-A816-26B76CD9D8D6")]
    public interface ICotask : Antilatency.InterfaceContract.IInterface {
        bool isTaskFinished();
    }
}