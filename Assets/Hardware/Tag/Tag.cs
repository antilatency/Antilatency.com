using Csml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


partial class Hardware: Scope {
    public static LanguageSelector<IMaterial> Tag => new LanguageSelector<IMaterial>();
    public partial class Tag_Assets : Scope {
        public static Image TagProduct0 => new Image("./TagProduct0.jpg");
    }
}