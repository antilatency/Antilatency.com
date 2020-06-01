using Csml;



partial class Hardware: Scope {
    public static LanguageSelector<IMaterial> Tag => new LanguageSelector<IMaterial>();
    public partial class Tag_Assets : Scope {
        public static Image TagProduct0 => new Image("./TagProduct0.jpg");
    }
}