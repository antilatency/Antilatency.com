using Csml;
using System.Drawing;
using static Internal.Debug_Assets;

public partial class Internal : Scope {

    public static Material Debug_ru => new Material(null, AltAndUsbSocket0,
        $"На этой странице странице некоторые примеры использования движка.")
        
        
        [new Section("Grid")
            [new Grid(120,1,2,3,4)
                
            ]
        ]
        
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
            [$"`<tag>content</tag>`"]
        ]
        [new Section("Картинки")
            [$"Это AltAndUsbSocket0"]
            [AltAndUsbSocket0]
            [$"Это все картинки, имя переменной которых начинается с AltAndUsbSocket"]
            [AltAndUsbSocketAll]
            [$"Картинки без roi"]
            [ExtensionBoard]
            [$"Маленькие картинки выравниваются по центру"]
            [SmallImage]
            [Input]
        ]
        [new Section("Code")
            [$"Файл с Github целиком."]
            [AntilatencyGitHub.AntilatencyCom_Master.Program]
            [$"Csml.Program.Main()"]
            [AntilatencyGitHub.AntilatencyCom_Master.Program.GetClass("Csml", "Program").GetMethod("Main")]
        ]
        [new Section("Xml from file")
            [$"Xml код с загрузкой из файла."]
            [TestXml]
        ]
        [new Section("Json from file")
            [$"Json из файла."]
            [TestJson]
        ]

        [new Section("Lists")
            [new UnorderedList()
                [$"Раньше было доступно 33 канала. Сейчас доступен полный диапазон каналов (141 шт.) для более гибкой настройки."]
                [new Paragraph($"Вложенный {0}")[
                    new UnorderedList()
                        [$"One."]
                        [$"Ссылка {Terms.Alt}"]
                        [WikipediaCSharp]
                    ]
                ]
                [new Paragraph($"Нумерованный {0}")[
                    new OrderedList()
                        [$"One."]
                        [$"Ссылка {Terms.Alt}"]
                        [WikipediaCSharp]
                    ]
                ]
            ]
        ]
        [new Section("Tables")
            [$"Просто таблица"]
            [new Table(2)
                [$"a"][$"a"]
                [$"a"][$"a"]
            ]
            [$"Таблица с заголовком"]
            [new Table("A","B","C")
                [$"a"][$"b"][$"c"]
                [$"d"][$"e"][$"f"]
            ]
            [$"Таблица с многоуровневыми заголовками по вертикали и горизонтали"]
            [new Table(
                new Column("xA",
                    new Column("xa1"), new Column("xa2")),
                new Column("xB"),
            
                new Row("yA",
                    new Row("ya1"), new Row("ya2")),
                new Row("yB")

                )

                [$"a"][$"a"][$"b"]
                [$"a"][$"a"][$"b"]
                [$"a"][$"a"][$"b"]
            ]
        ]

        [new Section("Panels")
            [new Info()[$"Ситуации 7 и 9 - это не рабочий вариант. Работа сети в такой конфигурации будет крайне плоха из-за большого количества потерь пакетов. Но теперь девайсы не должны крэшиться."]]
            [new Warning()[$"Ситуации 7 и 9 - это не рабочий вариант. Работа сети в такой конфигурации будет крайне плоха из-за большого количества потерь пакетов. Но теперь девайсы не должны крэшиться."]]
            [new Error()[$"Ситуации 7 и 9 - это не рабочий вариант. Работа сети в такой конфигурации будет крайне плоха из-за большого количества потерь пакетов. Но теперь девайсы не должны крэшиться."]]
            [new Note()]
            [new Success()]
            [new Bug($"Bug")]
        ]
        [new Section("Section")
            [new Section("Section")
                [$"Text"]
            ]
            [new Section("Section")
                [new Section("Section")
                    [$"Text"]
                ]
            ]
        ]
        [new Section("Color Sequence")
            [new ColorSequenceCos(Color.FromArgb(255, 128, 64), Color.Blue, 1.792f)]
            [new ColorSequence()
                [Color.Red, 0.3f]
                [Color.Black, 0.3f]
                [Color.Green, 0.3f]
                [Color.Black, 0.3f]
                [Color.Red, 0.3f]
                [Color.Black, 2.3f]
            ]
        ]

        [new Section("Нормальные состояния прошивки")
            [new Table("Отображение", "Описание")
                [new ColorSequenceCos(Color.Black, Color.FromArgb(0xa8, 0x00, 0xff), 1.792f)][$"Loading - Первое состояние {Terms.Alt} при подаче питания или перезагрузке, происходит инициализация периферии и применение настроек."]
                [new ColorSequenceCos(Color.Black, Color.FromArgb(0x7f, 0xba, 0xd9), 1.792f)][$"Idle - Ожидание задачи."]
                [new ColorSequenceCos(Color.Black, Color.FromArgb(0x00, 0xff, 0x00), 1.792f)][$"Task running - {Terms.Alt} выполняет задачу. Это может быть задача трекинга, обращение к свойствам или любая другая доступная задача."]
            ]
        ]
        [new Section("Modify")
            [new Modify(
                new Collection(false)
                    [new Modify($"public interface").Wrap("span").AddClasses("keyword")]
                    [$" "]
                    [new Modify(Api.Antilatency.DeviceNetwork.ILibrary.NameRef).AddClasses("typename")]
                    ["{\n".ToFormattableString()]
                    [new Modify($"bool isSupported(INetwork network, NodeHandle node);").Wrap("span").AddClasses("method")]
                ).Wrap("pre").Wrap("div").AddClasses("code")
            ]
            [$"{Api.Interface} {Api.Type(Api.Antilatency.DeviceNetwork.ILibrary.NameRef)} "]
            [$"*interface* {Api.Antilatency.DeviceNetwork.ILibrary.NameRef} {{\n\t_bool_ `isSupported`({Api.Antilatency.DeviceNetwork.NameRef} network, {Api.Antilatency.DeviceNetwork.NodeHandle.NameRef} node);\n}}"]

            [new Modify($"{new Modify($"public interface").Wrap("span").AddClasses("keyword")} {new Modify(Api.Antilatency.DeviceNetwork.ILibrary.NameRef).AddClasses("typename")}").Wrap("pre").Wrap("div").AddClasses("code")
            
            ]
        ]
        [new Section("Api")
            [$"Указать ссылку на метод можно несколькими способами"]
            [new UnorderedList()
                [new Modify(Api.Antilatency.DeviceNetwork.ILibrary.Methods.createNetwork.FullNameRef).ContentReplace($"link").Tag("span")]
                [$"Полное имя {Api.Antilatency.DeviceNetwork.ILibrary.Methods.createNetwork.FullNameRef}"]
                [$"Имя {Api.Antilatency.DeviceNetwork.ILibrary.Methods.createNetwork.NameRef}"]
                [$"При указании в тексте следует оборачивать в code `{Api.Antilatency.DeviceNetwork.ILibrary.Methods.createNetwork.NameRef}`"]
            ]
        ]
        ;

    

}