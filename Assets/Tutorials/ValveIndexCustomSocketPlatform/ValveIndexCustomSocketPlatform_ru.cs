using Csml;
using System;
using static Tutorials.Valve_Index_Custom_Socket_Platform_Assets;

partial class Tutorials : Scope {

    public static Material Valve_Index_Custom_Socket_Platform_ru => new Material(null, TitleImage, 
    $"Пошаговая инструкция по установке кастомных платформ на ValveIndex и контроллеры")
        [new ToDo("Заменить все картинки с графикой на png или svg",true)]
        [new ToDo("Сделать текст на картинках крупнее", true)]
        [new Section("Установка платформы для напольного сетапа")
            [$"*Шаг 1*"]
                [$"Используйте винты M2x10 DIN912 для установки {Hardware.HMD_Radio_Socket} на напечатанную платформу. Размер шестигранника — 1,5"]
                [ValveIndexBottomSocketPlatformAssembly]
            [$"*Шаг 2*"]
                [$"Отверткой T5 (Torx) выкрутить винты, отмеченные на рисунке. Винты понадобятся для установки платформы на VR гарнитуру"]
                [ValveIndexBottomPlatformStep1]
            [$"*Шаг 3*"]
                [$"Совместите отверстия платформы с отверстиями на ValveIndex и прикрутите площадку"]
                [ValveIndexBottomSocketPlatformInstall]           
            
        ]

        [new Section("Установка платформы для потолочного сетапа")
        [$"*Шаг 1*"]
            [$"Используйте винты M2x10 DIN912 для установки {Hardware.HMD_Radio_Socket} на напечатанную платформу. Размер шестигранника — 1,5"]
            [ValveIndextopSocketPlatformAssembly]
        [$"*Шаг 2*"]
            [$"Наклеить полоску двухстороннего вспененного скотча толщиной 0,5-1 мм на заднюю часть платформы"]
        [$"*Шаг 3*"]
            [$"Обезжирьте переднюю крышку VR гарнитуры и приклейте платформу согласно схеме ниже. Зацепившись верхним выступом на платформе, провернуть площадку вниз до касания с поверхностью шлема и легким надавливанием закрепить на скотче.{new ToDo("тут надо уточнить Механику у Димы, не совсем понятно что он имел в виду")}"]
            [ValveIndextopSocketPlatformInstall]
            [new Info()[$"Двусторонний скотч набирает адгезионную силу в течение 24 часов. Советуем начать использование спустя сутки"]]
        ]
        
        
        ;




}