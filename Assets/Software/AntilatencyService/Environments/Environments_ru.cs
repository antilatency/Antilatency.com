using Csml;
public partial class Software : Scope {
    public partial class AntilatencyService : Scope{
        public partial class Environments{

    public static Material Material_ru => new Material("Environments",
    EnvironmentsTabScreenshot,
    $"Инструмент {AntilatencyService.Material} для управления зонами трекинга. С его помощью можно не только создать или загрузить зону, но также посмотреть её характеристики, проверить качество трекинга и настроить параметры, используя редактор зон трекинга.")

     [new Info($"Подробнее о том, как собрать зону трекинга: \n{Tutorials.Devkit_Tracking_Area_Setup}")]

     
     [new Section("Зона трекинга по умолчанию")

        [($"Выбрать зону трекинга по умолчанию можно двумя способами. \nИспользуя опцию \"*Set as default*\"...")]
        [SetAsDefault1]
        
        [$"... или *долгим нажатием*."]
        [SetAsDefault2]
         
     ]

/* [new Section("Ссылка на зону трекинга")
   [$"Информацию о зоне трекинга можно передать другому"]
    http://www.antilatency.com/antilatencyservice/environment?data=AAVSaWdpZE8BBnllbGxvdwgIuFOJP9xGoD6vjmO9mpmZPgAAAAAAAAAAAJqZGT8NBQAEAwAGAwYCBAIDAAUHBgQDAwUAAAIHBgcGBwYHBwIHAgcGAgMDdzk%name=DevKitX         data и name setAsDefault(установить по умолчанию), и silent(добавить, не открывая диалога). Оба типа bool, то есть setAsDefault=true%silent=true, например.

         [($"Настройки зоны трекинга можно отправить другому пользователю в виде ссылки, используя опцию \"Share\".")]
                [Share]
     ]

    [new Section("Как добавить зону трекинга")
       [$"С помощью вкладки Environments можно создать новую зону трекинга или добавить проект другого пользователя, используя опцию /\"From link\"."]
             [FromLink]
            
    ]*/
     [new Info($"Подробнее о том, как собрать зону трекинга: \n{Tutorials.Devkit_Tracking_Area_Setup}")]

   /* [new Section("Качество зоны трекинга")
    [$"Используя встроенный в {AntilatencyService.Material} редактор зон трекинга, можно посмотреть и настроить качество выбранной зоны. Для правильной работы трекинга важно плотное и равномерное расположение /фич. Фича - это уникальная комбинация баров, благодаря которой {Hardware.Alt} определяет своё положение в пространстве. \nЧтобы увидеть, равномерно ли распределены фичи в конкретной зоне, зайдите в редактор и выберите режим отображения \"Visibility\"."]
      [new Spoiler("Visibility")
         [$"*Круговая диаграмма в центре* - ожидаемое качество трекинга"]
         [$"*Зелёные дуги у границы клетки* - число видимых фич"]
                [VisibilityViewMode]
            ]
   [$"Чтобы увидеть расположение фич, зажмите кнопку \"Show features\" в любом из режимов отображения."]
       [new Spoiler("Show features")
             [ShowFeatures]
         ]
   
   [new Info($"Подробнее о создании и редактировании зон трекинга можно почитать тут: \n{Tutorials.Environment_Editor}")]
    ]*/

       ;
        }
    }
}