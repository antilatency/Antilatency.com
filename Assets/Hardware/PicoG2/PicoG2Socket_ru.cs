using Csml;
using static Hardware.PicoG2Socket_Assets;

partial class Hardware : Scope {

    public static Material PicoG2Socket_ru => new Material(
            "Pico G2 Socket",
            PicoG2Socket_Assets.PicoG2SocketProduct0,
             $"Беспроводной {Terms.Socket}, спроектированный специально для отслеживания шлема PicoG2. Благодаря дополнительному разъёму USB type-C Female, можно заряжать VR шлем через PicoG2Socket.")

             [new Section("Приём данных от беспроводных устройств","")
             [$"PicoG2Socket работает как приёмник данных. Он собирает данные от подключенных к нему беспроводных устройств и передает их на шлем по USB вместе с данными своего трекера."]]

             [new Section("Компактный дизайн","")
             [$"Socket небольшого размера - {Dimensions} мм - устанавливается через разъём USB type-C. Дизайн устройства адаптирован к геометрии шлема. Благодаря этому Socket держится без дополнительных крепежей."]]
            
            [new Section("USB type-C Female","")
            [$"При подключении кабеля к разъёму USB type-C Female, PicoG2Socket начинает работать как переходник для VR шлема. Благодаря такому решению, после установки Socket вам не нужно отключать его для зарядки шлема или для передачи данных."]]
                        [new Info()
                            [$"PicoG2Socket работает либо в режиме USB-устройства, передавая данные трекинга, либо в режиме USB-переходника для шлема."]
                        ] 
                        
            [new Section("Техническая спецификация")
                [new Table(2)
                    [$"Интерфейс связи"][@$"2.4GHz проприетарный радиопротокол (режим master)
                                        USB 2.0 Full Speed"]
                    [$"Разъём"][@$"USB Type-C Male для подключения к HMD
                                  Usb Type-C Female для подключения HMD к компьютеру через Socket"]
                    [$"Питание"][$"USB 5V"]
                    [$"Энергопотребление"][@$"Без {Hardware.Alt}: 15mA@5V
                                                С подключённым {Hardware.Alt}: 115mA@5V"]
                    [$"Индикация"][@$"RGB LED"]
                    [$"Габариты"][$"{Dimensions} мм"]
                    [$"Вес"][$"{Weight} г"]
                ]
            ]

            [new Section("LED signals") 
                [PicoG2Socket_Assets.IndicationTable_ru]
            ]

        ;
}