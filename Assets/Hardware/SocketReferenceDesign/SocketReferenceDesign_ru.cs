﻿using Csml;

public partial class Hardware : Scope {

    public static Material SocketReferenceDesign_ru => new Material("SocketReferenceDesign",
    TopView,
    @$"Отладочная плата для разработчиков {Terms.Socket}, на основе которой можно собрать собственный Socket. Мы разработали рекомендации к параметрам платы и к дополнительным элементам, которые вы можете на неё поставить.")
        [new Section("Ключевые функциональные блоки","")
            [new UnorderedList()
                [$"nRF52840 module"]
                [$"SWD разъём"]
                [$"USB разъём"]
                [$"DC/DC 3V"]
                [$"{Hardware.Alt} разъём"]
                [$"RGB LED"]
                [$@"{Terms.Antilatency_Hardware_Extension_Interface} компоненты (опционально):
                    {new UnorderedList()
                    [$"cветодиоды"]
                    [$"кнопки"]
                    [$"триммеры"]}"
                ]

            ]
        ]
        [new Note($"Подробнее о разработке своего Socket читайте тут: {Tutorials.SocketCustomizing}")]

        [new Section("Рекомендации к плате","")
            [new UnorderedList()
                [$"высота 2мм - для правильной установки магнита;"]
                [$"покрытие ENIG - обеспечивает равномерность толщины покрытия, высокую износоустойчивость, а также стабильный контакт между погопинами {Hardware.Alt} и платой."]
            ]
        ]

        [new Section("Модуль nRF52840","")
            [$"Мы настойчиво рекомендуем использовать именно модуль с nRF52840, а не устанавливать на плату контроллер nRF52840 с внешними компонентами. Использование модуля имеет свои преимущества:"]
            [new UnorderedList()
                [$"меньше времени нужно для выхода вашего продукта на рынок, так как модуль сертифицирован;."]
                [$"BOM гораздо  меньше, что делает монтаж платы проще, следовательно, меньше шанс допустить ошибку при сборке;"]
                [$"все внешние компоненты для контроллера уже установлены на своих местах;"]
                [$"вы можете подобрать вариант модуль с нужными вам антенной и разъёмом, благодаря разнообразию устройств в серии;"]
                [$"некоторые производители перед отправкой могут прошить устройство по вашему запросу."]
            ]
            [new Warning($"Вы можете не использовать модуль. Тогда нужно поставить на плату контроллер, требуемые внешние компоненты к нему и RF антенну.")]
        ]

        [new Section("Питание","")
            [$"Контроллер и {Hardware.Alt} требуют питание 3V при среднем потреблении около 200mA в рабочем режиме. Мы рекомендуем брать регулятор с током минимум 250-300mA, к примеру, DC/DC NCP1529MUTBG."]
            [new Info($"Для работы USB модуля нужно питание 5V. Данный вход запитывает только USB модуль(меньше 1mA).")]
            [new Info($"С помощью джампера `VCC_3V`, можно отключить выход `3.0V` стабилизатора на плате и подключить свой источник питания.")]
        ]

        [new Section("USB разъём","")
            [$"USB обеспечивает устройство питанием 5V, а также соединяет контроллер для передачи данных, обновления прошивки и настройки свойств устройства."]
            [new Info($"Для подключения своего питания предусмотрен джампер `USB_5V`. Когда USB не нужен, например, если Socket работает в wireless режиме, на вход `VBUS` можно подавать любое напряжение в диапазоне `3V` - `5.5V`.")]
        ]

        [new Section("SWD разъём","")
            [$"SWD разъём нужен для того, чтобы загрузить в первый раз bootloader в контроллер. После этого он больше не нужен, так как дальнейшая загрузка/обновление прошивки осуществляется через уже прошитый bootloader в {Software.AntilatencyService.Material}"]
            [$"На плате стоят два разъёма: MicroMatch FOB.06P и Pls-4, Они дублируют друг друга. На своей плате достаточно поставить один в зависимости от ваших предпочтений."]
            [new Info($"Разъём не нужен, если модули будут предпрошиты производителем.")]
        ]

        [new Section($"{Hardware.Alt} разъём","")
            [$"Разъём для {Hardware.Alt} состоит из 8 сигнальных площадок и отверстие под магнит по центру. Рядом необходимо заложить монтажные отверстия для установки стакана. Подробнее читайте тут: {Tutorials.SocketCustomizing:mechanics}"]
        ]

        [new Section("RGB LED","")
            [$"RGB светодиод отображает состояние Socket. У него много режимов индикации, поэтому крайне желательно сохранить данный светодиод на своей плате."]
            [new Info($"При выборе другого светодиода проверьте соответствие оттенков с рекомендуемым.")]
        ]

        [new Section($"{Terms.Antilatency_Hardware_Extension_Interface} компоненты","")
            [$"Это опциональная часть. Если вы не планируете использовать {Terms.Antilatency_Hardware_Extension_Interface}, то соответствующие компоненты можно не ставить и пины контроллера никуда не подключать."]
            [$"На плате мы расположили 2 кнопки, 2 триммера-потенциометра и 4 светодиода. Каждый из этих компонентов подключен к контроллеру через джампер. С его помощью можно отключить компонент на плате и подключить другой внешний компонент."]
        ]

    ;
}
