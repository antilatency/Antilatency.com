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

     [new Section("Ссылка на зону трекинга","tracking_area_link")
        [$"Данные зоны трекинга можно отправить другому пользователю в виде ссылки, которая имеет следующий вид:"]
        
            [$"`http://www.antilatency.com/antilatencyservice/environment?`*data*`=AAVSaWdpZE8BBnllbGxvdwgIuFOJP9xGoD6vjmO9mpmZPgAAAAAAAAAAAJqZGT8NBQAEAwAGAwYCBAIDAAUHBgQDAwUAAAIHBgcGBwYHBwIHAgcGAgMDdzk&`*name*`=DevKitX&`*setAsDefault*`=true&`*silent*`=true`"]
            [$"\nСсылка может содержать несколько параметров, из которых два - data и name - обязательные."]
            [$"*data* - данные зоны трекинга; \n*name* - её название (можно изменить в {AntilatencyService.Material}); \n*setAsDefault* - автоматически назначает добавленную зону трекинга зоной по умолчанию; \n*silent* - актуально для Android; позволяет добавить зону трекинга нажатием по ссылке, не открывая окно {AntilatencyService.Material}."]
            [new Section("Как поделиться ссылкой","")]
        [$"Используя опцию \"*Share*\", можно скопировать и отправить другому пользователю ссылку на зону трекинга."]
        [Share]
            [new Section("Как добавить новую зону трекинга","")]
        [$"Добавить новый проект по ссылке можно при помощи опции \"*From link*\"."]
            [new Note($"Если вы заранее скопировали ссылку, то форма добавления зоны трекинга будет автоматически заполнена данными из буфера обмена.")]
        [FromLink]
        
        [$"\nЧтобы добавить зону трекинга на Android устройстве, можно использовать опцию \"From Link\" или нажать непосредственно на ссылку. Тогда откроется уже заполненная форма добавления новой зоны в {AntilatencyService.Material}. Если в ссылке присутствует параметр *silent*, то зона трекинга будет добавлена автоматически без вызова окна приложения."]

        [$"\nВы также можете добавить зону трекинга через {new ExternalReference("https://developer.android.com/studio/command-line/adb", "adb")}. Для этого введите в командной строке `adb shell am start` и вставьте ссылку на зону."]
        [$"\n`adb shell am start http://www.antilatency.com/antilatencyservice/environment?data=AAVSaWdpZE8BBnllbGxvdwgIuFOJP9xGoD6vjmO9mpmZPgAAAAAAAAAAAJqZGT8NBQAEAwAGAwYCBAIDAAUHBgQDAwUAAAIHBgcGBwYHBwIHAgcGAgMDdzk%name=DevKitX`"]
    
   //[new Info($"Подробнее о создании и редактировании зон трекинга читайте тут: \n{Tutorials.Environment_Editor}")]
     ]
       ;
        }
    }
}
