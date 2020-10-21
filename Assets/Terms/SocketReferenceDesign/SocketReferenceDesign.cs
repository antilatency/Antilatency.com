using Csml;

partial class Terms {

    public static LanguageSelector<IMaterial> SocketReferenceDesign => new LanguageSelector<IMaterial>();
    public partial class SocketReferenceDesignDeploying_Assets : Scope {
        public static Image TopView => new Image("Images/TopView.png");
    }
}