using System.Runtime.InteropServices; //GuidAttribute
using System;

namespace Antilatency.Alt.Tracking {

    public class Constants {
        public static float DefaultAngularVelocityAvgTime = 0.016f;
    }

    [Documentation.Summary("Part of ", typeof(Stability), " structure. Since meaning of Stability.value depends on stage, this meaning described here.")]
    public enum Stage {
        [Documentation.Summary("Tracker collect accelerometer data to find upright orientation. No tracking data is valid in this stage. value = 0")]
        InertialDataInitialization,
        [Documentation.Summary("Only rotation is valid in this stage. Rotation around vertical axis may drift. value = 0")]
        Tracking3Dof,
        [Documentation.Summary("Full 6 dof tracking, corrected by optics. Value represents how stable solution is. "
            , "Since this value depends on many factors, there is no units for it. This value may be used for debug purposes. ")]
        Tracking6Dof,
        [Documentation.Summary("Inertial only 6 dof tracking, without optical corrections. Value is a fraction of time left before switch to Tracking3Dof. "
            , "The value is useful for animation effects to notify the user about the oncoming loss of tracking.")]
        TrackingBlind6Dof, //value - 0..1 fraction of time left
    }

    [Documentation.Summary("Represents stability of tracking")]
    public struct Stability {
        public Stage stage;
        [Documentation.Summary("Meaning of value depends on stage. See ", typeof(Stage))]
        public float value;
    }
    
    public struct State {
        [Documentation.Summary("World space position meters, local to world rotation")]
        public Antilatency.Math.floatP3Q pose;
        [Documentation.Summary("World space, meters per second")]
        public Antilatency.Math.float3 velocity;
        [Documentation.Summary("Local space, radians per second")]
        public Antilatency.Math.float3 localAngularVelocity;
        [Documentation.Summary("Tracking stability")]
        public Stability stability;
    }

    [Guid("009EBFE1-F85C-4638-BE9D-AF7990A8CD04")]
    public interface ITrackingCotaskConstructor : Antilatency.DeviceNetwork.ICotaskConstructor {
        ITrackingCotask startTask(Antilatency.DeviceNetwork.INetwork network, Antilatency.DeviceNetwork.NodeHandle node, IEnvironment environment);
    }

    [Guid("B3032673-093A-47C5-A049-31576DCBE894")]
    public interface ITrackingDataCotaskConstructor : Antilatency.DeviceNetwork.ICotaskConstructor {
        ITrackingDataCotask startTask(
            Antilatency.DeviceNetwork.INetwork network,
            Antilatency.DeviceNetwork.NodeHandle node,
            ITrackingDataCallback callback);
    }

    [Guid("7F8B603C-FA91-4168-92B7-AF1644D087DB")]
    public interface ITrackingCotask : Antilatency.DeviceNetwork.ICotask {
        [Documentation.Parameter("placement", "Position (meters) and orientation (quaternion) of tracker relative to origin of tracked object.")]
        [Documentation.Parameter("deltaTime", "Extrapolation time (seconds).")]
        State getExtrapolatedState(Antilatency.Math.floatP3Q placement, float deltaTime);

        State getState(float angularVelocityAvgTimeInSeconds);
    }

    [Guid("91B0A5BE-A9C7-4D29-A03A-44FFF8E91C68")]
    public interface ITrackingDataCotask : Antilatency.DeviceNetwork.ICotask {

        Antilatency.Math.floatQ getOpticsToBodyRotation();
        void setExposure(uint exposure);
    }

    [Guid("8F2DAB91-8BA5-40A3-AE73-E3F8EF1FB876")]
    public interface ITrackingDataCallback : Antilatency.InterfaceContract.IInterface {

        void onTrackingFrame(
                OpticRay[] rays,
                Math.float3 inertialUp,
                InertialLeap inertialLeap,
                bool accelerometerOverflowOccured,
                bool gyroscopeOverflowOccured);

        void onIncompleteLeap(InertialLeap leap);

        void onAdnFinalize();
    }

    public struct OpticRay {
        public Math.float2 middleSpacePoint;
        public Math.float2x3 middleSpacePointDerivativeByLocalPosition;
        public Math.float3 direction;
        public float power;
    }

    public struct InertialLeap {
        public float timeLeap;
        public Math.float3 positionLeap;
        public Math.float3 velocityLeap;
        public Math.floatQ rotationLeap;
        public Math.float3x3 positionLeapByAcceleration;
        public Math.float3x3 velocityLeapByAcceleration;
    }
}