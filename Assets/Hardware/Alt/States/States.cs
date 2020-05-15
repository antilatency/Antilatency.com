using Csml;

partial class Hardware : Scope {
    partial class AltDescription : Scope {
        public static LanguageSelector<IMaterial> ColorCodes => new LanguageSelector<IMaterial>();
    }
}