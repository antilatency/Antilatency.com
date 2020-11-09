using Csml;
public partial class Software : Scope {
    public partial class AntilatencyService : Scope{
        public partial class Placements{

    public static Material Material_ru => new Material("Placements",
    Title,
    $"Инструмент {AntilatencyService.Material} для настройки расположения трекера Antilatency на VR устройствах. Вы можете использовать предустановленные решения для популярных моделей шлемов виртуальной реальности или создать собственный проект.")

    [$"Принцип работы с вкладкой Placements такой же, как и с {AntilatencyService.Environments.Material}. Здесь вы можете добавить настройки расположения модуля {Hardware.Alt} на VR устройстве, выбрать позицию трекера по умолчанию или отправить свой проект другому пользователю в виде ссылки."]
            [PlacementsTabScreenshot]
            [new Info($"Подробнее о создании пользовательских настроек расположения трекера Alt читайте тут: \n{Tutorials.Alt_HMD_Placement}")]
        ;
        }
    }
}