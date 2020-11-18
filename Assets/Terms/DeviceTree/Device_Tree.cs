using Csml;

partial class Terms : Scope {
    public static LanguageSelector<IMaterial> Device_Tree => new LanguageSelector<IMaterial>();

    public static Image RadioScheme => new Image("./RadioScheme.png");
    public static Image DeviceHierarchy => new Image("./DeviceHierarchy.jpg");
    public static Image DeviceTreeInAntilatencyService => new Image("./DeviceTreeInAntilatencyService.png");
    
}