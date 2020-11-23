using System.Collections.Generic;
using Csml;



partial class Hardware: Scope {
    public static LanguageSelector<IMaterial> PicoG2Socket => new LanguageSelector<IMaterial>();
    public partial class PicoG2Socket_Assets : Scope {
        public static Image PicoG2SocketProduct0 => new Image("./PicoG2SocketProduct0.jpg");

        public static string Dimensions = "44 × 21 × 36 ";
        public static string Weight = "12";
        public static string ThisDevice = "PicoG2Socket";

        public static LedSignal ExternalUsbLedSignal_ru = new LedSignal($"{new ColorSequence()[System.Drawing.Color.Green,0.3f][System.Drawing.Color.Black,2.5f][System.Drawing.Color.Green,0.3f][System.Drawing.Color.Black,2.5f]}",$"Подключёно внешнее питание через USB. Передача данных и отслеживание трекинга не доступно.");
        public static LedSignal ExternalUsbLedSignal_en = new LedSignal($"{new ColorSequence()[System.Drawing.Color.Green,0.3f][System.Drawing.Color.Black,2.5f][System.Drawing.Color.Green,0.3f][System.Drawing.Color.Black,2.5f]}",$"External USB cable connected. Radio and tracker is turned off");

        public static List<LedSignal> PicoG2SocketLedIndication_ru = new List<LedSignal>{ExternalUsbLedSignal_en};
        public static List<LedSignal> PicoG2SocketLedIndication_en = new List<LedSignal>{ExternalUsbLedSignal_en};

        public static Table IndicationTable_ru = new Table("Индикация", "Состояние устройства")
            [LedSignal.convert(RadioSocketLedSignals_ru)]
            [LedSignal.convert(PicoG2SocketLedIndication_ru)]
            [LedSignal.convert(CommonLedSignals_ru)];
        
        public static Table IndicationTable_en = new Table("Indication", "Socket state")
            [LedSignal.convert(RadioSocketLedSignals_en)]
            [LedSignal.convert(PicoG2SocketLedIndication_en)]
            [LedSignal.convert(CommonLedSignals_en)];
    }
}