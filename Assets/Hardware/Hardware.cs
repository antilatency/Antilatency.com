using Csml;

partial class Hardware : Scope {
    public static LanguageSelector<IMaterial> Bracer => new LanguageSelector<IMaterial>();
    public static LanguageSelector<IMaterial> SocketUsb => new LanguageSelector<IMaterial>();
    public static LanguageSelector<IMaterial> SocketUsbRadio => new LanguageSelector<IMaterial>();    
    public static LanguageSelector<IMaterial> PicoG2Socket => new LanguageSelector<IMaterial>();

}