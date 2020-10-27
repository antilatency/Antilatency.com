using Csml;
using System;
using System.Collections.Generic;
using System.Drawing;

partial class Hardware : Scope {

    public static LedSignal ErrorLedSignal_ru = new LedSignal($"{new ColorSequence()[Color.Red, 100f]}", $"Ошибка устройства, принудительная перезагрузка через несколько секунд");
    public static LedSignal ErrorLedSignal_en = new LedSignal($"{new ColorSequence()[Color.Red, 100f]}", $"Device error, it will be restarted in a few seconds");

    public static LedSignal FatalLedSignal_ru = new LedSignal($"{new ColorSequence()[Color.Red, 0.3f][Color.Black, 0.3f][Color.Red, 0.3f][Color.Black, 0.3f][Color.Black, 3f]}", $"Аппаратный сбой, количество красных вспышек означает номер ошибки");
    public static LedSignal FatalLedSignal_en = new LedSignal($"{new ColorSequence()[Color.Red, 0.3f][Color.Black, 0.3f][Color.Red, 0.3f][Color.Black, 0.3f][Color.Black, 3f]}", $"Hardware error, the number of the red blinking is the error code");

   
    public static LedSignal SearchLedSignal_ru = new LedSignal($"{new ColorSequence()[Color.Green, 1f][Color.Blue, 1f]}", $"Wireless устройство пытается найти доступный для подключения приёмник");
    public static LedSignal SearchLedSignal_en = new LedSignal($"{new ColorSequence()[Color.Green, 1f][Color.Blue, 1f]}", $"Wireless socket is trying to find any receiver to connect");
    
    public static LedSignal ConcreteSearchLedSignal_ru = new LedSignal($"{new ColorSequence()[Color.Green, 0.5f][Color.Blue, 0.5f][Color.Green, 0.5f][Color.Blue, 0.5f]}", $"Wireless устройство ищет конкретный приёмник (задано значение для свойства `MasterSN`)");
    public static LedSignal ConcreteSearchLedSignal_en = new LedSignal($"{new ColorSequence()[Color.Green, 0.5f][Color.Blue, 0.5f][Color.Green, 0.5f][Color.Blue, 0.5f]}", $"Wireless socket is trying to find a specific receiver (`MasterSN` property is not empty)");

    public static LedSignal ConnectedLedSignal_ru = new LedSignal($"{new ColorSequenceCos(Color.Black, Color.Magenta, 1.8f)}", $"Wireless устройство подключено к приёмнику. Цвет сигнала одинаковый на обоих подключённых устройствах.");
    public static LedSignal ConnectedLedSignal_en = new LedSignal($"{new ColorSequenceCos(Color.Black, Color.Magenta, 1.8f)}", $"Wireless socket is connected to the receiver. <color> should be identical on both devices.");


    public static List<LedSignal> CommonLedSignals_ru = new List<LedSignal> { ErrorLedSignal_ru, FatalLedSignal_ru };
    public static List<LedSignal> CommonLedSignals_en = new List<LedSignal> { ErrorLedSignal_en, FatalLedSignal_en };

    public static List<LedSignal> WirelessLedSignals_ru = new List<LedSignal> { SearchLedSignal_ru, ConcreteSearchLedSignal_ru, ConnectedLedSignal_ru };
    public static List<LedSignal> WirelessLedSignals_en = new List<LedSignal> { SearchLedSignal_en, ConcreteSearchLedSignal_en, ConnectedLedSignal_en };
}