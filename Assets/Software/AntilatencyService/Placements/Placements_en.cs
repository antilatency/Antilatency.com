using Csml;
public partial class Software : Scope {
    public partial class AntilatencyService : Scope{
        public partial class Placements{

    public static Material Material_en => new Material("Placements",
    PlacementsTabScreenshot,
    $"Use the {AntilatencyService.Material}'s tab to set the {Terms.Placement} of the {Hardware.Alt} for any VR gadget. You can choose whether one of the preloaded presets, or create your own configuration.")

    [$"This tab is similar to the {AntilatencyService.Environments.Material}. Here you can set the position of the {Hardware.Alt}."]
            [new Info($"Please, read here how to custom your {Terms.Placement}: \n{Tutorials.Alt_HMD_Placement}")]
            // Здесь вы можете добавить настройки расположения модуля Alt на VR устройстве, выбрать позицию трекера по умолчанию или отправить свой проект другому пользователю в виде ссылки.
        ;
        }
    }
}