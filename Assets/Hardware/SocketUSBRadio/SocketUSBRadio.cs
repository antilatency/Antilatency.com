using Csml;


partial class Hardware: Scope {
    public static LanguageSelector<IMaterial> SocketUsbRadio => new LanguageSelector<IMaterial>();
    public partial class SocketUsbRadio_Assets : Scope {
        public static Image SocketUsbRadioProduct0 => new Image("./SocketUsbRadioProduct0.jpg");

        public static string Dimensions = "9.1x18.2x32.1";
        public static string Weight = "7.2";
        public static string ThisDevice = "HMD Radio Socket";

        public static Table IndicationTable_ru = new Table("Индикация", "Состояние устройства")
        [LedSignal.convert(RadioSocketLedSignals_ru)]
        [LedSignal.convert(CommonLedSignals_ru)];
        
        public static Table IndicationTable_en = new Table("Indication", "Socket state")
        [LedSignal.convert(RadioSocketLedSignals_en)]
        [LedSignal.convert(CommonLedSignals_en)];

    }
}