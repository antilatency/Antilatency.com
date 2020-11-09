using Csml;
using System;
using System.Collections.Generic;
using System.Drawing;

partial class Hardware : Scope {

    public static LedSignal ErrorLedSignal_ru = new LedSignal($"{new ColorSequence()[Color.Red, 100f]}", $"Ошибка устройства, принудительная перезагрузка через несколько секунд");
    public static LedSignal ErrorLedSignal_en = new LedSignal($"{new ColorSequence()[Color.Red, 100f]}", $"Device error, it will be restarted in a few seconds");

    public static LedSignal FatalLedSignal_ru = new LedSignal($"{new ColorSequence()[Color.Red, 0.3f][Color.Black, 0.3f][Color.Red, 0.3f][Color.Black, 0.3f][Color.Black, 3f]}", $"Аппаратный сбой. Количество красных вспышек означает номер ошибки");
    public static LedSignal FatalLedSignal_en = new LedSignal($"{new ColorSequence()[Color.Red, 0.3f][Color.Black, 0.3f][Color.Red, 0.3f][Color.Black, 0.3f][Color.Black, 3f]}", $"Hardware error, the number of the red blinking is the error code");

   
    public static LedSignal SearchLedSignal_ru = new LedSignal($"{new ColorSequence()[Color.Green, 1f][Color.Blue, 1f]}", $"Беспроводное устройство ищет доступный для подключения приёмник");
    public static LedSignal SearchLedSignal_en = new LedSignal($"{new ColorSequence()[Color.Green, 1f][Color.Blue, 1f]}", $"Wireless socket is trying to find any receiver to connect");
    
    public static LedSignal ConcreteSearchLedSignal_ru = new LedSignal($"{new ColorSequence()[Color.Green, 0.5f][Color.Blue, 0.5f][Color.Green, 0.5f][Color.Blue, 0.5f]}", $"Wireless устройство ищет конкретный приёмник (задано значение для свойства `MasterSN`)");
    public static LedSignal ConcreteSearchLedSignal_en = new LedSignal($"{new ColorSequence()[Color.Green, 0.5f][Color.Blue, 0.5f][Color.Green, 0.5f][Color.Blue, 0.5f]}", $"Wireless socket is trying to find a specific receiver (`MasterSN` property is not empty)");

    public static LedSignal ConnectedLedSignal_ru = new LedSignal($"{new ColorSequenceCos(Color.Black, Color.Magenta, 1.8f)}", $"Беспроводное устройство подключено к приёмнику. Цвет сигнала соответствует каналу подключения, поэтому у пары подключённых устройств цвет будет одинаковый.");
    public static LedSignal ConnectedLedSignal_en = new LedSignal($"{new ColorSequenceCos(Color.Black, Color.Magenta, 1.8f)}", $"Wireless socket is connected to the receiver. <color> should be identical on both devices.");

    public static LedSignal RadioDisabledLedSignal_ru = new LedSignal($"{new ColorSequence()[System.Drawing.Color.Green,0.5f][System.Drawing.Color.Black,0.5f][System.Drawing.Color.Green,0.5f][System.Drawing.Color.Black,0.5f]}",$"Радио отключено. Лимит подключений равен `0`.");
    public static LedSignal RadioDisabledLedSignal_en = new LedSignal($"{new ColorSequence()[System.Drawing.Color.Green,0.5f][System.Drawing.Color.Black,0.5f][System.Drawing.Color.Green,0.5f][System.Drawing.Color.Black,0.5f]}",$"Radio is disabled. Connection limit is `0`.");

