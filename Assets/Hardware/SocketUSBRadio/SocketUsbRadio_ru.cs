using Csml;
using static Hardware.SocketUsbRadio_Assets;

partial class Hardware : Scope {

    public static Material SocketUsbRadio_ru => new Material(
            "HMD Radio Socket",
            SocketUsbRadio_Assets.SocketUsbRadioProduct0,
             $"HMD Radio Socket - это беспроводной {Terms.Socket}, который поддерживает два режима работы: приём данных от беспроводных устройств по {Terms.Antilatency_Radio_Protocol} и передачу данных трекинга.")



              [new Section("Функциональные особенности","")
                [new UnorderedList()

                    [@$"*Универсальный приёмник*
                    HMD Radio Socket может работать как приёмник данных от других беспроводных устройств. В таком случае Socket подключается через разъём USB type-C, который используется как для питания, так и для передачи данных на {Terms.Host}."]
                    [@$"*Передатчик данных
                    HMD Radio Socket может работать как передатчик данных по радиопротоколу. Питание в таком случае устройство получает от внешней батареи."]
                    [@$"*Внешняя батарея*
                    К HMD Radio Socket через порт USB type-C можно подключить внешний источник питания. В таком случае устройство будет работать как передатчик, аналогично, к примеру, {Hardware.Tag}."]
                    [@$"*Поддержка Extension board*
                    {Hardware.ExtensionBoard} подключается к HMD Radio Socket через порт USB type-C для передачи данных о внешних триггерах и управлением откликом, к примеру, вибрацией. HMD Radio Socket передает эти данные вместе с данными трекинга своему приемнику.
                    Подробнее см. {Terms.Antilatency_Hardware_Extension_Interface}."]
                    [@$"*Компактный дизайн*
                    HMD Radio Socket может заменить {Hardware.Tag} при трекинге объектов, если объект отслеживания имеет собственную батарею или если внешнюю батарею можно удобно разместить внутри или снаружи корпуса объекта. Главное преимущество HMD Radio Socket - небольшой размер. Его габариты всего {Dimensions} мм.
                    HMD Radio Socket можно закрепить на двухсторонний скотч или используя крепежные отверстия для надежной фиксации (TODO см. файл с моделькой корпуса)."]
                ] 
             ]

    

            [new Section("Техническая спецификация")
                [new Table(2)
                    [$"Интерфейс связи"][@$"2.4GHz Proprietary radio protocol (Master and Slave modes)
                                        USB 2.0 Full Speed"]
                    [$"Разъём"][$"Usb Type-C port (питание и передача данных)"]
                    [$"Аккумулятор"][@$"Нет аккумулятора.
                                    Может работать при подключении к внешней батарее."]
                    [$"Поддержка Antilatency Hardware Extension Interface"][$"Да"]
                    [$"Питание"][$"USB 5V"]
                    [$"Энергопотребление"][@$"Без {Hardware.Alt}: 15mA@5V
                                                С подключённым {Hardware.Alt}: 115mA@5V"]
                    [$"Индикация"][@$"RGB LED"]
                    [$"Габариты"][$"{Dimensions} mm"]
                    [$"Вес"][$"{Weight} g"]
                ]
            ]

            [new Section("LED signals") 
                [SocketUsbRadio_Assets.IndicationTable_ru]
            ]

        ;
}