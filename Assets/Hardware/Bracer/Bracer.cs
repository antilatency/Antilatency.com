using Csml;



partial class Hardware: Scope {
    public static LanguageSelector<IMaterial> Bracer => new LanguageSelector<IMaterial>();
    public partial class Bracer_Assets : Scope {
        public static Image BracerProduct0 => new Image("./BracerProduct0.jpg");
    }
}