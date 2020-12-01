using Csml;
using static Hardware.SocketUsb_Assets;

public partial class Hardware{

public static Material SocketUsb_ru => new Material("Socket USB", null, $"Лёгкий и маленький Socket без поддержки {Terms.Antilatency_Radio_Protocol} идёт в комплекте с {Hardware.Alt}.")

[new Section("Техническая спецификация")
                [new Table(2)
                    [$"Интерфейс связи"][@$"USB 2.0 Full Speed"]
                    [$"Разъём"][$"USB Type-C port (питание и передача данных)"]
                    [$"Аккумулятор"][@$"Нет"]
                    [$"Поддержка Antilatency Hardware Extension Interface"][$"Нет"]
                    [$"Питание"][$"USB 5В"]
                    [$"Энергопотребление"][@$"Без {Hardware.Alt}: 15мA@5В
                                                С подключённым {Hardware.Alt}: 115мA@5В"]
                    [$"Индикация"][@$"RGB LED"]
                    [$"Габариты"][$"{Dimensions} мм"]
                    [$"Вес"][$"{Weight} г"]
                ]
            ]

;
}