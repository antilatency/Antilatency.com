using Csml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


partial class Hardware: Scope {
    public static MultiLanguageGroup ExtensionBoard => new MultiLanguageGroup("Antilatency extension board");
    public partial class ExtensionBoard_Assets : Scope {
        public static Image ExtensionBoard => new Image("Images/ExtensionBoard.png");

        public static Image Input => new Image("Images/Input.png");
        public static Image Output => new Image("Images/Output.png");
        public static Image HighLoadOutput => new Image("Images/HighLoadOutput.png");
        public static Image Analog => new Image("Images/Analog.png");

        public static Table PinFunctions => new Table("Pin", "Input", "Output", "PulseCounter", "Analog")
                [$"IO_1"][$"+"][$"+"][$"+"][$"-"]
                [$"IO_2"][$"+"][$"+"][$"+"][$"-"]
                [$"IOA_3"][$"+"][$"+"][$"+"][$"+"]
                [$"IOA_4"][$"+"][$"+"][$"+"][$"+"]
                [$"IO_5"][$"+"][$"+"][$"+"][$"-"]
                [$"IO_6"][$"+"][$"+"][$"+"][$"-"]
                [$"IO_7"][$"+"][$"+"][$"+"][$"-"]
                [$"IO_8"][$"+"][$"+"][$"+"][$"-"];
    }
}