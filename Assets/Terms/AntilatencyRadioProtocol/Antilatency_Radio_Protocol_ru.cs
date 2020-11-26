using Csml;
using static Terms.Antilatency_Radio_Protocol_Assets;

partial class Terms : Scope {
    public static Material Antilatency_Radio_Protocol_ru => new Material(null, null,
    $"Устройства Antilatency могут передавать данные через проприетарный радиопротокол, который работает на частоте 2.4ГГц. Радиопротокол оптимизирован для работы в режиме реального времени и имеет низкую задержку при передаче данных.")

        [$"{Terms.Socket}, в зависимости от конфигурации, может выполнять роль клиента или точки доступа. Клиент передаёт по радиопротоколу данные точке доступа. Например, данные трекинга, полученные с модуля Alt. Точка доступа собирает данные со всех подключённых клиентов, добавляет к ним свои и отправляет эту информацию на Host через USB."]
        [new Info($"Подробнее о свойствах клиента и точки доступа, а также о конфигурации устройств читайте тут: {Tutorials.ConfiguringRadioDevices}")]

        [new Section("Доступные каналы", "channels")

            [$"Радиопротокол Antilatency поддерживает 141 радиоканал в диапазоне 2360-2500 MHz. Вы можете работать с любым из них."]

            [new Warning($"В ряде стран для использования некоторых каналов из указанного диапазона нужна лицензия (например, 2360-2400 MHz, 2488-2500 MHz). Рекомендуем заранее уточнить условия использования выбранного радиоканала в вашей стране.")]

            [$"По умолчанию, клиент и точка доступа работают на одном из пяти каналов:"]

            [new UnorderedList()
                [$"42 = 2402 MHz"]
                [$"66 = 2426 MHz"]
                [$"92 = 2452 MHz"]
                [$"114 = 2474 MHz"]
                [$"120 = 2480 MHz"]
            ]

            [RadioChannelsImage]
            [new Info()
                [$"Когда точка доступа занимает один из каналов, отображенных на схеме выше, светодиод на устройстве загорается соответствующим этому каналу цветом. Например, при подключении к 42 каналу, светодиод загорится синим."]
            ]

            [$"Стабильная передача данных точке доступа от клиента напрямую зависит от расстояния между устройствами, наличия препятствий между ними и радиошума на выбранном канале. Если радиосвязь нестабильная, часть пакетов данных не будет достигать точки доступа. В таком случае, перезапустится {Terms.Task} на {Hardware.Alt}, закреплённом на клиенте."]
        ]

        [new Section("Несколько клиентов - одна точка доступа ")
            [@$"К одной точке доступа можно подключить несколько устройств. В таком случае, пропускная способность радиоканала точки доступа будет делиться между всеми подключёнными клиентами.
            Общая пропускная способность радиоканала составляет `1.6Mбит/с`. Поэтому, если к одной точке доступа подключить три устройства, то пропускная способность для каждого клиента будет `0.53 Mбит/с`." 
            ]
            [new Warning($"Мы рекомендуем подключать к одной точке доступа не более 4 клиентов.")]
        ]

        [new Section("Несколько активных точек доступа в одном помещении")
            [$"Вы можете разместить несколько точек доступа в одном помещении, каждая из которых будет работать на отдельном радиоканале. Более того, они могут быть подключены к одному Host."]
            [MultipleChannelsImage]
            [$"При организации работы нескольких точек доступа в пределах одного помещения важно учитывать:"]
            [new UnorderedList()
                [@$"*внешние факторы*
                    Конфигурация WiFi сетей в помещении может влиять на качество работы радиоустройств.
                    Перед выбором радиоканалов мы рекомендуем просканировать диапазон 2.4 ГГц в помещении с помощью {Software.RadioScan} или аналогичной программы.
                {new Info()[$"Желательно, чтобы WiFi устройства в помещении были настроены на частоту 5 ГГц."]}"]

                [@$"*расстояние между используемыми каналами*
                    Чем ближе друг к другу каналы, установленные для разных точках доступа, тем сильнее устройства мешают друг другу.
                    Дистанция в 6 каналов обеспечивает почти полное отсутствие помех на расстоянии в полметра между точками доступа. 
                    На меньшей дистанции стабильность передачи данных может ухудшаться, если к одной точке доступа подключено много клиентов.
                "]
                
                [@$"*физическое расстояние между точками доступа*
                    Мы рекомендуем располагать точки доступа на расстоянии не менее чем `0.5 метров` друг от друга.
                "]            
            ]
        ]
    ;
    


}