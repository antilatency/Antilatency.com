using Csml;
using static Hardware.Alt_Assets;

partial class Hardware : Scope {
        public static Material Alt_ru => new Material("Alt", AltAndUsbSocket0,
        @$"Оптико-инерциальный модуль трекинга небольшого размера имеет угол обзора в 240 градусов. С его помощью вы можете отслеживать положение любого физического объекта. Alt поставляется в комплекте с {Hardware.SocketUsb}.")

        [new Section("Слияние данных","")
        [$"Alt параллельно обрабатывает данные из двух источников: инфракрасной камеры и IMU, инерциального измерительного модуля. Это обеспечивает точное отслеживание положения объекта в пространстве в режиме реального времени."]
        ]

        [new Section("Низкая задержка при передаче данных", "")
        [$"Трекер делает около 2000 измерений в секунду, при этом задержка при передаче данных всего 2мс."]
        ]

        [new Section("Работа с данными","")
        [$"Модуль Alt выполняет большинство задач по обработке данных трекинга, благодаря чему снижается нагрузка на HMD."]
        ]

        [new Section("Широкий угол обзора","")
        [$"Инфракрасная камера Alt охватывает область в 240 градусов. Хорошая видимость маркеров зоны трекинга обеспечивает стабильное отслеживает позиции объекта в пространстве."]
        ]    

        [new Section("Техническая спецификация")
            [new Table(2)
                [$"Датчики"][$"Оптический датчик,  акселерометр,  гироскоп"]
                [$"Частота обновления"][$"2000 Гц"]
                [$"Задержка"][$"2 мс"]
                [$"Угол обзора"][$"240 градусов"]
                [$"Потребление энергии"][@$"В режиме трекинга: 175мA@3В
                                          В режиме ожидания: 130мA@3В"]
                [$"Интерфейс связи"][@$"Передача данных через {Terms.Socket}"]
                [$"Габариты"][$"{Dimensions} мм"]
                [$"Вес"][$"{Weight} г"]
            ]
        ]



        ;
}