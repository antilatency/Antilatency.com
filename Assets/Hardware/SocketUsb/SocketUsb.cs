using Csml;

partial class Hardware : Scope {

    public static LanguageSelector<IMaterial> SocketUsb => new LanguageSelector<IMaterial>();

    public partial class SocketUsb_Assets : Scope{

        public static string Dimensions = "9 x 18 x 32";
        public static string Weight = "";

    }

}