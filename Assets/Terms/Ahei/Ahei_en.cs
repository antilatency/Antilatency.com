using Csml;

partial class Terms : Scope {
    static Material Ahei_en => new Material("Antilatency hardware extension interface", null,
    $"Accessing the GPIO of a socket through a USB type C connector with {Hardware.ExtensionBoard} and {Software.Ahei}")
        [new Section("Currently supported")
            [new UnorderedList()
                [$"*{Hardware.SocketUsbRadio}*(hardware version 2.0.0) - UsbRadioSocket and RadioSocket modes."]]]

        [new Section("Connection")
            [$"{Hardware.ExtensionBoard} 2.0.0 is used."]
            [Ahei_Assets.Connection]]

        [new UnorderedList()
            [$"Connect the socket to {Hardware.ExtensionBoard} using a USB 3.1 Type-C cable(3.1 is important as all 4 differential pairs are needed for it to work). It is necessary to connect the socket and the extension board with the same orientation of the connectors to prevent crossing the signal lines. There are cables which already have a crossover of signal lines inside. You need to connect such cables the other way around, that is, upside down."]
            [$"Connect {Hardware.ExtensionBoard} to a power supply with a Type-C cable."]]

        [$"*Todo info* The extension board is not symmetrical, You should connect the board from the right side. The power connector is placed below the blue connectors (see the scheme above)."]
    ;   


}