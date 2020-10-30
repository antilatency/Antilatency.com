using Csml;
using System.Collections.Generic;

partial class Hardware: Scope {

    public static LanguageSelector<IMaterial> Tag => new LanguageSelector<IMaterial>();
    public partial class Tag_Assets : Scope {
        public static Image TagProduct0 => new Image("./TagProduct0.jpg");

        public static string Dimensions = "9 x 18 x 66";
        public static string Weight = "18";
        public static string BatteryCapacity = "250 mAh";
        public static string ThisDevice = "Tag";

        public static LedSignal ChargingLedSignal_ru = new LedSignal(@$"{new ColorSequence()[System.Drawing.Color.Red, 5f][System.Drawing.Color.Black, 5f]}", $"Устройство заряжается");
        public static LedSignal ChargingLedSignal_en = new LedSignal(@$"{new ColorSequence()[System.Drawing.Color.Red, 5f][System.Drawing.Color.Black, 5f]}", $"Socket is charging");

        public static LedSignal ChargedLedSignal_ru = new LedSignal($"{new ColorSequence()[System.Drawing.Color.Green, 100f]}", $"Устройство полностью заряжено");
        public static LedSignal ChargedLedSignal_en = new LedSignal($"{new ColorSequence()[System.Drawing.Color.Green, 100f]}", $"Socket is fully charged");

        public static List<LedSignal> TagLedSignals_ru = new List<LedSignal> { ChargingLedSignal_ru, ChargedLedSignal_ru };
        public static List<LedSignal> TagLedSignals_en = new List<LedSignal> { ChargingLedSignal_en, ChargedLedSignal_en };

        public static Table IndicationTable_ru = new Table("Индикация","Состояние устройства")
                    [LedSignal.convert(CommonLedSignals_ru)]
                    [LedSignal.convert(WirelessLedSignals_ru)]
                    [LedSignal.convert(TagLedSignals_ru)];

        public static Table IndicationTable_en = new Table("Indication","Socket state")
                    [LedSignal.convert(CommonLedSignals_en)]
                    [LedSignal.convert(WirelessLedSignals_en)]
                    [LedSignal.convert(TagLedSignals_en)];

    }
}