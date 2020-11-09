using Csml;
using System.Collections.Generic;

partial class Hardware: Scope {
    public static LanguageSelector<IMaterial> Bracer => new LanguageSelector<IMaterial>();
    public partial class Bracer_Assets : Scope {
        
        public static Image BracerProduct0 => new Image("./BracerProduct0.jpg");

        public static string Dimensions = "111х38х32.6";
        public static string Weight = "35";
        public static string BatteryCapacity = "250mAh";
        public static string ThisDevice = "Bracer";

        public static LedSignal ChargingLedSignal_ru = new LedSignal(@$"{new ColorSequence()[System.Drawing.Color.Green, 1f][System.Drawing.Color.Black, 1f][System.Drawing.Color.Green, 1f][System.Drawing.Color.Black, 1f]}",$"Устройство заряжается");
        public static LedSignal ChargingLedSignal_en = new LedSignal(@$"{new ColorSequence()[System.Drawing.Color.Green, 1f][System.Drawing.Color.Black, 1f][System.Drawing.Color.Green, 1f][System.Drawing.Color.Black, 1f]}",$"The device is charging");

        public static LedSignal ChargedLedSignal_ru = new LedSignal($"{new ColorSequence()[System.Drawing.Color.Green, 100f]}", $"Устройство полностью заряжено");
        public static LedSignal ChargedLedSignal_en = new LedSignal($"{new ColorSequence()[System.Drawing.Color.Green, 100f]}", $"The device is fully charged");

        public static List<LedSignal> BracerLedSignals_ru = new List<LedSignal>{ChargingLedSignal_ru, ChargedLedSignal_ru};
        public static List<LedSignal> BracerLedSignals_en = new List<LedSignal>{ChargingLedSignal_en, ChargedLedSignal_en};

        public static Table IndicationTable_ru = new Table("Индикация", "Состояние устройства")
                        [LedSignal.convert(BracerLedSignals_ru)]
                        [LedSignal.convert(WirelessLedSignals_ru)]
                        [LedSignal.convert(CommonLedSignals_ru)];
        
        public static Table IndicationTable_en = new Table("Indication","Bracer state")
                        [LedSignal.convert(BracerLedSignals_en)]
                        [LedSignal.convert(WirelessLedSignals_en)]
                        [LedSignal.convert(CommonLedSignals_en)];
    
    }
}