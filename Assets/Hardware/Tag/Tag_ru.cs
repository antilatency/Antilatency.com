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
             @$"{ThisDevice} - это wireless {Terms.Socket}, который можно закрепить на объекте или части тела человека для их отслеживания. 
             {ThisDevice} сам по себе не определяет свое положение, а передает данные с {Hardware.Alt}, вставленного в него. 
             С использованием {ThisDevice} можно отслеживать физические предметы и кастомные контроллеры, например, макеты оружия."
             )

            [new Section("Features")
                [new UnorderedList()
                    [@$"*Low latency radio protocol*
                    {ThisDevice} для передачи данных использует {Terms.Antilatency_Radio_Protocol}. {ThisDevice} может выступать только в качестве передатчика.{new Info() [$"Для приема данных на хосте обязательно наличие приемника (например, {Hardware.SocketUsbRadio})."]}"]
                    [@$"*Rechargeable battery*
                    {ThisDevice} имеет встроенный заряжаемый аккумулятор емкостью _{BatteryCapacity}_. Порт Type-C используется только для зарядки аккумулятора. Функциональность {ThisDevice} полностью доступна во время зарядки аккумулятора, включая передачу данных трекинга с {Hardware.Alt}."]
                    [@$"*Compact design*
                    {ThisDevice} имеет компактный размер (_{Dimensions}_) и маленький вес (_{Weight}_), что позволяет закрепить его даже на небольших объектах. {ThisDevice} можно закрепить на двухсторонний скотч или используя крепежные отверстия для надежной фиксации (см. TODO файл с моделькой корпуса)."]
                ]
            ]           

            [new Section("Техническая спецификация")
                [new Table(2)
                    [$"Connectivity"][$"2.4GHz Proprietary radio protocol (Slave mode only)"]
                    [$"Ports"][$"Usb Type-C port for charging only"]
                    [$"Battery"][$"{BatteryCapacity} internal LiPo rechargeable battery"]
                    [$"Charging mode"][@$"Fully functional while charging
                                         Current consumption by charging: 350mA@5V"]
                    [$"Indication"][@$"RGB led"]
                    [$"Dimensions"][$"{Dimensions}"]
                    [$"Weight"][$"{Weight}"]
                ]
            ]

            [new Section("Led signals") 
                [Tag_Assets.IndicationTable]
            ]

        ;
}