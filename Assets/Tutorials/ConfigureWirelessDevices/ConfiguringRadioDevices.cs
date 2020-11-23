using Csml;
using System.Collections.Generic;

partial class Tutorials {
    public static LanguageSelector<IMaterial> ConfiguringRadioDevices => new LanguageSelector<IMaterial>();

    public partial class ConfiguringRadioDevices_Assets : Scope {
            public static Image TitleImage => new Image("./TitleImage.jpg");   

            public static Image accessPointSN = new Image("./AccessPointSerialNumber.png");

            public static Table SearchIndicationTable_ru = new Table("Индикация","Состояние устройства")
                    [Hardware.LedSignal.convert(Hardware.SearchSignals_ru)];

    }
    
}