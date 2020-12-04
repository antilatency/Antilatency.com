using Csml;
using static Hardware.ExtensionModule_Assets;

partial class Hardware {

    public static Material ExtensionModule_ru =>
    new Material ("Extension Module", 
    null,
    $" Модуль для подключения к {Hardware.HMD_Radio_Socket} дополнительных компонентов с помощью {Terms.Antilatency_Hardware_Extension_Interface}. Используя модуль, можно считывать внешние триггеры с кнопок или, например, управлять виброоткликом устройства через встроенный вибромоторчик.")

    [$"Чтобы подключить питание к {ThisDevice}, используйте кабель USB Type-C."]

    [$"Для подключения доступно 8 пинов, каждый из которых может работать в режиме входа и выхода. Любые 2 пина могут одновременно работать в режиме подсчёта импульсов. Любые 4 - в режиме ШИМ выхода."]
    [Pinout]
    [PinFunctions]
    [new Warning($"Максимальное напряжение на всех пинах может быть не более 3В.")]
    [new Warning($"IN3 и IN4 - низкоскоростные пины, для которых частота сигнала не должна превышать 10кГц.")]
    [new Warning ($"Ток, потребляемый с пина в режиме Output, не должен превышать 4мA.")]

    [$"`Input` - режим входа с внутренним Pull-Up(≈13 кОм). Каждые 5мс система запрашивает состояние пина. Если оно изменилось, система отправляет данные на хост."]

    [$"`Output` - режим выхода Push-Pull."]

    [$"`PulseCounter` - Плавающий режим входа, в котором подсчитывается количество положительных фронтов сигнала. С его помощью можно подключать другие микросхемы, например, схему ёмкостного датчика."]

    [$"`PWN` - режим выхода ШИМ сигнала (Push-Pull) заданной частоты и скважности, с помощью которого можно управлять яркостью светодиодов, интенсивностью вибрации и т.д. PWN можно использовать для подключения микросхем или как аналоговый выход с помощью RC фильтра."]

    [$"`Analog` - аналоговый режим с разрешением 10 бит."]

    ;
}