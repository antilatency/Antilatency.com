using Csml;
using static Tutorials.TrackingMinimalDemoCSharp_Assets;

partial class Tutorials : Scope {

    public static Material TrackingMinimalDemoCSharp_ru =>
    
    new Material(
        "Antilatency Tracking : Минимальное приложение на C#",
        null,
        $"В этом уроке напишем минимальное консольное приложение на C#, которое: находит {Terms.Alt}, создает {Terms.Environment}, запускает {Terms.Task} трекинга и выводит координаты в консоль.")
        [new Section("Оборудование")
            [Terms.Alt]
        ]
        [new Section("Код")
            [AntilatencyGitHub.TrackingMinimalDemoCSharp_Master.Program]
        ]
    ;

}