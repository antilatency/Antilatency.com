using Csml;
using System.Collections.Generic;
using static Hardware.Bracer_Assets;

partial class Hardware : Scope {

    public static Material Bracer_ru => new Material(
            "Bracer",
            Bracer_Assets.BracerProduct0,
            $"Bracer - это беспроводной {Terms.Socket}, разработанный для отслеживания 6DoF. Устройство надевается на руку и отслеживает её положение, передавая данные с {Hardware.Alt}. В это время вы можете свободно взаимодействовать с физическими предметами, к примеру, с макетом оружия или огнетушителя."
            )

            [new Section("Функциональные особенности","")
                [new UnorderedList()
                    [@$"*Радиопротокол с низкой задержкой* 
                    Bracer может выступать только в качестве передатчика. Для обмена данными к Host должен быть подключён приёмник (например, {Hardware.SocketUsbRadio}). Для передачи данных Bracer использует {Terms.Antilatency_Radio_Protocol}."]
                    [@$"*Встроенный заряжаемый аккумулятор* 
                    Bracer имеет встроенный заряжаемый аккумулятор ёмкостью _{BatteryCapacity}_. Bracer поставляется вместе со специальным модулем для зарядки, который вставляется в разъем для трекера {Hardware.Alt}. Во время зарядки устройство использовать нельзя."]
                    [@$"*Сенсорная поверхность*
                    Если надеть Bracer на руку, сенсорная поверхность окажется на внутренней стороне ладони. Благодаря такому расположению, устройство может распознакать жесты захвата-отпускания объектов в VR."]
                    [@$"*Вибро-отклик*
                    Bracer имеет встроенный модуль вибро-отклика, благодаря которому пользователь может получать тактильную обратную связь от своих действий. Модуль вибро-отклика управляется из приложения пользователя с помощью API."]
                    [new Error()
                    [$"TODO: Ссылка на API "]
                    ]
                    [@$"*Эргономичный дизайн*
                    Устройство разработано специально для удобного размещения на руке пользователя. Размер регулируется при помощи затягивающегося шнурка."]
                 ] 
             ]

            [new Section("Техническая спецификация")
                [new Table(2)
                    [$"Connectivity"][$"2.4GHz Proprietary radio protocol (Slave mode only)"]
                    [$"Battery"][$"250mAh internal LiPo rechargeable battery"]
                    [$"Charging mode"][@$"Зарядка через разъем для подключения {Hardware.Alt} с использованием специального модуля для зарядки
                                        Bracer нельзя использовать во время зарядки
                                        Current consumption by charging: 250mA@5V"]
                    [$"Haptic feedback "][$"LRA haptic feedback"]
                    [$"Touch sensing element"][$"На внутренней стороне ладони"]
                    [$"Indication"][@$"RGB LED
                                       For LED signals see table below TODO"]
                    [$"Dimensions"][$"{Dimensions} мм"]
                    [$"Weight"][$"{Weight} г"]
                ]
            ]

            [new Section("LED signals") 
                [IndicationTable_ru]
            ]

        ;
}