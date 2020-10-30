using Csml;
public partial class Software : Scope {
    public partial class AntilatencyService : Scope{
        public partial class Environments{

    public static Material Material_ru => new Material("Environments",
    EnvironmentsTabScreenshot,
    $"Инструмент {AntilatencyService.Material} для управления зонами трекинга. С его помощью вы можете создать или загрузить зону, посмотреть её характеристики, настроить параметры и проверить качество расположения фич, используя редактор зон трекинга.")

     [new Info($"Подробнее о том, как собрать зону трекинга: \n{Tutorials.Devkit_Tracking_Area_Setup}")]

     
     [new Section("Зона трекинга по умолчанию")

        [($"Выбрать зону трекинга по умолчанию можно двумя способами. \nИспользуя опцию \"*Set as default*\"...")]
        [SetAsDefault1]
        
        [$"... или *долгим нажатием*."]
        [SetAsDefault2]
         
     ]

     [new Section("Ссылка на зону трекинга","tracking_area_link")
        [$"Данные зоны трекинга вы можете отправить другому пользователю в виде ссылки."]
        
            [$"`http://www.antilatency.com/antilatencyservice/environment?`*data*`=AAVSaWdpZE8BBnllbGxvdwgIuFOJP9xGoD6vjmO9mpmZPgAAAAAAAAAAAJqZGT8NBQAEAwAGAwYCBAIDAAUHBgQDAwUAAAIHBgcGBwYHBwIHAgcGAgMDdzk&`*name*`=DevKitX&`*setAsDefault*`=true&`*silent*`=true`"]
            [$"\nСсылка содержит несколько параметров, из которых два - data и name - обязательные."]
            [$"*data* - данные зоны трекинга; \n*name* - её название (можно изменить в редакторе); \n*setAsDefault* - автоматически назначает добавленную зону трекинга зоной по умолчанию; \n*silent* - актуально для Android; позволяет добавить зону трекинга нажатием по ссылке, не открывая окно {AntilatencyService.Material}."]
            [new Section("Как поделиться ссылкой","")]
        [$"Используя опцию \"*Share*\", скопируйте, а потом отправьте другому пользователю ссылку на зону трекинга удобным вам способом."]
        [Share]
            [new Section("Как добавить новую зону трекинга","")]
        [$"Используйте опцию \"*From link*\", чтобы добавить новый проект по ссылке."]
            [new Note($"Если вы заранее скопировали ссылку, то форма добавления зоны трекинга будет автоматически заполнена данными из буфера обмена.")]
        [FromLink]
        
        [$"\nЧтобы добавить зону трекинга на Android устройстве, используйте опцию \"From Link\" или нажмите непосредственно на ссылку. После нажатия откроется уже заполненная форма добавления новой зоны в {AntilatencyService.Material}. Если в ссылке содержится параметр *silent*, то зона трекинга будет добавлена автоматически без вызова окна приложения."]

        [$"\nВы также можете добавить зону трекинга через {new ExternalReference("https://developer.android.com/studio/command-line/adb", "adb")}. Для этого введите в командной строке `adb shell am start` и вставьте нужную ссылку."]
        [$"\n`adb shell am start http://www.antilatency.com/antilatencyservice/environment?data=AAVSaWdpZE8BBnllbGxvdwgIuFOJP9xGoD6vjmO9mpmZPgAAAAAAAAAAAJqZGT8NBQAEAwAGAwYCBAIDAAUHBgQDAwUAAAIHBgcGBwYHBwIHAgcGAgMDdzk%name=DevKitX`"]
    
   //[new Info($"Подробнее о создании и редактировании зон трекинга читайте тут: \n{Tutorials.Environment_Editor}")]
     ]
       ;
        }
    }
}
