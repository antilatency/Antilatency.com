using Csml;
using static Api.Antilatency.HardwareExtensionInterface;
using System.Linq;

partial class Software : Scope {
    public static LanguageSelector<IMaterial> Antilatency_Hardware_Extension_Interface_Library => new LanguageSelector<IMaterial>();
    public partial class Antilatency_Hardware_Extension_Interface_Library_Assets : Scope {

        public static class Modes {
            public static string Init = "*Init*";
            public static string Run = "*Run*";
        }

        public static Collection createPinMethods = new Collection()[
            typeof(ICotask.Methods)
            .GetNestedTypes()
            .Where(x => x.Name.StartsWith("create") && x.Name.EndsWith("Pin"))
            .Select(x => x.GetProperty("NameRefCode").GetValue(null) as IElement)
            ];
    }
}