using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices; //GuidAttribute

namespace Antilatency.Alt {

    [Guid("8F1BA51F-F6B8-4C4C-B81F-30B3AFBFB4A1")]
    public interface IGeometrySettings : Antilatency.InterfaceContract.IInterface {
        byte[] getData();

        [Documentation.Summary("Head parameters as string")]
        string toString();

        [Documentation.Summary("Head parameters as tab separated key - value string. ${Parameter1Name}\t${Parameter1Value}\n${Parameter2Name}\t${Parameter2Value}\n ...")]
        string toKeyValueString();

        Antilatency.Math.float2 sensorToMiddle(Antilatency.Math.float2 point, float temperature);
        Antilatency.Math.float3 middleToRay(Antilatency.Math.float2 point);
        Antilatency.Math.float2 rayToMiddle(Antilatency.Math.float3 ray);

        Antilatency.Math.float3 gyroscopeSensorToLocal(Antilatency.Math.float3 sensorSpace, float temperature);
        Antilatency.Math.float3 gyroscopeLocalToSensor(Antilatency.Math.float3 localSpace, float temperature);

        Antilatency.Math.float3 accelerometerSensorToLocal(Antilatency.Math.float3 sensorSpace, float temperature);
        Antilatency.Math.float3 accelerometerLocalToSensor(Antilatency.Math.float3 localSpace, float temperature);
    }
}
