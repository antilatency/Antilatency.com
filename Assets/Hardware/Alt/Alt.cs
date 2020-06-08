using Csml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


partial class Hardware: Scope {

    public static LanguageSelector<IMaterial> Alt => new LanguageSelector<IMaterial>();

    static Image AltAndUsbSocket0 => new Image("./AltAndUsbSocket0.jpg");
    static Image AltAndUsbSocket1 => new Image("./AltAndUsbSocket1.jpg");
    static Image AltAndUsbSocket2 => new Image("./AltAndUsbSocket2.jpg");




}

/*
public sealed partial class Api : Scope<Api>{

    public sealed partial class Antilatency : Scope<Antilatency> {

        public sealed partial class Tracking : Scope<Tracking> {
            public static MultiLanguageGroup _Material => new MultiLanguageGroup("Antilatency.Tracking");
            public static Material _Material_en => new Material(_Material.Title, null, $"Namespace");

            public sealed partial class ILibrary : Scope<ILibrary> {
                public static MultiLanguageGroup _Material => new MultiLanguageGroup("Antilatency.Tracking.ILibrary");//TODO: user defined title
                private static Material _Material_en => new Material(_Material.Title, null, $"");

                public sealed partial class createEnvironment : Scope<createEnvironment> {
                    public static MultiLanguageGroup _Material => new MultiLanguageGroup("Antilatency.\u200BTracking.\u200BILibrary.\u200BcreateEnvironment");//TODO: user defined title
                    private static Material _Material_en => new Material(_Material.Title, null, $"Method");
                }
            }
        }
    }
}

partial class Api {
    partial class Antilatency {
        partial class Tracking {
            partial class ILibrary {
                partial class createEnvironment { 
                
                }
            }
        }
    }
}*/
