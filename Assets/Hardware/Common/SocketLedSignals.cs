using Csml;
using System;
using System.Collections.Generic;
using System.Drawing;

partial class Hardware : Scope {

    public static LedSignal ErrorLedSignal = new LedSignal($"Constant red light", $"Device error, it will be restarted in a few seconds", $"{new ColorSequence()[Color.Red, 100f]}");
    public static LedSignal FatalLedSignal = new LedSignal($"Red blinking (on/off) for `N` times", $"Hardware error, `N` – error code", $"{new ColorSequence()[Color.Red, 0.3f][Color.Black, 0.3f][Color.Red, 0.3f][Color.Black, 0.3f][Color.Black, 3f]}");

    public static LedSignal SearchLedSignal = new LedSignal($"Green to blue cyclic change", $"Wireless socket is trying to find any receiver to connect", $"{new ColorSequence()[Color.Green, 1f][Color.Blue, 1f]}");
    public static LedSignal ConcreteSearchLedSignal = new LedSignal($"Green to blue quick cyclic change", $"Wireless socket is trying to find a specific receiver (`MasterSN` property is not empty)", $"{new ColorSequence()[Color.Green, 0.5f][Color.Blue, 0.5f][Color.Green, 0.5f][Color.Blue, 0.5f]}");
    public static LedSignal ConnectedLedSignal = new LedSignal($"Smoothly blinking <color>", $"Wireless socket is connected to the receiver. <color> should be identical on both devices.", $"{new ColorSequenceCos(Color.Black, Color.Magenta, 1.8f)}");


    public static List<LedSignal> CommonLedSignals = new List<LedSignal> { ErrorLedSignal, FatalLedSignal };
    public static List<LedSignal> WirelessLedSignals = new List<LedSignal> { SearchLedSignal, ConcreteSearchLedSignal, ConnectedLedSignal };
}