﻿using Csml;

using static Terms.SocketReferenceDesignDeploying_Assets;

partial class Terms {
    public static Material SocketReferenceDesign_ru => new Material("Socket Reference Design", TopView,
    @$"Отладочная плата для разработчиков {Terms.Socket}")
        [new Section("Ключевые функциональные блоки")
            [new UnorderedList()
                [$"Nrf52840 module"]
                [$"Swd connector"]
                [$"Usb connector"]
                [$"Dc/Dc 3V"]
                [$"{Hardware.Alt} connector"]
                [$"Rgb status led"]
                [$@"{Terms.Antilatency_Hardware_Extension_Interface} components(optional):
                    {new UnorderedList()
                    [$"Leds"]
                    [$"Buttons"]
                    [$"Trimmers"]}"
                ]

            ]
        ]

        [new Section("Рекомендации к плате")
            [new UnorderedList()
                [$"Высота 2мм для правильной установки магнита."]
                [$"Покрытие Immersion gold, которое обеспечивает равномерность толщины покрытия, высокую износоустойчивость, а также стабильный контакт между погопинами {Hardware.Alt} и платой."]
            ]
        ]

        [new Section("Nrf52840 module")
            [$"Мы настойчиво рекомендуем использовать именно модуль с Nrf52840, а не ставить на свою плату контроллер Nrf52840 и внешние компоненты для его корректной работы. Использование модуля даёт такие преимущества:"]
            [new UnorderedList()
                [$"Самое главное - он сертифицирован! Это значительно уменьшает время выхода на рынок."]
                [$"BOM гораздо  меньше, как следствие - проще монтаж платы и меньше ошибок при сборке."]
                [$"Все внешние компоненты для контроллера уже на своих местах, поэтому нет опасности, что их расположат неправильно."]
                [$"Как правило, в серии модули идут на выбор с разными антеннами или разъёмами. А значит - можно подобрать под себя, если есть предпочтения."]
                [$"Некоторые производители предлагают предзагрузить прошивку / бутлоадер перед отправкой."]
            ]
            [new Warning($"Отказ от использования модуля возможен. Это потребует расположения на своей плате контроллера, внешних компонентов и RF части. Однако необходимо понимать возможные последствия такого решения.")]
        ]

        [new Section("Питание")
            [$"Контроллер и {Hardware.Alt} требует питание 3V, средние потребление около 200mA в рабочем режиме. Рекомендуем брать регулятор с током минимум 250-300mA. Мы используем Dc/Dc NCP1529MUTBG."]
            [new Info($"Для работы usb модуля обязательно наличие 5V. Данный вход запитывает только usb модуль(меньше 1mA).")]
            [new Info($"С помощью джампера `VCC_3V`, можно отключить выход `3.0V` стабилизатора на плате и подключить свой источник питания.")]
        ]

        [new Section("Usb connector")
            [$"Usb обеспечивает устройство питанием 5V, а также соединяет контроллер для передачи данных, обновления прошивки и настройки свойств устройства."]
            [new Info($"Для подключения своего питания предусмотрен джампер `USB_5V`. Когда usb не нужен, например, сокет работает в wireless mode, на вход `VBUS` можно подавать любое напряжение в диапазоне `3V` - `5.5V`")]
        ]

        [new Section("Swd connector")
            [$"SWD разъём нужен для того, чтобы прошить первый раз bootloader в контроллер. После данной операции он не нужен, так как дальнейшая загрузка/обновление прошивки осуществляется через уже прошитый bootloader при помощи {Terms.AntilatencyService}"]
            [$"На плате стоят два разъёма: MicroMatch FOB.06P и Pls-4, Они дублируют друг друга. На своей плате достаточно поставить один в зависимости от предпочтений."]
            [new Info($"Разъём не нужен, если модули будут предпрошиты производителем.")]
        ]

        [new Section($"{Hardware.Alt} connector")
            [$"Разъём для {Hardware.Alt} состоит из 8 сигнальных площадок и отверстие под магнит по центру. Рядом необходимо заложить монтажные отверстия для монтажа стенок, которые необходимы для выравнивания. См. {Tutorials.SocketReferenceDesignDeploying:mechanics} для лучшего понимания."]
        ]

        [new Section("Rgb status led")
            [$"Rgb светодиод помогает сокету показать своё состояние пользователю. У него много режимов индикации, поэтому крайне желательно сохранить данный светодиод на своей плате."]
            [new Info($"При выборе другого светодиода необходимо проверить соответствие оттенков с рекомендуемым.")]
        ]

        [new Section($"{Terms.Antilatency_Hardware_Extension_Interface} components")
            [$"Это опциональная часть. Если вы не планируете использовать {Terms.Antilatency_Hardware_Extension_Interface}, то соответствующие компоненты можно не ставить, и пины контроллера никуда не подключать."]
            [$"На плате находятся 2 кнопки, 2 триммера-потенциометра и 4 светодиода. Каждый из этих компонентов подключен к контроллеру через джампер, с помощью него можно отключить компонент на плате и подключить другой внешний компонент."]
        ]

    ;
}
