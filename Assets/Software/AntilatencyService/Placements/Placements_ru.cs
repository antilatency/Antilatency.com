using Csml;
public partial class Software : Scope {
    public partial class AntilatencyService : Scope{
        public partial class Placements{

    public static Material Material_ru => new Material("Placements",
    PlacementsTabScreenshot,
    $"Инструмент {AntilatencyService.Material} для настройки расположения трекера Antilatency на VR устройствах. Вы можете использовать предустановленные решения для популярных моделей шлемов виртуальной реальности или создать собственный проект.")

        [new Section("Активная VR гарнитура")
           
            [$"Выбрать устройство для VR по умолчанию можно двумя способами:"]
                [new Spoiler("Set as default")
                    [SetAsDefault1]
                ]
                [new Spoiler("Долгим нажатием")
                    [SetAsDefault2]
                ]
        ]

        [new Section("Как поделиться настройками расположения")
        
            [($"Созданные вами настройки расположения трекера можно отправить другому пользователю в виде ссылки. Для этого используйте опцию \"Share\".")]

                 [new Spoiler("Share")
                     [Share]
                 ]

        ]

        [new Section("Как добавить новый проект")
            [$"Во вкладке Placements можно самостоятельно настроить расположение устройства Antilatency на VR гарнитуре или добавить проект другого пользователя через опцию \"From link\"."]
                 [new Spoiler("From link")
                     [FromLink]
                 ]

            [new Info($"Подробнее о создании пользовательских настроек расположения трекера Alt: \n{Tutorials.Alt_HMD_Placement}")]
        ]
        ;
        }
    }
}