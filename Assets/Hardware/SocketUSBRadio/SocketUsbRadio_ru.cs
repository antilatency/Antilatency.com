using Csml;

partial class Hardware : Scope {

    public static Material SocketUsbRadio_ru => new Material(
            "HMD Radio Socket",
            SocketUsbRadio_Assets.SocketUsbRadioProduct0,
             $"{Hardware.SocketUsbRadio} - это wireless {Terms.Socket}, который поддерживает как прием данных от беспроводных устройств по {Terms.Antilatency_Radio_Protocol}, так и передачу данных трекинга при размещении на объектах отслеживания. ")

            [new Section("Универсальный приемник данных по радиопротоколу ")
                [@$"В работе {Terms.Antilatency_Radio_Protocol} {Hardware.SocketUsbRadio} выступает, как правило, в качестве приемника данных от передатчиков. USB type-C порт в этом случае используется для питания {Hardware.SocketUsbRadio} и  для передачи данных на {Terms.Host} по USB. 
                    См. также ниже другие режимы работы {Hardware.SocketUsbRadio}.
                "]
            ]
            
            [new Section("Работа в качестве передатчика данных")
                [$"{Hardware.SocketUsbRadio} через свойство “Mode” может быть сконфигурирован для работы в качестве передатчика данных по радиопротоколу. В этом случае {Hardware.SocketUsbRadio} получает питание от внешней батареи."] 
            ]

            [new Section("Внешняя батарея")
                [$"К {Hardware.SocketUsbRadio} через порт USB type-C может быть подключена внешний Power bank для питания сокета. {Hardware.SocketUsbRadio} в этом случае работает в качестве передатчика, аналогично {Hardware.Tag}"] 
            ]

            [new Section("Поддержка Extension board")
                [@$"{Hardware.SocketUsbRadio} поддерживает работу с {Hardware.ExtensionBoard}. {Hardware.ExtensionBoard} подключается к {Hardware.SocketUsbRadio} через порт USB type-C для передачи данных о внешних триггерах и управлением откликом(вибрация и т.д.). {Hardware.SocketUsbRadio} передает эти данные вместе с данными трекинга своему приемнику. 
                    Подробнее см. {Terms.Antilatency_Hardware_Extension_Interface}. 
                "] 
            ]

            [new Section("Modular design")
                [@$"{Hardware.SocketUsbRadio} может рассматриваться как альтернативу использованию {Hardware.Tag} при трекинге объектов, в случае если объект отслеживания обладает собственной батареей или же внешнюю батарею удобно разместить внутри или снаружи корпуса объекта. В этом случае {Hardware.SocketUsbRadio} имеет меньший размер, чем {Hardware.Tag}, а питание приходит с внешней батареи. 
                    {Hardware.SocketUsbRadio} можно закрепить на двухсторонний скотч или используя крепежные отверстия для надежной фиксации (TODO см. файл с моделькой корпуса).
                "] 
            ]

            [new Section("Техническая спецификация")
                [new Table(2)
                    [$"Connectivity"][@$"2.4GHz Proprietary radio protocol (Master and Slave modes)
                                        USB 2.0 Full Speed"]
                    [$"Ports"][$"Usb Type-C port for Power and Data Transfer"]
                    [$"Battery"][@$"No built in battery
                                    External power banks are supported "]
                    [$"Antilatency Hardware Extension Interface support "][$"Yes"]
                    [$"Power supply"][$"USB 5V"]
                    [$"Current consumption"][@$"Without {Hardware.Alt}: 15mA@5V
                                                With {Hardware.Alt}: 115mA@5V"]
                    [$"Indication"][@$"RGB LED
                                       For LED signals see table below TODO"]
                    [$"Dimensions"][$"9.1x18.2x32.1 mm"]
                    [$"Weight"][$"7.2 g"]
                ]
            ]

            [new Section("LED signals") 
                [new Table("Led signal","Socket state")
                    [$"Blinking green light (on/off)"][$"Radio is disabled (Connection limit is 0)"]
                    [$"Green to blue cyclic change"][$"Searching for a free radio channel or the radio channel is set to a specific value and this channel is occupied by another device"]
                    [$"Blinking <color> (on/off)"][$"{Hardware.SocketUsbRadio} found a channel to work with and now waits for wireless sockets. <color> is the channel identification, different channels will have different colors"]
                    [$"Smoothly blinking <color>"][$"{Hardware.SocketUsbRadio} has at least one other wireless socket connected to it, <color> will be equal on these devices"]
                    [$"Bright red to pale red cyclic change"][$"Bootloader mode"]
                    [$"Constant red light"][$"Device error, it will be restarted in a few seconds"]
                    [$"Red blinking (on/off) for N times"][$"Hardware error, N – error code"]
                ]
            ]

        ;
}