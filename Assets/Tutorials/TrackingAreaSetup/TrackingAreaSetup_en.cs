using Csml;
using static Tutorials.Tracking_Area_Setup_Assets;

partial class Tutorials : Scope {

    public static Material Tracking_Area_Setup_en => new Material("Сборка напольного сетапа зоны трекинга",
     TitleImage, 
     @$"Пошаговая инструкция, которая поможет собрать напольный сетап зоны трекинга.
     Данный туториал предполагает, что у вас есть готовый {Terms.Environment} для зоны трекинга, и что этот {Terms.Environment} у вас добавлен в {Software.Antilatency_Service}. 
     По добавлению готовых {Terms.Environment} в {Software.Antilatency_Service} см. {new ToDo("Add tutorial Работа с Environment в AntilatencyService", false, true)} Работа с Environment в AntilatencyService. 
     Если вам еще только нужно создать Environment, см. {new ToDo("Add tutorial Туториал по созданию Environment", false, true)}Туториал по созданию Environment. 
     ")

        [new Section("Схема разводки зоны")
            [$"Откройте вкладку Environments в {Software.Antilatency_Service} и выберите нужную зону трекинга. Кликните правой кнопкой на нужную зону и нажмите “Edit” в контекстном меню."]
            [AntilatencyServiceScreen]
            [$"Откроется экран с выбранной зоной. Перейдите во вкладку Routing."]
            [EnvironmentEditorSelectRouting]
            [@$"Если схема разводки для зоны уже была создана ранее, вы увидите ее на экране. 
                В этом случае можете сразу переходить к секции Сборка зоны по готовой схеме разводки.



                Если схема еще не готова, см. секцию Генерация схемы разводки зоны."]
            [RoutingScreen]
            [$"Обязательно соблюдайте направление лент на схеме при сборке зоны. Ориентируйтесь на расположение маркеров на каждой ленте."]
            [ConnectionScheme]
            [$"После присоединения лент друг к другу, свертесь еще раз со схемой. Перед тем как покрывать ленты коврами, советуем подключить блоки питания и проверить правильность подключения. Все маркеры должны гореть зеленым цветом. Если подключение корректно, отключите блоки питания и покройте зону защитными коврами."]
        ];
} 