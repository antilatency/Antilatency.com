using Csml;

public partial class Terms : Scope{

    public static LanguageSelector<IMaterial> Environment => new LanguageSelector<IMaterial>();

    public partial class Environment_Assets : Scope{
        public static Image DisplayFeatures => new Image("./Images/DisplayFeatures.gif");
    }
    
}