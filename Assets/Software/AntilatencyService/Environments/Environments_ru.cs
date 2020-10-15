using Csml;
public partial class Software : Scope {
    public partial class AntilatencyService : Scope{
        public partial class Environments{

    public static Material Material_ru => new Material("Environments",
    EnvironmentsTabScreenshot,
    $"Инструмент для управления зонами трекинга. С его помощью можно не только создать или загрузить зону, но также посмотреть её характеристики, проверить качество трекинга и настроить параметры, используя редактор зон трекинга.")
     
     [($"Сразу после установки в {AntilatencyService.Material} доступны настройки для стандартного DevKit и 3 расширенных комплектов.")]

     [new Info($"Подробнее о том, какие бывают зоны трекинга и как собрать DevKit: \n{Tutorials.Devkit_Tracking_Area_Setup}")]

     
     [new Section("Активная зона трекинга")

         [($"Выбрать зону трекинга по умолчанию можно двумя способами:")]

         [new Spoiler("Set as default")
         [SetAsDefault1]
         ]
        
         [new Spoiler("Долгим нажатием")
         [SetAsDefault2]
         ]
         
     ]

    [new Section("Как поделиться зоной трекинга")

        [($"Настройки зоны трекинга можно отправить другому пользователю в виде ссылки, используя опцию \"Share\".")]
            [new Spoiler("Share")
                [Share]
            ]
     ]

    [new Section("Как добавить зону трекинга")
        [$"С помощью вкладки Environments можно создать новую зону трекинга или добавить проект другого пользователя, используя опцию \"From link\"."]
       // [new Success($"User needs to get a link first")]
            [new Spoiler("From link")
                 [FromLink]
            ]
    ]

    [new Section("Качество зоны трекинга")
    [$"Используя встроенный в {AntilatencyService.Material} редактор зон трекинга, можно посмотреть и настроить качество выбранной зоны. Для правильной работы трекинга важно плотное и равномерное расположение фич. Фича - это уникальная комбинация баров, благодаря которой {Hardware.Alt} определяет своё положение в пространстве. \nЧтобы увидеть, равномерно ли распределены фичи в конкретной зоне, зайдите в редактор и выберите режим отображения \"Visibility\"."]
            [new Spoiler("Visibility")
           // [new UnorderedList()
            [$"*Круговая диаграмма в центре* - ожидаемое качество трекинга"]
            [$"*Зелёные дуги у границы клетки* - число видимых фич"]
            //]
                 [VisibilityViewMode]
            ]
    [$"Чтобы увидеть расположение фич, зажмите кнопку \"Show features\" в любом из режимов отображения."]
            [new Spoiler("Show features")
                 [ShowFeatures]
            ]
    
    [new Info($"Подробнее о создании и редактировании зон трекинга можно почитать тут: \n{Tutorials.Environment_Editor}")]
    ]

       ;
        }
    }
}