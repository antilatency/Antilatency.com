using Csml;
using System;
using System.Collections.Generic;
using System.Drawing;
using static Hardware.Tag_Assets;

partial class Hardware : Scope {


    public static Material Tag_ru => new Material(
        "Tag",
        TagProduct0,
        $"Беспроводной {Terms.Socket}, который можно удобно разместить даже на небольшом объекте из-за малых габаритов и веса. Кроме того, {ThisDevice} имеет встроенный аккумулятор и остаётся полностью функционален во время зарядки.")

        [new Section("Низкая задержка при передаче данных","")
        [$"{ThisDevice} может выступать только в качестве передатчика. Для обмена данными к Host должен быть подключён приёмник (например, {Hardware.HMD_Radio_Socket}). Для передачи данных {ThisDevice} использует {Terms.Antilatency_Radio_Protocol}."]]

        [new Section("Встроенный аккумулятор","")
        [$"{ThisDevice} имеет встроенный заряжаемый аккумулятор ёмкостью _{BatteryCapacity}_. Порт Type-C используется только для зарядки аккумулятора. Функциональность {ThisDevice} полностью доступна во время зарядки аккумулятора, включая передачу данных трекинга с {Hardware.Alt}."]]

        [new Section("Компактный дизайн","")
        [$"Размер устройства {Dimensions}, а вес всего {Weight}. {ThisDevice} можно закрепить на объекте при помощи двустороннего скотча, но для надёжной фиксации рекомендуем устанавливать Socket с помощью крепёжных отверстий."]]       

            [new Section("Техническая спецификация")
                [new Table(2)
                    [$"Интерфейс связи"][$"2.4GHz проприетарный радиопротокол (только режим radio slave)"]
                    [$"Разъём"][$"USB Type-C (только для зарядки)"]
                    [$"Ёмкость батареи"][$"встроенный LiPo аккумулятор {BatteryCapacity}"]
                    [$"Режим зарядки"][@$"Полностью функционален во время зарядки.
                                         Энергопотребление: 350mA@5V"]
                    [$"Индикация"][@$"RGB LED"]
                    [$"Габариты"][$"{Dimensions} мм"]
                    [$"Вес"][$"{Weight} г"]
                ]
            ]

            [new Section("LED индикация") 
                [IndicationTable_ru]
            ]

        ;
}