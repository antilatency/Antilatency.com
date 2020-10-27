using Csml;
using System;
using System.Collections.Generic;
using System.Drawing;
using static Hardware.Tag_Assets;

partial class Hardware : Scope {


    public static System.FormattableString ThisDevice = $"_{Hardware.Tag.Title}_";

    public static Material Tag_ru => new Material(
            "Tag",
            Tag_Assets.TagProduct0,
             @$"{ThisDevice} - это беспроводной {Terms.Socket}, который можно закрепить на объекте или на части тела человека для их отслеживания. Он передаёт данные с подключённого к нему {Hardware.Alt}. Используя {ThisDevice}, вы можете отслеживать положение физических предметов и кастомных контроллеров, например, макетов оружия."
             )

            [new Section("Особенности","")
                [new UnorderedList()
                    [@$"*Низкая задержка при передаче данных*
                    {ThisDevice} для передачи данных использует {Terms.Antilatency_Radio_Protocol}. {ThisDevice} может выступать только в качестве передатчика.{new Info() [$"Для приема данных на хосте обязательно наличие приемника (например, {Hardware.SocketUsbRadio})."]}"]
                    [@$"*Встроенный заряжаемый аккумулятор*
                    {ThisDevice} имеет встроенный заряжаемый аккумулятор ёмкостью _{BatteryCapacity}_. Порт Type-C используется только для зарядки аккумулятора. Функциональность {ThisDevice} полностью доступна во время зарядки аккумулятора, включая передачу данных трекинга с {Hardware.Alt}."]
                    [@$"*Компактный дизайн*
                    Габариты {ThisDevice} (_{Dimensions}_), а вес всего (_{Weight}_), что позволяет закрепить устройство даже на небольших объектах. Для надёжной фиксации рекомендуем устанавливать Socket с помощью крепёжных отверстий.(см. TODO файл с моделькой корпуса)."]
                ]
            ]           

            [new Section("Техническая спецификация")
                [new Table(2)
                    [$"Интерфейс связи"][$"2.4GHz Proprietary radio protocol (Slave mode only)"]
                    [$"Разъём"][$"USB Type-C (только для зарядки)"]
                    [$"Ёмкость батареи"][$"встроенный LiPo аккумулятор {BatteryCapacity}"]
                    [$"Режим зарядки"][@$"Fully functional while charging
                                         Энергопотребление: 350mA@5V"]
                    [$"Индикация"][@$"RGB LED"]
                    [$"Габариты"][$"{Dimensions}"]
                    [$"Вес"][$"{Weight}"]
                ]
            ]

            [new Section("LED signals") 
                [Tag_Assets.IndicationTable_ru]
            ]

        ;
}