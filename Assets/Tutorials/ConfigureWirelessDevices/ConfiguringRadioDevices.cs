using Csml;

partial class Tutorials {
    public static LanguageSelector<IMaterial> ConfiguringRadioDevices => new LanguageSelector<IMaterial>();

    public partial class ConfiguringRadioDevices_Assets : Scope {
            public static Image TitleImage => new Image("./TitleImage.jpg");   

    }
    
}