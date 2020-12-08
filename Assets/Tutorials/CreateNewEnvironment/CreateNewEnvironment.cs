using Csml;

partial class Tutorials : Scope {

    public static LanguageSelector<IMaterial> Create_New_Environment => new LanguageSelector<IMaterial>();
    
    public partial class Create_New_Environment_Assets : Scope {

        public static Image CreateNewEnvironment => new Image("./Images/NewEnvironment.gif");
        public static Image CreateNewEnvironment1 => new Image ("./Images/NewEnvironment1.png");
        public static Image CreateNewEnvironment2 => new Image ("./Images/NewEnvironment2.png");
        public static Image CreateNewEnvironment3 => new Image ("./Images/NewEnvironment3.png");
        public static Image AddBars => new Image("./Images/EnvironmentAddingBars.gif");
        public static Image LockBars => new Image("./Images/EnvironmentLockBars.gif");
        public static Image OptTracking => new Image("./Images/OptTracking.gif");
        public static Image OptFeatures => new Image("./Images/OptFeatures.gif");
    }
}