using Csml;

partial class Hardware : Scope {

    public static Material ExtensionBoard_ru =>

        new Material(
            "Antilatency Extension Board",
            ExtensionBoard_Assets.ExtensionBoard,
        $"Плата для удобного использования {Terms.Antilatency_Hardware_Extension_Interface}")
        [new Section("Pinout")
            [$"Всего для подключения доступны 8 пинов, среди которых каждый может быть в режиме входа(*Input*) или выхода(*Output*). Любые 2 среди всех пинов могут быть в режиме подсчета импульсов(*PulseCounter*). И только 2 определённых пина могут быть в аналоговом режиме(*Analog*)."]
            [ExtensionBoard_Assets.PinFunctions]
            [new Warning()[$"Максимальное напряжение на всех пинах(в том числе и аналоговых) не более 3В."]]
            [new Warning()[$"IOA_3 и IOA_4 - низкоскоростные пины.(Частота сигнала не должна превышать 10kHz)"]]]
       
        [new Section("Input")
            [$"Режим входа с внутренним Pull-Up(≈13 kOhm). Каждые 5мс опрашивается состояние пина, и если оно изменилось - отправляется на хост."]
            [$"Типичная схема подключение кнопки: "]
            [ExtensionBoard_Assets.Input]]
        
        [new Section("Output")
            [$"Режим выхода Push-Pull."]
            [new Info()[$"Ток, потребляемый с пина, не должен превышать 4mA."]]
            [$"Типичная схема подключения светодиода:"]
            [ExtensionBoard_Assets.Output]
            [$"Если нужно управлять более мощной нагрузкой - можно использовать схему:"]
            [ExtensionBoard_Assets.HighLoadOutput]]
        
        [new Section("PulseCounter")
            [$"Режим входа floating(без подтяжек)."]
            [$"Считает количество положительных фронтов сигнала(переход из Low в High → rising edge). Предназначен для подключения других микросхем, например, схема ёмкостного датчика."]]
        
        [new Section("Analog")
            [$"Режим аналогового входа. Разрешение 10 бит."]
            [$"Типичная схема подключения потенциометра:"]
            [ExtensionBoard_Assets.Analog]
            [new Info()[$"Резистор R3 обеспечивает ограничение напряжение на пине IOA. Напряжение должно быть в диапазоне 0-3 В."]]]
            ;
}