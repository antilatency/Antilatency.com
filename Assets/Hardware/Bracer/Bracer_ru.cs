using Csml;
using System.Collections.Generic;
using static Hardware.Bracer_Assets;

partial class Hardware : Scope {

    public static Material Bracer_ru => new Material(
            "Bracer",
            Bracer_Assets.BracerProduct0,
            $"Небольшой лёгкий {Terms.Socket} с поддержкой 6DoF, спроектированный для отслеживания положения рук. Благодаря эргономичному дизайну, можно свободно взаимодействовать с физическими предметами во время трекинга."
            )
            

            [new Section("Низкая задержка","")
            [$"Bracer передаёт данные о положении объекта с трекера {Hardware.Alt}, который делает около 2000 измерений в секунду. В сочетании с задержкой Bracer всего в 2мс это обеспечивает быстрое обновление положения объекта в пространстве и снижает задержку рендеринга."]]
            
            [new Section("Встроенный заряжаемый аккумулятор","")
            [$"Ёмкостью аккумулятора Bracer _{BatteryCapacity}_. Устройство заряжается от специального модуля, который вставляется в разъем для трекера {Hardware.Alt}. Во время зарядки устройство использовать нельзя."]]
                
            [new Section("Сенсорная поверхность","")
            [$"Если надеть Bracer на руку, сенсорная поверхность окажется на внутренней стороне ладони. Устройство поддерживает функцию распознавания жестов захвата-отпускания объектов в VR."]]

            [new Section("Виброотклик","")
            [$"Встроенный модуль виброотклика обеспечивает тактильную обратную связь от действий пользователя. Управление модулем доступно из приложения пользователя с помощью API."]]

            [new Section("Эргономичный дизайн","")
            [$"Мы спроектировали Bracer так, чтобы пользователю было в нём удобно вне зависимости от размера руки. Размер регулируется при помощи затягивающегося шнурка."]]
    

            [new Section("Техническая спецификация")
                [new Table(2)
                    [$"Интерфейс связи"][$"2.4GГц проприетарный радиопротокол (в режиме клиента)"]
                    [$"Аккумулятор"][$"Встроенный LiPo аккумулятор {BatteryCapacity}"]
                    [$"Режим зарядки"][@$"Модуль для зарядки в комплекте
                                        Bracer нельзя использовать во время зарядки
                                        Энергопотребление: 250мA@5В"]
                    [$"Виброотдача"][$"LRA"]
                    [$"Сенсорная поверхность"][$"На внутренней стороне ладони"]
                    [$"Индикация"][@$"RGB LED"]
                    [$"Габариты"][$"{Dimensions} мм"]
                    [$"Вес"][$"{Weight} г"]
                ]
            ]

            [new Section("LED signals") 
                [IndicationTable_ru]
            ]

        ;
}
