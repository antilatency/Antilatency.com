using Csml;


partial class Tutorials : Scope {
    public static LanguageSelector<IMaterial> Alt_HMD_Placement => new LanguageSelector<IMaterial>();
    public partial class Alt_HMD_Placement_Assets : Scope {
        public static Image TitleImage => new Image("./Images/TitleImage.jpg");

        public static Image CreateCustomPlacement => new Image ("./Images/CreateCustomPlacement.gif");
        public static Image CreateCustomPlacement2 => new Image("./Images/CreateCustomPlacement2.png");
        public static Image SetPlacement => new Image("./Images/SetPlacement.png");
        
        
        public static Image ASPlacement => new Image("./Images/ASPlacement.png");
        public static Image ASSelect => new Image("./Images/ASSelect.png");
        public static Image Axises => new Image("./Images/Axises.png");
        public static Image CorrectPlacementScene => new Image("./Images/CorrectPlacementScene.png");
        public static Image IncorrectPlacementScene => new Image("./Images/IncorrectPlacementScene.png");
        public static Image OculusGoPlacement => new Image("./Images/OculusGoPlacement.jpg");
        public static Image OculusQuestPlacement => new Image("./Images/OculusQuestPlacement.jpg");
        public static Image OculusRiftPlacement => new Image("./Images/OculusRiftPlacement.jpg");
        public static Image OculusRiftS => new Image("./Images/OculusRiftS.jpg");
        public static Image PicoG2Placement => new Image("./Images/PicoG2Placement.jpg");
        public static Image ViveProPlacement => new Image("./Images/ViveProPlacement.jpg");
        public static Image PicoG2Socket => new Image("./Images/PicoG2Socket.jpg");    
        
        }
    }
    