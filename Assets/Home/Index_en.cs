using Csml;


public partial class Root {
    
    
    static Material Index_en => new Material("Antilatency", null, $"")
        [Antilatency_Device_Network]
        [Alt]
        ;

    public static MultiLanguageGroup Index => new MultiLanguageGroup();
}