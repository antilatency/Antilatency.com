using Csml;

partial class Hardware : Scope {

    public static Material Bracer_ru => new Material(
            "Bracer",
            Bracer_Assets.BracerProduct0,
             $"{Hardware.Bracer} - это wireless {Terms.Socket} для отслеживания рук пользователя, спроектированный для удобного размещения на руке. В отличие от стандартных VR-контроллеров, добавляя 6DoF отслеживание рук, {Hardware.Bracer} оставляет руки пользователя свободными для взаимодействия с физическими предметами."
             )

            [new Section("Low latency radio protocol")
                [$"{Hardware.Bracer} для передачи данных использует {Terms.Antilatency_Radio_Protocol}. {Hardware.Bracer} может выступать только в качестве передатчика."]
                [new Warning()
                    [$"Для приема данных на хосте обязательно наличие приемника (например, {Hardware.SocketUsbRadio}). См. {Terms.Antilatency_Radio_Protocol}"]
                ]
            ]
            
            [new Section("Rechargeable battery")
                [@$"{Hardware.Bracer} имеет встроенный заряжаемый аккумулятор емкостью 250 mAh. 
                {Hardware.Bracer} поставляется вместе со специальным модулем для зарядки аккумулятора. Модуль зарядки вставляется в разъем для трекера {Hardware.Alt}. Работа {Hardware.Bracer} во время зарядки не поддерживается. 
                "] 
            ]

            [new Section("Touch поверхность")
                [$"{Hardware.Bracer} имеет в своем составе touch-поверхность, которая при надетом на руку {Hardware.Bracer}, располагается на внутренней стороне ладони. Благодаря этой поверхности {Hardware.Bracer} может распознавать жесты захвата-отпускания объектов в VR."] 
            ]

            [new Section("Haptic feedback")
                [$"{Hardware.Bracer} имеет встроенный модуль вибро-отклика, благодаря которому пользователь может получать тактильную обратную связь от своих действий. Модуль вибро-отклика управляется из приложения пользователя с помощью API"] 
                [new Error()
                    [$"TODO: Ссылка на API "]
                ]
            ]

            [new Section("Designed for hands ")
                [$"{Hardware.Bracer} был специально спроектирован для удобного размещения на руках пользователя. Для подстройки под размер ладони пользователя у {Hardware.Bracer} есть затягивающийся шнурок с фиксацией."] 
            ]

            [new Section("Техническая спецификация")
                [new Table(2)
                    [$"Connectivity"][$"2.4GHz Proprietary radio protocol (Slave mode only)"]
                    [$"Battery"][$"250mAh internal LiPo rechargeable battery"]
                    [$"Charging mode"][@$"Зарядка через разъем для подключения {Hardware.Alt} с использованием специального модуля для зарядки
                                        {Hardware.Bracer} нельзя использовать во время зарядки
                                        Current consumption by charging: 250mA@5V"]
                    [$"Haptic feedback "][$"LRA haptic feedback"]
                    [$"Touch sensing element"][$"На внутренней стороне ладони"]
                    [$"Indication"][@$"RGB LED
                                       For LED signals see table below TODO"]
                    [$"Dimensions"][$"111х38х32.6 mm"]
                    [$"Weight"][$"35 g"]
                ]
            ]

            [new Section("LED signals") 
                [new Table("Led signal","Socket state")
                    [$"Green to blue cyclic change"][$"Wireless socket is trying to find any receiver to connect"]
                    [$"Green to blue quick cyclic change"][$"Wireless socket is trying to find a specific receiver (“MasterSN” property is not empty)"]
                    [$"Smoothly blinking <color>"][$"Wireless socket is connected to the приемник. <color> should be identical on both devices."]
                    [$"Constant red light"][$"Device error, it will be restarted in a few seconds"]
                    [$"Red blinking (on/off) for N times"][$"Hardware error, N – error code"]
                ]

                 [new Table("Charing module's Led signal","Socket state")
                    [$"Blinking green"][$"{Hardware.Bracer} is charging"]
                    [$"Constant green"][$"{Hardware.Bracer} is fully charged"]
                 ]
            ]

        ;
}