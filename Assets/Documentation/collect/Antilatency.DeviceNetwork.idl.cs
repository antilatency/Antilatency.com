using System;
using System.Runtime.InteropServices; //GuidAttribute

namespace Antilatency {
    namespace DeviceNetwork{
        [Documentation.Summary("Antilatency Device Network predefined constants.")]
        public class Constants {
            /*[Documentation.Summary("Root device in Antilatency Device Network hierarchy, any socket node connected directly by USB to PC, smartphone or HMD, will have RootNode as its parent.")]
            public int RootNode = 0;
            [Documentation.Summary("Predefined constant value for invalid node.")]
            public int InvalidNode = -1;*/
        }
        
        [Documentation.Summary("Handle to Antilatency Device Network device. Every time device is connected, the unique handle will be applied to it, so, when device disconnects, NodeStatus for its node becomes Invalid, after reconnection this devices receives new NodeHandle.")]
        public enum NodeHandle : int {
            [Documentation.Summary("Any socket node connected directly by USB to PC, smartphone or HMD, will have Null as its parent.")]
            Null
        }

        public enum UsbVendorId : ushort
        {
            Antilatency = 0x0301
        }

        [Documentation.Summary("Defines different node conditions.")]
        public enum NodeStatus : int {
            [Documentation.Summary("Node in connected and no task is currently running on it. Any supported task can be started on it.")]
            Idle = 0,
            [Documentation.Summary("Node in connected and some task is currently running on it. Before running any task on such node, you need to stop current task firstly.")]
            TaskRunning,
            [Documentation.Summary("Node in not valid, no tasks can be executed on it.")]
            Invalid
        }
        
        [Documentation.Summary("Antilatency Device Network log verbosity level.")]
        public enum LogLevel : int {
            Trace = 0,
            Debug,
            Info,
            Warning,
            Error,
            Critical,
            Off
        }

        [Documentation.Summary("USB device identifier.")]
        public struct UsbDeviceType {
            [Documentation.Summary("USB device vendor ID. Default value for Antilatency devices is 0x0301")]
            public UsbVendorId vid;
            [Documentation.Summary("USB device product ID. Default value for Antilatency Sockets is 0x0000")]
            public ushort pid;
        }
        
        [Guid("af7402e8-2a23-442b-8230-d41f55ef5dc0")]
        [Documentation.Summary("Synchronous task read/write stream.")]
        public interface ISynchronousConnection : Antilatency.InterfaceContract.IInterface {
            [Documentation.Summary("Get received packets. Blocks until any packets received or task finished.")]
			[Documentation.Returns("Received packets array. Zero packets count if task is finished.")]
            Antilatency.DeviceNetwork.Interop.Packet[] getPackets();
            [Documentation.Summary("Get received packets.")]
			[Documentation.Parameter("taskFinished", "Is task finished.")]
			[Documentation.Returns("Received packets array. Zero packets count if no packets received.")]
            Antilatency.DeviceNetwork.Interop.Packet[] getAvailablePackets([OutRef] bool taskFinished);

            bool writePacket(Antilatency.DeviceNetwork.Interop.Packet packet);
        }

        [Guid("4cb2369c-7a66-4e85-9a0c-dbc89fc1c75e")]
        [Documentation.Summary("Network of Nodes")]
        public interface INetwork : Antilatency.InterfaceContract.IInterface {
            [Documentation.Summary("Every time any supported device is connected or disconnected, update ID will be incremented. You can use this method to check if there are any changes in ADN.")]
			[Documentation.Returns("Current factory update ID.")]
            uint getUpdateId();
            
            [Documentation.Summary("Get USB device types selected to work with this factory instance.")]
			[Documentation.Returns("Array of USB device identifiers which this factory instance is working with.")]
            UsbDeviceType[] getDeviceTypes();
            
            [Documentation.Summary("Get all currently connected nodes.")]
            NodeHandle[] getNodes();
            
            [Documentation.Summary("Get current NodeStatus for node.")]
			[Documentation.Parameter("node", "Node handle to get status of.")]
            NodeStatus nodeGetStatus(NodeHandle node);
            
            [Documentation.Summary("Checks if task is supported by node.")]
			[Documentation.Parameter("node", "Node handle.")]
			[Documentation.Parameter("taskId", "Task ID.")]
			[Documentation.Returns("True if node supports such task, otherwise false.")]
            bool nodeIsTaskSupported(NodeHandle node, Guid taskId);
            
            [Documentation.Summary("Get parent for node, in case of USB node this method will return Antilatency.DeviceNetwork.Constants.RootNode")]
			[Documentation.Parameter("node", "Node handle.")]
            NodeHandle nodeGetParent(NodeHandle node);
            
            [Documentation.Summary("Physical address path to first level device that contains this node in network tree.")]
			[Documentation.Parameter("node", "Node handle.")]
			[Documentation.Returns("String represents physical path to first level device (connected via USB).")]
            string nodeGetPhysicalPath(NodeHandle node);
            
            [Documentation.Summary("Run task on node with asynchronous packet receive API.")]
			[Documentation.Parameter("node", "Node handle to start task on.")]
			[Documentation.Parameter("taskId", "Task ID.")]
			[Documentation.Parameter("readCallback", "Packet received callback. Method will be invoked from internal RX thread.")]
            Antilatency.DeviceNetwork.Interop.IDataReceiver nodeStartTask(NodeHandle node, Guid taskId, Antilatency.DeviceNetwork.Interop.IDataReceiver taskDataReceiver);
            
            [Documentation.Summary("Run task on node with synchronous packet receive API.")]
			[Documentation.Parameter("node", "Node handle to start task on.")]
			[Documentation.Parameter("taskId", "Task ID.")]
            ISynchronousConnection nodeStartTask2(NodeHandle node, Guid taskId);
            
			string nodeGetStringProperty(NodeHandle node, string key);

            byte[] nodeGetBinaryProperty(NodeHandle node, string key);

            //IPropertyCotask nodeStartPropertyTask(NodeHandle node);
        }

        [Guid("36219fe8-3ad9-4b70-8c47-a032fe0b5c10")]
        [Documentation.Summary("Antilatency Device Network library entry point.")]
        public interface ILibrary : Antilatency.InterfaceContract.IInterface {
            [Documentation.Summary("Create Antilatency Device Network factory object")]
			[Documentation.Parameter("deviceTypes", "Array of USB device identifiers which will be used by factory.")]
            INetwork createNetwork(UsbDeviceType[] deviceTypes);
            [Documentation.Summary("Get Antilatency Device Network library version.")]
            string getVersion();
            [Documentation.Summary("Set Antilatency Device Network log verbosity level")]
            void setLogLevel(LogLevel level);
        }
    }
}