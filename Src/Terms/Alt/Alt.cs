using Csml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static Csml.Utils.Static;



partial class Root {


    MultiLanguageGroup Alt => new MultiLanguageGroup();

    Image AltAndUsbSocket0 => new Image("./AltAndUsbSocket0.jpg");
    Image AltAndUsbSocket1 => new Image("./AltAndUsbSocket1.jpg");
    Image AltAndUsbSocket2 => new Image("./AltAndUsbSocket2.jpg");

    //List<Image> AllImages => Directory.GetFiles(ThisDirectory(), "*.jpg").Select(x => new Image(x)).ToList();
    List<Image> AltAndUsbSocketAll => GetType().GetPropertiesAll()
        .Where(x => x.PropertyType == typeof(Image))
        .Where(x => x.Name.StartsWith("AltAndUsbSocket"))
        .Select(x => x.GetValue(this) as Image).ToList();

    public Material Alt_ru => new Material(null, AltAndUsbSocket0,
        $"На этой странице пока побудут некоторые примеры использования движка.")
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
            [new GitHubCode()]
        ]
        ;

}