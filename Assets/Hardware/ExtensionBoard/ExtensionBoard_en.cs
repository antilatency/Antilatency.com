using Csml;

partial class Hardware : Scope {

    public static Material ExtensionBoard_en =>

        new Material(
            "Antilatency Extension Board",
            ExtensionBoard_Assets.TitleImage,
        $"Pcb for easy using {Terms.Antilatency_Hardware_Extension_Interface}")
        [new Section("Pinout")
            [$"There are 8 pins available for the connection, each of them can operate in input or output mode. Any 2 among the pins can be set to pulse counting mode (*PulseCounter*). Only 2 specific pins can be set to analog mode (*Analog*)."]
            [ExtensionBoard_Assets.PinFunctions]
            [new Warning()[$"The maximum voltage on all pins (including the analog ones) is 3V."]]
            [new Warning()[$"IOA_3 and IOA_4 are low-speed pins. (The signal frequency should not exceed 10kHz)"]]]
       
        [new Section("Input")
            [$"An input mode with internal pull-up (≈13 kOhm). The state of the pin is updated every 5ms, and if it has changed, it is sent to the host."]
            [$"Button connection schematic: "]
            [ExtensionBoard_Assets.Input]]
        
        [new Section("Output")
            [$"Push-pull output mode."]
            [new Info()[$"The current consumption from the pin must not exceed 4mA."]]
            [$"LED connection schematic:"]
            [ExtensionBoard_Assets.Output]
            [$"If you need to manage a more powerful load, you can use the following schematic:"]
            [ExtensionBoard_Assets.HighLoadOutput]]
        
        [new Section("PulseCounter")
            [$"Input mode: floating (without pullup/pulldown)."]
            [$"It counts the number of rising edges of the signal (a change in level from Low to High) and is designed to connect other circuits e.g. a capacitive sensor circuit."]]

        [new Section("Analog")
            [$"Analog input mode. Resolution: 10 bit."]
            [$"Potentiometer connection schematic:"]
            [ExtensionBoard_Assets.Analog]
            [new Info()[$"An R3 resistor provides a voltage limitation on the IOA pin. The voltage should be in the range of 0-3 V."]]]
            ;
}