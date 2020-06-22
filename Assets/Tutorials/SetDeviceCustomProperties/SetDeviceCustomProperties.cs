using Csml;


partial class Tutorials : Scope {
    public static LanguageSelector<IMaterial> Set_Device_Custom_Properties => new LanguageSelector<IMaterial>();
    public partial class Set_Device_Custom_Properties_Assets : Scope {
             public static Image TitleImage => new Image("./TitleImage.jpg");  
             public static Image SetProperty => new Image("./SetProperty.jpg");   
             public static Image DeviceTreeAS => new Image("./DeviceTreeAS.jpg");  
             public static Image SendSettings => new Image("./SendSettings.jpg");  
    }
    }
    