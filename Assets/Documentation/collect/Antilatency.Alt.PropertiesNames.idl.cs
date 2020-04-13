namespace Antilatency {
    namespace Alt {
        namespace PropertiesNames {
            public class Constants {
                static string SysPath = "sys/";
                static string BinaryExtension = ".b";
                static string GeometrySettingsPath = SysPath+ "GeometrySettings" + BinaryExtension;
	            static string IntensityCorrectionTablePath = SysPath + "IntensityCorrectionTable" + BinaryExtension;
	            static string FpgaIntensityCorrectionTablePath = SysPath + "FpgaIntensityCorrectionTable"; //No extension. 32 symbols already
                static string MaximumViewAnglePath = SysPath + "MaximumViewAngle" + BinaryExtension;
            }
        }        
    }
}