using Csml;
public partial class Software : Scope {
    public partial class AntilatencyService : Scope{
        public partial class Environments{

    public static Material Material_ru => new Material("Environments",
    EnvironmentsTabScreenshot,
    $"Вкладка {AntilatencyService.Material} для управления зонами трекинга. Вы можете создать или загрузить новую зону трекинга, а также выбрать {Terms.Environment} по умолчанию. С помощью встроенного редактора можно настроить параметры нужного Environment, к примеру, качество расположения фич.")

     [new Info($"Подробнее о том, как собрать зону трекинга: \n{Tutorials.Devkit_Tracking_Area_Setup}")]

        [$"Данные зоны трекинга могут иметь вид ссылки. В таком формате вы можете отправить Environment другому пользователю."]
        
            [$"`http://www.antilatency.com/antilatencyservice/environment?`*data*`=AAVSaWdpZE8BBnllbGxvdwgIuFOJP9xGoD6vjmO9mpmZPgAAAAAAAAAAAJqZGT8NBQAEAwAGAwYCBAIDAAUHBgQDAwUAAAIHBgcGBwYHBwIHAgcGAgMDdzk&`*name*`=DevKitX&`*setAsDefault*`=true&`*silent*`=true`"]
            [$"\nСсылка содержит несколько параметров, из которых два - data и name - обязательные."]
            [$"*data* - данные зоны трекинга; \n*name* - её название (можно изменить в редакторе); \n*setAsDefault* - автоматически назначает добавленную зону трекинга зоной по умолчанию; \n*silent* - актуально для Android; позволяет добавить зону трекинга нажатием по ссылке, не открывая окно {AntilatencyService.Material}."]
            
        [new Section("Как добавить новый Environment","")

        [$"Используйте опцию \"*From link*\", чтобы добавить Environment в приложение."]
            [new Note($"Если вы заранее скопировали ссылку, то форма добавления зоны трекинга будет автоматически заполнена данными из буфера обмена.")]
        [FromLink]

            [new Section("Как добавить зону трекинга на Android устройстве","")

                [$"*\nЧерез AntilatencyService*"]
                     [$"Вы можете использовать опцию \"From Link\"или нажать непосредственно на ссылку. \nТогда откроется заполненная форма добавления новой зоны в {AntilatencyService.Material}. Если в ссылке содержится параметр `silent`, то Environment будет добавлен автоматически, без вызова окна приложения."]
        
                [$"*\nЧерез {new ExternalReference("https://developer.android.com/studio/command-line/adb", "adb")}*"]
        
                     [$"Ввведите в командной строке `adb shell am start` и вставьте нужную ссылку. Пример запроса может выглядеть так:"]
                     [$"\n`adb shell am start http://www.antilatency.com/antilatencyservice/environment?data=AAVSaWdpZE8BBnllbGxvdwgIuFOJP9xGoD6vjmO9mpmZPgAAAAAAAAAAAJqZGT8NBQAEAwAGAwYCBAIDAAUHBgQDAwUAAAIHBgcGBwYHBwIHAgcGAgMDdzk%name=DevKitX`"]
            ]
        ]

        [new Section("Как поделиться ссылкой","")
             [$"Используя опцию \"*Share*\", скопируйте ссылку на Environment. Теперь вы можете отправить её другому пользователю удобным для вас способом."]
                 [Share]
        ]

        [new Section("Зона трекинга по умолчанию")

             [($"Выбрать зону трекинга по умолчанию можно двумя способами. \nИспользуя опцию \"*Set as default*\"...")]
                 [SetAsDefault1]
        
             [$"\n... или *долгим нажатием*."]
                 [SetAsDefault2]
    
   //[new Info($"Подробнее о создании и редактировании зон трекинга читайте тут: \n{Tutorials.Environment_Editor}")]
     ]
       ;
        }
    }
}
