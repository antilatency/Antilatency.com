using System.Runtime.InteropServices; //GuidAttribute
using System;

namespace Antilatency
{
    namespace Alt
    {
        namespace Tracking
        {
            [IntegerBehaviour]
            public enum MarkerIndex : uint
            {
                MaximumValidMarkerIndex = 0xFFFFFFF0,
                Invalid = 0xFFFFFFFE,
                Unknown = 0xFFFFFFFF 
            }

			[IntegerBehaviour]
			public enum RayIndex : uint
            {
                Unassigned = 0xFFFFFFFF 
            }

            [Guid("C257C858-F296-43B7-B6B5-C14B9AFB1A13")]
            public interface IEnvironment : Antilatency.InterfaceContract.IInterface {
                bool isMutable();

                Antilatency.Math.float3[] getMarkers();

                bool filterRay(Antilatency.Math.float3 up, Antilatency.Math.float3 ray);

                [Documentation.Parameter("raysUpSpace", "rays directions. Normalized")]
                bool match(Antilatency.Math.float3[] raysUpSpace, [OutRef]MarkerIndex[] markersIndices, [OutRef]Antilatency.Math.floatP3Q poseOfUpSpace);
                //[Obsolete]
                //MarkerIndex[] matchProjections(Antilatency.Math.float2[] projections);

                [Documentation.Summary("Match rays to markers by known position")]
                [Documentation.Parameter("rays", "rays directions world space. Normalized")]
                [Documentation.Parameter("origin", "Common rays origin world space")]
                [Documentation.Returns("Indices of corresponding markers. result.size == rays.size")]
                MarkerIndex[] matchByPosition(Antilatency.Math.float3[] rays, Antilatency.Math.float3 origin);
            }
            
            [Guid("E664544B-AFD5-4723-949A-9A888526EF97")]
            public interface IEnvironmentMutable : Antilatency.InterfaceContract.IInterface
            {
                bool mutate(
                    float[] powers,
                    Antilatency.Math.float3[] rays,                    
                    float sphereD,
                    Antilatency.Math.float2[] x,
                    Antilatency.Math.float2x3[] xOverPosition,
                    Antilatency.Math.float3 up
                    );
                int getUpdateId();
            }


        }
    }
}