using Csml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


partial class Terms: Scope {

    static Image AltAndUsbSocket0 => new Image("./AltAndUsbSocket0.jpg");
    static Image AltAndUsbSocket1 => new Image("./AltAndUsbSocket1.jpg");
    static Image AltAndUsbSocket2 => new Image("./AltAndUsbSocket2.jpg");

    //List<Image> AllImages => Directory.GetFiles(ThisDirectory(), "*.jpg").Select(x => new Image(x)).ToList();
    static List<Image> AltAndUsbSocketAll => ThisType.GetPropertiesAll()
        .Where(x => x.PropertyType == typeof(Image))
        .Where(x => x.Name.StartsWith("AltAndUsbSocket"))
        .Select(x => x.GetValue(null) as Image).ToList();


    public static Material Alt_ru => new Material(null, AltAndUsbSocket0,
        $"На этой странице странице пока побудут некоторые примеры использования движка.")
        [new Section("<-Ссылки на секции")
            [$"Оказывается даже такие ссылки валидные, но так делать не нужно"]
        ]
        [new Section("Ссылки")
            [$"Можно вставлять {Alt} в текст"]
            [$"Если навести на ссылку, то в подсказке будет описание страницы. Это полезно для терминов."]
        ]
        [new Section("Картинки")
            [$"Это AltAndUsbSocket0"]
            [AltAndUsbSocket0]
            [$"Это все картинки, имя переменной которых начинается с AltAndUsbSocket"]
            [AltAndUsbSocketAll]
        ]
        [new Section("Code")
            [$"Файл с Github целиком."]
            [AntilatencyGitHub.AntilatencyCom_Master.Program]
            [$"Csml.Program.Main()"]
            [AntilatencyGitHub.AntilatencyCom_Master.Program.GetClass("Csml", "Program").GetMethod("Main")]
        ]
        [new Section("Api")
            //[$"{Api.Antilatency.Alt.Tracking._Material}"]
        ]
        ;

}

/*
public sealed partial class Api : Scope<Api>{

    public sealed partial class Antilatency : Scope<Antilatency> {

        public sealed partial class Tracking : Scope<Tracking> {
            public static MultiLanguageGroup _Material => new MultiLanguageGroup("Antilatency.Tracking");
            public static Material _Material_en => new Material(_Material.Title, null, $"Namespace");

            public sealed partial class ILibrary : Scope<ILibrary> {
                public static MultiLanguageGroup _Material => new MultiLanguageGroup("Antilatency.Tracking.ILibrary");//TODO: user defined title
                private static Material _Material_en => new Material(_Material.Title, null, $"");

                public sealed partial class createEnvironment : Scope<createEnvironment> {
                    public static MultiLanguageGroup _Material => new MultiLanguageGroup("Antilatency.\u200BTracking.\u200BILibrary.\u200BcreateEnvironment");//TODO: user defined title
                    private static Material _Material_en => new Material(_Material.Title, null, $"Method");
                }
            }
        }
    }
}

partial class Api {
    partial class Antilatency {
        partial class Tracking {
            partial class ILibrary {
                partial class createEnvironment { 
                
                }
            }
        }
    }
}*/
