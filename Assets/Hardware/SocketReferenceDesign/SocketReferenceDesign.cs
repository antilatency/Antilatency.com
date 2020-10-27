using Csml;

public partial class Hardware : Scope {

    public static LanguageSelector<IMaterial> SocketReferenceDesign => new LanguageSelector<IMaterial>();
        public static Image TopView => new Image("Images/TopView.png");
    
}