    public static LedSignal RadioSocketSearchLedSignal_ru = new LedSignal($"{new ColorSequence()[System.Drawing.Color.Green, 1f][System.Drawing.Color.Blue,1f][System.Drawing.Color.Green, 1f][System.Drawing.Color.Blue,1f]}", $"Устройство ищет свободный радиоканал или заданный для этого устройства радиоканал занят.");
    public static LedSignal RadioSocketSearchLedSignal_en = new LedSignal($"{new ColorSequence()[System.Drawing.Color.Green, 1f][System.Drawing.Color.Blue,1f][System.Drawing.Color.Green, 1f][System.Drawing.Color.Blue,1f]}", $"Searching for a free radio channel or the radio channel is set to a specific value and this channel is occupied by another device");

    public static LedSignal ChannelFoundLedSignal_ru = new LedSignal($"{new ColorSequence()[System.Drawing.Color.Magenta, 0.5f][System.Drawing.Color.Black, 0.5f][System.Drawing.Color.Magenta, 0.5f][System.Drawing.Color.Black, 0.5f]}",$"Устройство заняло радиоканал и ожидает подключения беспроводных устройств. <Цвет индикации> соответствует номеру канала.");
    public static LedSignal ChannelFoundLedSignal_en = new LedSignal($"{new ColorSequence()[System.Drawing.Color.Magenta, 0.5f][System.Drawing.Color.Black, 0.5f][System.Drawing.Color.Magenta, 0.5f][System.Drawing.Color.Black, 0.5f]}",$"Pico G2 Socket found a channel to work with and now waits for wireless sockets. <color> is the channel identification, different channels will have different colors");

    public static LedSignal RadioSocketConnectedLedSignal_ru = new LedSignal($"{new ColorSequenceCos(System.Drawing.Color.Magenta, System.Drawing.Color.Black, 1.8f)}",$"К master устройству подключено как минимум одно беспроводное устройство. <Цвет индикации> одинаковый на паре подключённых устройств.");
    public static LedSignal RadioSocketConnectedLedSignal_en = new LedSignal($"{new ColorSequenceCos(System.Drawing.Color.Magenta, System.Drawing.Color.Black, 1.8f)}",$"Pico G2 Socket has at least one other wireless socket connected to it, <color> will be equal on these devices");

    public static LedSignal BootloaderModeLedSignal_ru = new LedSignal($"{new ColorSequence()[System.Drawing.Color.Red,0.5f][System.Drawing.Color.DarkRed,0.5f][System.Drawing.Color.Red,0.5f][System.Drawing.Color.DarkRed,0.5f]}", $"Устройство в режиме обновления прошивки.");
    public static LedSignal BootloaderModeLedSignal_en = new LedSignal($"{new ColorSequence()[System.Drawing.Color.Red,0.5f][System.Drawing.Color.DarkRed,0.5f][System.Drawing.Color.Red,0.5f][System.Drawing.Color.DarkRed,0.5f]}", $"Device is in the bootloader mode.");

    public static List<LedSignal> RadioSocketLedSignals_ru = new List<LedSignal>(){RadioDisabledLedSignal_ru, RadioSocketSearchLedSignal_ru, ChannelFoundLedSignal_ru, RadioSocketConnectedLedSignal_ru, BootloaderModeLedSignal_ru};
    public static List<LedSignal> RadioSocketLedSignals_en = new List<LedSignal>(){RadioDisabledLedSignal_en, RadioSocketSearchLedSignal_en, ChannelFoundLedSignal_en, RadioSocketConnectedLedSignal_en, BootloaderModeLedSignal_en};


    public static List<LedSignal> CommonLedSignals_ru = new List<LedSignal> { ErrorLedSignal_ru, FatalLedSignal_ru };
    public static List<LedSignal> CommonLedSignals_en = new List<LedSignal> { ErrorLedSignal_en, FatalLedSignal_en };

    public static List<LedSignal> WirelessLedSignals_ru = new List<LedSignal> { SearchLedSignal_ru, ConcreteSearchLedSignal_ru, ConnectedLedSignal_ru };
    public static List<LedSignal> WirelessLedSignals_en = new List<LedSignal> { SearchLedSignal_en, ConcreteSearchLedSignal_en, ConnectedLedSignal_en };
}