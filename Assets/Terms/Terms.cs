using Csml;

partial class Terms : Scope {

    public static LanguageSelector<IMaterial> Task => new LanguageSelector<IMaterial>();
    public static LanguageSelector<IMaterial> AntilatencyRPiSocket => new LanguageSelector<IMaterial>();
    public static LanguageSelector<IMaterial> Host => new LanguageSelector<IMaterial>();
}