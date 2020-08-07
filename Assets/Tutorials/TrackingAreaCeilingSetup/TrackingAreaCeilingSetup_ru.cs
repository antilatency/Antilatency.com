using Csml;

partial class Tutorials : Scope {

    public static Material TrackingAreaCeilingSetup_ru => new Material("Сборка потолочного сетапа зоны трекинга",
     TrackingAreaCeilingSetup_Assets.TrackingAreaCeilingSetup0, 
     @$"Потолочный сетап поставляется компанией Antilatency в виде отдельных маркеров.
        Монтаж потолочной системы, а также проведение электротехнических работ по подведению питания к маркерам осуществляется на стороне заказчика.
        Ниже приведена инструкция по установке потолочного сетапа.
     ")

        [new Section("Материалы для монтажа")
            [$"Для установки потолочного сетапа понадобятся следующие компоненты:"]
            [new UnorderedList()
                [$"потолочные маркеры от Antilatency"]
            ]
            [TrackingAreaCeilingSetup_Assets.CeilingMarkerView]
            [new UnorderedList()
                [$"подвесная потолочная система с потолочными плитками (например, система Армстронг)"]
            ]
            [TrackingAreaCeilingSetup_Assets.GridSystemView]
            [new UnorderedList()
                [@$"соединительные провода.
                    Требования к проводам: для соединения маркеров необходимо использовать медные провода с проводником 1мм2 (17 AVG).
                "]
            ]
            [new Info()
                [$"Перед подключением проводов к маркерам, концы проводов рекомендуется обжать наконечниками, подобными тем что показаны на картинке."]
            ]
            [TrackingAreaCeilingSetup_Assets.WiresEnds]          
            [new UnorderedList()
                [@$"блок питания.
                    Требования к блоку питания: блок питания должен иметь выходное напряжение 18 вольт.
                    Пример рекомендуемого блока питания: {new ExternalReference("https://www.meanwell.com/webapp/product/search.aspx?prod=rps-400", "Meanwell RPS-400-18 ")} 
                "]
            ]
            [new Warning()
                [$"Выходной ток блока питания должен быть рассчитан исходя из формулы N*0.06*3, где N - количество маркеров."]
            ]
        ]

        [new Section("Подготовка потолочных плиток и нарезание отверстий")
            [$"Маркеры устанавливаются в отверстия потолочных плиток, предварительно нарезанных перед монтажом. Корпуса потолочных маркеров имеют ободок, благодаря которому маркер держится в отверстии потолочной плитки."]
            [new Warning()
                [$"Чем точнее нарезаны отверстия в потолочных плитках, тем точнее будет работать система трекинга. Неточности при нарезании отверстий повлекут неточности в работе системы трекинга."]
            ]
            [new Info()
                [$"Строго рекомендуется нарезать отверстия в потолочных плитках на лазерном станке по чертежам, представленным в данном разделе. Лазерный станок - это стандартное оборудование, используемое рекламно-производственными компаниями. Вы можете воспользоваться услугами таких компаний в своем городе для нарезания отверстий."]
            ]

            [@$"Как правило, стандартный шаг потолочной системы равен 60 см. (см. TODO рисунок по потолочной системе).
                Стандартная схема IR раскладки в AntilatencyService предполагает, что шаг равен 60 см. Если шаг отличается, то необходимо будет изменить параметры в AntilatencyService.
            "]

            [@$"Воспользуйтесь чертежами для нарезания отверстий в потолочных плитках.
                Все размеры в чертежах заданы от центра плитки. Это позволяет использовать чертежи не только для плиток потолочной системы с шагом 60 см, но и для систем с другим шагом. 
            "]
            [@$"Чтобы посчитать количество плиток, в которых нужно нарезать отверстия, воспользуйтесь схемой IR раскладки для своего помещения.
	            Например, для помещения IR раскладки, приведенной на рисунке, необходимо подготовить Х потолочных плиток с 1 отверстием и Х потолочных плиток с 2 отверстиями.
            "]
        ]

        [new Section("Подключение маркеров")
            [$"Провода питания подключаются к одному маркеру согласно схеме:"]
            [TrackingAreaCeilingSetup_Assets.CeilingMarkerPinOut]
            [$"Маркеры подключаются к блоку питания последовательно, выстраиваясь в цепочку.. Схема подключения цепочки маркеров:"]
            [TrackingAreaCeilingSetup_Assets.MarkerChainMax]
            [new Warning()
                [$"В одну цепочку рекомендуется соединять не более 27 маркеров."]
            ]
            [@$"Если требуется подключить большее количество маркеров чем 27, то следует собрать несколько цепочек. При этом все цепочки могут быть подключены к одному блоку питания, если параметры блока питания позволяют.
                TODO (Показать на схеме примеры цепочек: так правильно, так неправильно) 
            "]
            [new Info()
                [$"После подключения цепочки маркеров к блоку питания рекомендуется измерить с помощью мультиметра напряжение на входе первого маркера цепочки и на выходе последнего маркера в цепочке. Падение напряжения для цепочки в 27 маркеров не должно превышать ХХ В. Если падение напряжения больше указанного порога, проверьте качество подключения проводов в цепочке."]
            ]
        ]
        
        [new Section("Конфигурация потолочного сетапа в AntilatencyService")
            [$"Для сборки потолочного сетапа воспользуйтесь схемой из AntilatencyService. (TODO скрин)"]
            [new Warning()
                [$"Схема имеет вид, как будто мы смотрим на нее из-под потолка сверху вниз."]
            ]
            [$"В параметрах Environment в AntilatencyService указывается высота потолка. ({new ToDo("скрин")} )"]
            [$"Убедитесь, что шаг потолочной системы составляет 60 см, и если шаг отличается, то надо поменять параметры в AntilatencyService. (TODO скрин)"]
        ]

        [new Section("Этапы сборки потолочного сетапа")
            [$"Таким образом, основные этапы сборки потолочного сетапа выглядят следующим образом:"]
            [new OrderedList()
                [$"Монтаж направляющих потолочной системы."]
                [$"Расчет количества потолочных плиток для нарезания отверстий в соответствии со схемой IR раскладки."]
                [$"Нарезание отверстий в потолочных плитках на лазерном станке в соответствии с чертежами."]
                [$"Установка потолочных плиток."]
                [$"Установка маркеров в потолочные плитки и их проведение электротехнических работ по подключению маркеров к блоку питания."]
            ]
        ]
        
        ;

} 