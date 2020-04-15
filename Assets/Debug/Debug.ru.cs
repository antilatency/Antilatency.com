using Csml;
using static Internal.Debug_Assets;

public partial class Internal : Scope {

    public static Material Debug_ru => new Material(null, AltAndUsbSocket0,
        $"На этой странице странице пока побудут некоторые примеры использования движка.")
        [new Section("Ссылки")
            [$"Можно вставлять {Terms.Alt} в текст"]
            [$"Если навести на ссылку, то в подсказке будет описание страницы. Это полезно для терминов."]
        ]
        [new Section("Внешние ссылки")
            [new ExternalReference("https://ru.wikipedia.org/wiki/C_Sharp")]
            [$"Ссылки с текстом: {new ExternalReference("https://ru.wikipedia.org/wiki/C_Sharp", "C#")}"]
            [$"Ссылки с текстом и подсказкой: {new ExternalReference("https://ru.wikipedia.org/wiki/C_Sharp", "C#", "Статья на Wikipedia про язык C#")}"]
            [$"Контекстно-зависимые ссылки: {WikipediaCSharp}. В зависимости от языка _(aka context)_ страницы ссылка будет меняться. Так можно делать с любыми объектами движка."]
        ]
        [new Section("<-Ссылки на секции")
            [$"Оказывается даже такие ссылки валидные, но так делать не нужно"]
        ]
        [new Section("Markdown")
            [$"`code` *bold* _italic_ ~strikethrough~ ~*bold*strikethrough~ ~_*bold*italic_strikethrough~ `~_*bold*italic_strikethrough~`"]
            [$"`код со ссылкой {Debug}`"]
        ]               
        [new Section("Картинки")
            [$"Это AltAndUsbSocket0"]
            [AltAndUsbSocket0]
            [$"Это все картинки, имя переменной которых начинается с AltAndUsbSocket"]
            [AltAndUsbSocketAll]
        ]
        [new Section("Code")
            [$"Файл с Github целиком."]
            [AntilatencyGitHub.AntilatencyCom_Master.Programm]
            [$"Csml.Program.Main()"]
            [AntilatencyGitHub.AntilatencyCom_Master.Programm.GetClass("Csml", "Program").GetMethod("Main")]
        ]
        [new Section("Xml from file")
            [$"Xml код с загрузкой из файла."]
            [TestXml]
        ]
        [new Section("Json from file")
            [$"Json из файла."]
            [TestJson]
        ]
        
        [new Section("Api")
            [$"{Api.Antilatency.Alt.Tracking._Material}"]
        ]
        ;
}