using Csml;


partial class Hardware: Scope {
    public static LanguageSelector<IMaterial> HMD_Radio_Socket => new LanguageSelector<IMaterial>();
    public partial class HMD_Radio_Socket_Assets : Scope {
        public static Image HMD_Radio_SocketProduct0 => new Image("./SocketUsbRadioProduct0.jpg");

        public static string Dimensions = "9 x 18 x 32";
        public static string Weight = "7";
        public static string ThisDevice = "HMD Radio Socket";

        public static Table IndicationTable_ru = new Table("Индикация", "Состояние устройства")
        [LedSignal.convert(RadioSocketLedSignals_ru)]
        [LedSignal.convert(CommonLedSignals_ru)];
        
        public static Table IndicationTable_en = new Table("Indication", "Socket state")
        [LedSignal.convert(RadioSocketLedSignals_en)]
        [LedSignal.convert(CommonLedSignals_en)];

    }
}