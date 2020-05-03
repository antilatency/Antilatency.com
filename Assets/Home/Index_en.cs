using Csml;


public partial class Root {
    
    
    static Material Index_en => new Material("Antilatency", null, $"");

    public static LanguageSelector<IMaterial> Index => new LanguageSelector<IMaterial>();
}