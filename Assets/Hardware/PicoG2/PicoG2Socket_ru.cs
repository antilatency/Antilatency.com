using Csml;
using static Hardware.PicoG2Socket_Assets;

partial class Hardware : Scope {

    public static Material PicoG2Socket_ru => new Material(
            "Pico G2 Socket",
            PicoG2Socket_Assets.PicoG2SocketProduct0,
             $"PicoG2Socket - это беспроводной {Terms.Socket}, спроектированный специально для отслеживания шлема PicoG2.")

             [new Section("Функциональные особенности","")
                [new UnorderedList()
                    [@$"*Приём данных от беспроводных устройств* 
                    В работе {Terms.Antilatency_Radio_Protocol} PicoG2Socket выступает в качестве приёмника данных. PicoG2Socket собирает данные от подключенных к нему беспроводных устройств и передает их на шлем по USB вместе с данными своего трекера."]
                    [@$"*Компактный дизайн*
                    Устройство адаптировано к геометрии модели PicoG2, благодаря чему оно надёжно крепится на шлеме. Socket имеет небольшой размер - {Dimensions} мм - и устанавливается через разъём USB type-C."]
                    [@$"*Дополнительный разъём USB type-C Female*
                    При подключении кабеля к разъёму USB type-C Female, PicoG2Socket начинает работать как переходник для VR шлема. Поэтому единожды установив и зафиксировав Socket, не нужно его отключать для зарядки шлема или для передачи данных. Это будет осуществляться через дополнительный разъём."]
                        [new Info()
                            [$"PicoG2Socket работает либо в режиме USB-устройства, передавая данные трекинга, либо в режиме USB-переходника для шлема."]
                        ] 
                ] 
             ]

            [new Section("Техническая спецификация")
                [new Table(2)
                    [$"Интерфейс связи"][@$"2.4GHz Proprietary radio protocol (Master only)
                                        USB 2.0 Full Speed"]
                    [$"Разъём"][@$"Usb Type-C Male connector for connection between PicoG2Socket and headset
                                  Usb Type-C Female connector for charging and connection between headset and PC"]
                    [$"Питание"][$"USB 5V"]
                    [$"Энергопотребление"][@$"Без {Hardware.Alt}: 15mA@5V
                                                С подключённым {Hardware.Alt}: 115mA@5V"]
                    [$"Индикация"][@$"RGB LED"]
                    [$"Габариты"][$"{Dimensions} mm"]
                    [$"Вес"][$"12 g"]
                ]
            ]

            [new Section("LED signals") 
                [PicoG2Socket_Assets.IndicationTable_ru]
            ]

        ;
}