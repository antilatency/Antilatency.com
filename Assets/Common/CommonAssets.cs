using Csml;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class Root {
    public partial class Common_Assets : Scope {
        public static IEnumerable<Paragraph> HardwareProducts => 
            ScopeHelper.GetScopePropertiesOfType<Hardware, LanguageSelector<IMaterial>>().Where(x => x.HasTarget).Select(x => new Paragraph($"{x}"));

        public static int CopyrightYear => DateTime.Now.Year;
    }

}