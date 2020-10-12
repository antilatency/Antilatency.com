using Csml;

public partial class Software : Scope {
    public partial class AntilatencyService : Scope {
        public partial class Device_Network : Scope {
            public static LanguageSelector<IMaterial> Material => new LanguageSelector<IMaterial>();
        }
    }
}