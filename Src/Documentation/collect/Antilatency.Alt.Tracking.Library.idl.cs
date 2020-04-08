using System.Runtime.InteropServices; //GuidAttribute

namespace Antilatency.Alt.Tracking {

    [Guid("13AC393D-A7C5-4E51-A6EB-FEAA11C3C049")]
    public interface ILibrary : Antilatency.InterfaceContract.IInterface {

        IEnvironment createEnvironment(string code);

        Math.floatP3Q createPlacement(string code);

        string encodePlacement(Math.float3 position, Math.float3 rotation);

        ITrackingCotaskConstructor createTrackingCotaskConstructor();

        ITrackingDataCotaskConstructor createTrackingDataCotaskConstructor();
    }
}