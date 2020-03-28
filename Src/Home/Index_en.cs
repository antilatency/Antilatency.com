using Csml;


public partial class Root {
    
    
    Material Index_en => new Material("Antilatency", null, $"")
        [Antilatency_Device_Network]
        [Alt]
        ;

    MultiLanguageGroup Index => new MultiLanguageGroup();
}