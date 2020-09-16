using Csml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


partial class Tutorials: Scope {
    public static LanguageSelector<IMaterial> SocketReferenceDesignDeploying => new LanguageSelector<IMaterial>();
    public partial class SocketReferenceDesignDeploying_Assets : Scope {
        public static Image AltMount1 => new Image("Images/AltMount1.jpg");
        public static Image AltMount2 => new Image("Images/AltMount2.jpg");
    }
}