using Csml;


partial class Tutorials : Scope {
    public static LanguageSelector<IMaterial> Set_Device_Custom_Properties => new LanguageSelector<IMaterial>();
    public partial class Set_Device_Custom_Properties_Assets : Scope {
             public static Image TitleImage => new Image("./TitleImage.jpg"); 

             public static Image EditStep1 = new Image ("./Images/EditStep1.png");
             public static Image EditStep2 = new Image ("./Images/EditStep2.png");
             public static Image EditResult = new Image ("./Images/EditResult.png");

             public static Image addNewStep1 = new Image ("./Images/addNewStep1.png");
             public static Image addNewStep2 = new Image ("./Images/addNewStep2.png");
             public static Image addNewStep3 = new Image ("./Images/addNewStep3.png");
             public static Image addNewResult = new Image ("./Images/addNewResult.png");

             public static Image DeleteStep1 = new Image ("./Images/DeleteStep1.gif");
             public static Image DeleteStep2 = new Image ("./Images/DeleteStep2.png");

               
    }
    }
    