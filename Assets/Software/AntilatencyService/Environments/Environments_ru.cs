using Csml;
public partial class Software : Scope {
    public partial class AntilatencyService : Scope{
        public partial class Environments{

    public static Material Material_ru => new Material("Environments",null,$"Инструмент для настройки зон трекинга. Во вкладке Environments можно создать или загрузить зону, проверить её качество и отредактировать параметры.")
     
     [($"По умолчанию в {AntilatencyService.Material} доступны стандартный DevKit и 3 расширенных комплекта.")]
     [new Info($"Подробнее о том, какие бывают зоны трекинга и как собрать DevKit: \n{Tutorials.Devkit_Tracking_Area_Setup}")]

     
     [new Section("Активная зона трекинга")
         [($"Выбрать зону трекинга по умолчанию можно двумя способами:")]
         [($"*Способ 1.*")]
         [SetAsDefault1]
         [($"*Способ 2.*")]
         [SetAsDefault2]
         //tan -- add animation(?)
     ]

    //[new Section("Как поделиться зоной трекинга")
    //      [($"Чтобы отправить настройки зоны трекинга другому пользователю, нажмите на троеточие возле названия зоны и выберите пункт \"Share\".")]
    //      
    // ]

    // [new Section("Как добавить новую зону трекинга")]
    //     [$"*Шаг 1.* Чтобы загрузить настройки новой зоны трекинга в программу, нажмите на \"+\" в нижней части экрана."]
    //        
    //     [($"*Шаг 2.* Во всплывающем меню выберите пункт \"From link\".")]
    //         
    //    [($"*Шаг 3. ")]

    //[new Info($"Подробнее о создании и редактировании зон трекинга: {Tutorials.Environment_Editor}")]




    // [new Section("Качество зоны трекинга")]

       ;
        }
    }
}