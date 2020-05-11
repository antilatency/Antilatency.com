using Csml;

partial class Store : Scope {

    public static LanguageSelector<IMaterial> PresetEditor => new LanguageSelector<IMaterial>();


    public static Material PresetEditor_en => new Material("Store", null, $"Welcome to Antilatency store!")[new PresetEditor()];



}