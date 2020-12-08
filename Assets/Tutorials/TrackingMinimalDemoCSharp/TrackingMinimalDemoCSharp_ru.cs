using Csml;
using static Tutorials.TrackingMinimalDemoCSharp_Assets;

partial class Tutorials : Scope {


    public static Material TrackingMinimalDemoCSharp_ru =>    
    new Material(
        "Tracking: Консольное приложение на C#",
        TitleImage,
        $"Консольное демонстрационное приложение на C#, которое находит {Hardware.Alt}, создает {Terms.Environment}, запускает {Terms.Task} трекинга и выводит координаты в консоль.")
        [new Section("Оборудование")
            [Hardware.Alt]
        ]
        [new Section("Код")
            [AntilatencyGitHub.TrackingMinimalDemoCSharp_Master.Program]
        ]
    ;

}