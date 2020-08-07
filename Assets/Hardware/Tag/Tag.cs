using Csml;
using System.Collections.Generic;

partial class Hardware: Scope {

    public static LanguageSelector<IMaterial> Tag => new LanguageSelector<IMaterial>();
    public partial class Tag_Assets : Scope {
        public static Image TagProduct0 => new Image("./TagProduct0.jpg");

        public static string Dimensions = "9 x 18 x 66 mm";
        public static string Weight = "18 g";
        public static string BatteryCapacity = "250 mAh";

        public static LedSignal ChargingLedSignal = new LedSignal(@$"Cyclic 5 second red light – 5 seconds off", $"Socket is charging", $"{new ColorSequence()[System.Drawing.Color.Red, 5f][System.Drawing.Color.Black, 5f]}");
        public static LedSignal ChargedLedSignal = new LedSignal($"Constant green", $"Socket is fully charged", $"{new ColorSequence()[System.Drawing.Color.Green, 100f]}");

        public static List<LedSignal> TagLedSignals = new List<LedSignal> { ChargingLedSignal, ChargedLedSignal };

        public static Table IndicationTable = new Table("Led signal", "Socket state", "Indication")
                    [LedSignal.convert(CommonLedSignals)]
                    [LedSignal.convert(WirelessLedSignals)]
                    [LedSignal.convert(TagLedSignals)];


    }
}