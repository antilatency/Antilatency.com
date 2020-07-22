using Csml;

partial class Hardware : Scope {

    public static Material PicoG2Socket_en => new Material(
            "Pico G2 Socket",
            PicoG2Socket_Assets.PicoG2SocketProduct0,
             $"{Hardware.PicoG2Socket} - это wireless {Terms.Socket}, спроектированный под шлем PicoG2 для трекинга шлема и приема данных от беспроводных устройств по {Terms.Antilatency_Radio_Protocol}.")

            [new Section("Дизайн для шлема Pico G2")
                [$"{Hardware.PicoG2Socket} был специально спроектирован под геометрию шлема Pico G2. {Hardware.PicoG2Socket} позиционируется с помощью разъема USB type-C на шлеме и надежно фиксируется на шлеме."]
            ]
            
            [new Section("Прием данных от беспроводных устройств по радиопротоколу ")
                [$"В работе {Terms.Antilatency_Radio_Protocol} {Hardware.PicoG2Socket} выступает в качестве приемника данных от передатчиков. {Hardware.PicoG2Socket} собирает данные от подключенных к нему беспроводных устройств и передает их на шлем по USB вместе с данными своего трекера."] 
            ]

            [new Section("Дополнительный разъем USB type-C Female")
                [$"Помимо разъема USB type-C Male для подключения к шлему {Hardware.PicoG2Socket} имеет разъем USB type-C Female. При подключении кабеля к разъему USB type-C Female, {Hardware.PicoG2Socket} начинает работать как USB-переходник для зарядки и проброса USB-данных на шлем. Таким образом, единожды подключив {Hardware.PicoG2Socket} к шлему и зафиксировав, {Hardware.PicoG2Socket} уже не нужно будет отключать: зарядка шлема и передача данных по USB для установки приложений будет происходить через указанный разъем USB type-C Female."] 
                [new Info()
                    [$"{Hardware.PicoG2Socket} работает в 2-х взаимоисключающих режимах: либо в режиме USB-устройства, передающее данные трекинга на шлем, либо в режиме USB-переходника."]
                ]                
            ]


            [new Section("Техническая спецификация")
                [new Table(2)
                    [$"Connectivity"][@$"2.4GHz Proprietary radio protocol (Master only)
                                        USB 2.0 Full Speed"]
                    [$"Ports"][@$"Usb Type-C Male connector for connection between {Hardware.PicoG2Socket} and headset
                                  Usb Type-C Female connector for charging and connection between headset and PC"]
                    [$"Power supply"][$"USB 5V"]
                    [$"Current consumption"][@$"Without {Hardware.Alt}: 15mA@5V
                                                With {Hardware.Alt}: 115mA@5V"]
                    [$"Indication"][@$"RGB LED
                                       For LED signals see table below TODO"]
                    [$"Dimensions"][$"44.1×21×36 mm"]
                    [$"Weight"][$"12 g"]
                ]
            ]

            [new Section("LED signals") 
                [new Table("Led signal","Socket state")
                    [$"Blinking green light (on/off)"][$"Radio is disabled (Connection limit is 0)"]
                    [$"Green to blue cyclic change"][$"Searching for a free radio channel or the radio channel is set to a specific value and this channel is occupied by another device"]
                    [$"Blinking <color> (on/off)"][$"{Hardware.PicoG2Socket} found a channel to work with and now waits for wireless sockets. <color> is the channel identification, different channels will have different colors"]
                    [$"Smoothly blinking <color>"][$"{Hardware.PicoG2Socket} has at least one other wireless socket connected to it, <color> will be equal on these devices"]
                    [$"Bright red to pale red cyclic change"][$"Bootloader mode"]
                    [$"Constant red light"][$"Device error, it will be restarted in a few seconds"]
                    [$"Red blinking (on/off) for N times"][$"Hardware error, N – error code"]
                    [$"Short green flash"][$"External USB cable connected. Radio and tracker is turned off"]
                ]
            ]

        ;
}