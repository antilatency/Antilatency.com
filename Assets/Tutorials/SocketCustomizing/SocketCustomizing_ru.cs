﻿﻿using Csml;
using System.Net.Sockets;
using static Tutorials.SocketCustomizing_Assets;

partial class Tutorials : Scope {

    public static Material SocketCustomizing_ru =>

        new Material(
            "Socket Reference Design Deploying",
            null,
        $"В данной статье будет описана последовательность действий для изготовления своего {Terms.Socket} с помощью {Terms.SocketReferenceDesign}")
            [new Section("Основные компоненты")
                [new OrderedList()
                    [$"Разработанная плата."]
                    [$"Разработанная механическая часть."]
                    [$"Прошивка от Antilatency."]
                ]
            ]

            [new Section("Разработка платы")
                [$"Примером является {Terms.SocketReferenceDesign} с него можно перенести в свой проект необходимые модули. Для загрузки доступны файлы: схемотехника, пример трассировки, 3d модель, производственные BOM и Gerber."]
                [$"Проводники Spi к {Hardware.Alt} необходимо сделать максимально короткими и защищёнными от помех."]
                [$"Расположение Nrf модуля должно соответствовать требованиям из даташита на модуль. Особое внимание нужно уделить антенне."]
                [new ToDo("Ссылка на даташит.")]
            ]

            [new Section("Разработка механической части", "mechanics")
                [$"Основной нюанс, который необходимо учитывать, - это крепление для {Hardware.Alt}. Площадка должна содержать магнит для надёжной фиксации, а также стенки для правильной позиции."]
                [$"Мы применяем магнит с характеристиками: D = 7mm; H = 2mm; Grade = N52. Данный магнит хорошо запрессуется в отверстие в плате диаметром 6.9mm."]
                [new ToDo("3d модель стакана")]
                [$"Для стенок мы используем алюминиевый  стакан(модель доступна для загрузки) с 4-мя ножками, которые позиционируют его относительно платы. Эти же ножки после расклёпки удерживают стакан на плате."]
                [new ToDo("Обновить фотки, когда будут платы.")]
                [$"Top view:"]
                [AltMount1]
                [$"Bottom view:"]
                [AltMount2]
            ]

            [new Section("Прошивка от Antilatency")
                [$"С сайта необходимо скачать `*.bin` файл, который представляет собой bootloader. Данный файл прошивки необходимо загрузить в контроллер на плате с помощью SWD пинов и программатора(например, Jlink)."]
                [new Info($"Некоторые производители Nrf модулей могут по запросу прошить контроллер до отправки. В таком случае достаточно скинуть им файл прошивки, SWD программатор не нужен.")]
                [$"После прошивки bootloader, необходимо подключить usb, и с помощью {Terms.AntilatencyService} установить акутальную версию прошивку. Уже в этой прошивке доступен полный функционал системы Antilatency. Набор функций аналогичен {Hardware.SocketUsbRadio}, включая поддержку {Terms.Antilatency_Hardware_Extension_Interface}, обновления через {Terms.AntilatencyService} и работу {Terms.Antilatency_Radio_Protocol} в двух режимах."]
            ]
            ;
}
