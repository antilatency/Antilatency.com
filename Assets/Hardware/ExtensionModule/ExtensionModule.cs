using Csml;

partial class Hardware : Scope {

    public static LanguageSelector<IMaterial> ExtensionModule => new LanguageSelector<IMaterial>();

    public partial class ExtensionModule_Assets : Scope {

        public static string ThisDevice = "Extension Module";
        public static string TitleImage = "";

        public static string Dimensions = "";
        public static Image Pinout = new Image("./Images/ExtBoardInfo.jpg");

        public static Table PinFunctions => new Table("Pin", "Input", "Output", "PulseCounter", "PWM", "Analog")
                [$"IN 1"]   [$"+"][$"+"][$"+"][$"+"][$"-"]
                [$"IN 2"]   [$"+"][$"+"][$"+"][$"+"][$"-"]
                [$"IN 3"]   [$"+"][$"+"][$"+"][$"+"][$"+"]
                [$"IN 4"]   [$"+"][$"+"][$"+"][$"+"][$"+"]
                [$"IN 5"]   [$"+"][$"+"][$"+"][$"+"][$"-"]
                [$"IN 6"]   [$"+"][$"+"][$"+"][$"+"][$"-"]
                [$"IN 7"]   [$"+"][$"+"][$"+"][$"+"][$"-"]
                [$"IN 8"]   [$"+"][$"+"][$"+"][$"+"][$"-"];

    }

}