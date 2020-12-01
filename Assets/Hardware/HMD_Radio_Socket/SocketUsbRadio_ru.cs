using Csml;
using static Hardware.HMD_Radio_Socket_Assets;

partial class Hardware : Scope {

    public static Material HMD_Radio_Socket_ru => new Material(
            "HMD Radio Socket",
            HMD_Radio_Socket_Assets.HMD_Radio_SocketProduct0,
             $"Маленький и лёгкий {Terms.Socket}. {ThisDevice} может работать и как приёмник, и как передатчик. Более того, через {Hardware.ExtensionBoard} устройство может считывать внешние физические триггеры, например, нажание кнопки.")



                [new Section("Два режима работы")
                    [$"HMD Radio Socket может работать как приёмник или как передатчик. В режиме приёмника он собирает данные от других беспроводных устройств и передаёт их на Host через USB type-C. Если Socket подключён к внешней батарее, он может работать как передатчик, отправляя данные master устройству по радиопротоколу."]
                   [new Info($"Подробнее о режимах работы читайте тут: {Tutorials.HMDSocketMode}")]
                ]

                [new Section("Питание от внешней батареи")
                    [$"Разъём USB Type-C служит как для передачи данных, так и для питания устройства. При подключении к внешней батарее, HMD Radio Socket может работать только в режиме передатчика."]
                ]

                [new Section("Поддержка Extension board")
                    [$"{Hardware.ExtensionBoard} подключается к HMD Radio Socket через порт USB type-C. Используя плату, вы можете передавать на {Terms.Socket} данные о внешних триггерах и управлять откликом, к примеру, вибрацией. HMD Radio Socket передаёт эти данные вместе с данными трекинга приёмнику. Подробнее см. {Terms.Antilatency_Hardware_Extension_Interface}."]
                ]
                    
                [new Section("Компактный дизайн")
                    [$"HMD Radio Socket - самое маленькое устройство в линейке Socket. Его размеры - {Dimensions}. HMD Radio Socket можно использовать вместе более крупного {Hardware.Tag} при отслеживании объекта. Для этого нужно подключить Socket к внешнему источнику питания."]
                    [new Info($"HMD Radio Socket можно закрепить на двухсторонний скотч, но мы рекомендуем использовать крепежные отверстия для надежной фиксации.")]
                ]
             

            [new Section("Техническая спецификация")
                [new Table(2)
                    [$"Интерфейс связи"][@$"2.4Гц проприетарный радиопротокол (в режиме точки доступа и клиента)
                                        USB 2.0 Full Speed"]
                    [$"Разъём"][$"USB Type-C port (питание и передача данных)"]
                    [$"Аккумулятор"][@$"Нет.
                                    Можно подключить к внешней батарее."]
                    [$"Поддержка Antilatency Hardware Extension Interface"][$"Да"]
                    [$"Питание"][$"USB 5В"]
                    [$"Энергопотребление"][@$"Без {Hardware.Alt}: 15мA@5В
                                                С подключённым {Hardware.Alt}: 115мA@5В"]
                    [$"Индикация"][@$"RGB LED"]
                    [$"Габариты"][$"{Dimensions} мм"]
                    [$"Вес"][$"{Weight} г"]
                ]
            ]

            [new Section("LED signals") 
                [HMD_Radio_Socket_Assets.IndicationTable_ru]
            ]

        ;
}
