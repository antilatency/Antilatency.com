using Csml;
using static Terms.Antilatency_Hardware_Extension_Interface_Assets;

partial class Terms : Scope {
    static Material Antilatency_Hardware_Extension_Interface_ru => new Material(null, null,
    $"Реализаци доступа к GPIO сокета через UsbTypeC разъём с помощью {Hardware.ExtensionBoard} и {Software.Antilatency_Hardware_Extension_Interface_Library}")
        [Video.GetPlayer()]
        [new Section("Поддерживаемые сокеты")
            [new UnorderedList()
                [$"*{Hardware.SocketUsbRadio}*(hardware version 2.0.0) - режим UsbRadioSocket и RadioSocket."]]]

        [new Section("Схема подключение")
            [$"Используется {Hardware.ExtensionBoard} 2.0.0."]
            [Hardware.ExtensionBoard_Assets.Connection]]

            [$"Сокет подключается к {Hardware.ExtensionBoard} при помощи Usb 3.1 Type-C кабеля, во второй разъём подключается питание с помощью любого Type-C кабеля. {Hardware.ExtensionBoard} позволяет подключать различные кнопки, концевики, потенциометры, светодиоды, вибромоторчики и т.д."]
    ;   


}