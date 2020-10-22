﻿﻿using Csml;
using System.Net.Sockets;
using static Tutorials.SocketCustomizing_Assets;

partial class Tutorials : Scope {

    public static Material SocketCustomizing_ru =>

        new Material(
            "Создание своего Socket",
            null,
        $"Как разработать свой {Terms.Socket} на основе {Terms.SocketReferenceDesign}")
            [new Section("Основные компоненты")
                [new OrderedList()
                    [$"Разработанная плата"]
                    [$"Разработанная механическая часть"]
                    [$"Прошивка от Antilatency"]
                    [$"Модуль {Hardware.Alt} (для проверки правильности сборки {Terms.Socket})"]
                ]
            ]

            [new Section("Разработка платы")
                [$"В качестве примера вы можете использовать {Terms.SocketReferenceDesign}. Модули этой платы, подойдут и для вашего проекта."]
                
                [$"Основные рекомендации по разработке:"]
                [new UnorderedList()
                    [$"Делайте проводники SPI к {Hardware.Alt} максимально короткими. Важно надёжно защитить их от помех."]
                    [$"Расположение nRF модуля должно соответствовать требованиям технического описания. Особое внимание обратите на расположение антенны."]
                ]
                [$"*Для загрузки доступны файлы:* схемотехника, 3d модель, производственные BOM, Gerber и техническое описание для модуля nRF52840 MS88SF3 V1.1."]
                
                [CustomMaterials]
            ]

            [new Section("Разработка механической части", "mechanics")

                [$"Крепление для {Hardware.Alt} - самый важный этап разработки. Мы используем магнит N52 и алюминиевый стакан, чтобы надёжно зафиксировать модуль в нужной позиции на площадке."]

                    [new Section("Установка магнита","")
                        [$"Используемый магнит имеет диаметр 7мм и высоту 2мм. Размер отверстия в плате под такой магнит 6,9 мм. Благодаря разнице в диаметрах магнит прочно впресовывается в плату."]
                        [new Note($"После этого этапа паять плату уже нельзя, потому что магнит теряет свои свойства при перегреве.")]
                        [$"Перед началом работы подготовьте плату, магнит и трекер {Hardware.Alt}."]
                            [MagnetMount0]
                        [$"*Шаг 1.* Чтобы определить полярность магнита, соедините его с модулем {Hardware.Alt}. Отметьте ту сторону магнита, которая будет снизу платы. Мы использовали красный маркер."]
                        [new Warning($"Если установить магнит не той стороной, {Hardware.Alt} будет отталкиваться от {Terms.Socket}.")]
                            [MagnetMount1]
                        [$"*Шаг 2.* Аккуратно впрессуйте магнит в плату при помощи тисков."]
                            [MagnetMount2]
                            [MagnetMount3]
                        [$"*Шаг 3.* Проверьте, совпадает ли плоскость магнита с плоскостью платы."]
                        [new Warning($"Если магнит установлен под углом, контакт между пинами {Hardware.Alt} и площадками на плате будет нестабильный.")]
                            [MagnetMount4]
                            [MagnetMount5]
                        [$"*Шаг 4.* Подсоедините трекер {Hardware.Alt} и проверьте, надёжно ли он держится."]
                            [MagnetMount6]

                    ]

                    [new Section("Установка стакана","")
                        [$"Алюминиевый стакан с 4-мя ножками удерживает трекер {Hardware.Alt}. Эти же ножки после расклёпки фиксируют стакан на плате."]
                        [Holder3D]
                        [$"Перед началом работы подготовьте плату с установленным магнитом, {Hardware.Alt}, кернер и молоток."]
                            [HolderMount1]
                        [$"*Шаг 1.* Установите стакан на плату."]
                            [HolderMount2]
                        [$"*Шаг 2.* Переверните плату и прислоните её к устойчивой поверхности. Например, положите на стол."]
                        [new Warning($"Рекомендуем подложить что-то под стакан, чтобы его не поцарапать. К примеру, кусок картона.")]
                            [HolderMount3]
                        [$"*Шаг 3.* Установите кернер по центру ножки стакана и аккуратно ударьте по нему молотком несколько раз. Повторите эти действия для каждой ножки."]
                            [HolderMount4]
                            [HolderMount5]
                        [$"*Шаг 4.* после расклёпки ножки надёжно зафиксируют стакан на плате."]
                            [HolderMount6]
                            [HolderMount7]
                        [$"*Шаг 5.* Вставьте {Hardware.Alt} и проверьте, надежно ли держится модуль."]
                            [HolderMount8]
                    ]
            ]

            [new Section("Прошивка от Antilatency")
                [$"Скачайте `*.bin` файл, который представляет собой bootloader. Данный файл прошивки загрузите в контроллер на плате, используя SWD пины и программатор(например, Jlink)."]
                [new Info($"Некоторые производители nRF модулей могут по запросу клиента прошить контроллер перед отправкой. В таком случае вам не нужно прошивать устройство самостоятельно.")]
                [$"После прошивки bootloader, подключите USB и с помощью {Terms.AntilatencyService} установите акутальную версию прошивку. Вы получите доступ к полному функционалу системы Antilatency. Набор функций аналогичен {Hardware.SocketUsbRadio} и включает в себя поддержку {Terms.Antilatency_Hardware_Extension_Interface}, обновление через {Terms.AntilatencyService} и работу {Terms.Antilatency_Radio_Protocol} в двух режимах."]
                ]
            ;
}
