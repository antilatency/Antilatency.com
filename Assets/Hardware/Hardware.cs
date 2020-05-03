using Csml;

partial class Hardware : Scope {
    public static LanguageSelector<IMaterial> Tag => new LanguageSelector<IMaterial>();
    public static LanguageSelector<IMaterial> Bracer => new LanguageSelector<IMaterial>();
    public static LanguageSelector<IMaterial> Socket => new LanguageSelector<IMaterial>();
    public static LanguageSelector<IMaterial> SocketUsbRadio => new LanguageSelector<IMaterial>();    
}