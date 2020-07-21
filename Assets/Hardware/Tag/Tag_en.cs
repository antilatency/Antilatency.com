using Csml;

partial class Hardware : Scope {

    public static Material Tag_en => new Material(
            "Tag",
            Tag_Assets.TagProduct0,
             @$"{Hardware.Tag} - это wireless {Terms.Socket}, который можно закрепить на объекте или части тела человека для их отслеживания. 
             {Hardware.Tag} сам по себе не определяет свое положение, а передает данные с {Hardware.Alt}, вставленного в него. 
             С использованием {Hardware.Tag} можно отслеживать физические предметы и кастомные контроллеры, например, макеты оружия."
             )

            [new Section("Low latency radio protocol")
                [$"{Hardware.Tag} для передачи данных использует {Terms.Antilatency_Radio_Protocol}. {Hardware.Tag} может выступать только в качестве передатчика."]
                [new Warning()
                    [$"Для приема данных на хосте обязательно наличие приемника (например, {Hardware.SocketUsbRadio}). См. {Terms.Antilatency_Radio_Protocol}"]
                ]
            ]
            
            [new Section("Rechargeable battery")
                [$"{Hardware.Tag} имеет встроенный заряжаемый аккумулятор емкостью 250 mAh. Порт Type-C используется только для зарядки аккумулятора. Функциональность {Hardware.Tag} полностью доступна во время зарядки аккумулятора, включая передачу данных трекинга с {Hardware.Alt}."] 
            ]

            [new Section("Compact design")
                [$"{Hardware.Tag} имеет компактный размер (8.5x18.2x65.7 mm) и маленький вес (18 g), что позволяет закрепить его даже на небольших объектах. {Hardware.Tag} можно закрепить на двухсторонний скотч или используя крепежные отверстия для надежной фиксации (см. TODO файл с моделькой корпуса)."] 
            ]

            [new Section("Техническая спецификация")
                [new Table(2)
                    [$"Connectivity"][$"2.4GHz Proprietary radio protocol (Slave mode only)"]
                    [$"Ports"][$"Usb Type-C port for charging only"]
                    [$"Battery"][$"250mAh internal LiPo rechargeable battery"]
                    [$"Charging mode"][@$"Fully functional while charging
                                         Current consumption by charging: 350mA@5V"]
                    [$"Indication"][@$"RGB LED
                                       For LED signals see table below TODO"]
                    [$"Dimensions"][$"8.5x18.2x65.7 mm"]
                    [$"Weight"][$"18 g"]
                ]
            ]

            [new Section("LED signals") 
                [new Table("Led signal","Socket state")
                    [$"Green to blue cyclic change"][$"Wireless socket is trying to find any receiver to connect"]
                    [$"Green to blue quick cyclic change"][$"Wireless socket is trying to find a specific receiver (“MasterSN” property is not empty)"]
                    [$"Smoothly blinking <color>"][$"Wireless socket is connected to the приемник. <color> should be identical on both devices."]
                    [$"Constant red light"][$"Device error, it will be restarted in a few seconds"]
                    [$"Red blinking (on/off) for N times"][$"Hardware error, N – error code"]
                    [$"Cyclic 5 second red light – 5 seconds off"][$"Socket is charging"]
                    [$"Constant green"][$"Socket is fully charged"]
                ]
            ]

        ;
}