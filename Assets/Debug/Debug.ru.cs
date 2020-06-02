using Csml;
using System.Drawing;
using static Internal.Debug_Assets;

public partial class Internal : Scope {

    public static Material Debug_ru => new Material(null, AltAndUsbSocket0,
        $"На этой странице странице некоторые примеры использования движка.")        
        [new Section("ToDo")
            [$"В текст можно вставлять елемент {new ToDo("just do it later", false, true)}`new ToDo(\"text\")`"]
            [$"Параметр конструктора `suppressWarning` сделан исключительно для этого примера. Не используйте его."]
            [$"Этот элемент будет виден только если `ToDo.Enabled = true;` , например в DeveloperBuild"]
        ]
        [new ToDo("Тут должна быть секция. Чтобы текст отображался ставите `showText:true` (второй параметр)", true, true)]

        [new Section("Grid")
            [new Grid(120,1,2,3,4)
                
            ]
        ]
        
        [new Section("Ссылки")
            [$"Можно вставлять {Hardware.Alt} в текст"]
            [$"Если навести на ссылку, то в подсказке будет описание страницы. Это полезно для терминов."]
        ]
        [new Section("Внешние ссылки")
            [new ExternalReference("https://ru.wikipedia.org/wiki/C_Sharp")]
            [$"Ссылки с текстом: {new ExternalReference("https://ru.wikipedia.org/wiki/C_Sharp", "C#")}"]
            [$"Ссылки с текстом и подсказкой: {new ExternalReference("https://ru.wikipedia.org/wiki/C_Sharp", "C#", "Статья на Wikipedia про язык C#")}"]
            [$"Контекстно-зависимые ссылки: {WikipediaCSharp}. В зависимости от языка _(aka context)_ страницы ссылка будет меняться. Так можно делать с любыми объектами движка."]
        ]
        [new Section("Ссылки на секции")
            [$"Рядом с заголовком секции есть якорь (ссылка на эту секцию). По ней вы перейдете на `https://example.com/page#identifier`, где `identifier` это `id` html элемента. Для секций `id` будет создан из `title` если не указан явно."]
            [$"Если вы явно указываете `identifier`, то убедитесь что во всех переводах страницы указан такой же."]
            [new Warning($"Обратите внимание переводчика на то, что параметр `identifier` не переводится.")]
            [$"Можно вставлять в текст ссылки на секции страниц. Например `{{Debug:images}}` {Debug:images}"]
        ]
        [new Section("Секция без якоря","")
            [$"Если указать пустой `identifier` то у секции не будет добавлен якорь."]
            [$"`new Section(\"Секция без якоря\",\"\")`"]
        ]
        [new Section("Markdown")
            [$"`code` *bold* _italic_ ~strikethrough~ ~*bold*strikethrough~ ~_*bold*italic_strikethrough~ `~_*bold*italic_strikethrough~`"]
            [$"`код со ссылкой {Debug}`"]
            [$"`<tag>content</tag>`"]
        ]
        [new Section("Картинки", "images")
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
            [AntilatencyGitHub.AntilatencyCom_Master.Program.GetClass("Csml", "Application").GetMethod("Main")]
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
                [new Paragraph(@$"Вложенный {new UnorderedList()
                        [$"One."]
                        [$"Ссылка {Hardware.Alt}"]
                        [WikipediaCSharp]
                    }")
                ]
            ]
            [new Paragraph($"Нумерованный")]
            [new OrderedList()
                [$"One."]
                [$"Ссылка {Hardware.Alt}"]
                [WikipediaCSharp]
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
                [new ColorSequenceCos(Color.Black, Color.FromArgb(0xa8, 0x00, 0xff), 1.792f)][$"Loading - Первое состояние {Hardware.Alt} при подаче питания или перезагрузке, происходит инициализация периферии и применение настроек."]
                [new ColorSequenceCos(Color.Black, Color.FromArgb(0x7f, 0xba, 0xd9), 1.792f)][$"Idle - Ожидание задачи."]
                [new ColorSequenceCos(Color.Black, Color.FromArgb(0x00, 0xff, 0x00), 1.792f)][$"Task running - {Hardware.Alt} выполняет задачу. Это может быть задача трекинга, обращение к свойствам или любая другая доступная задача."]
            ]
        ]

        [new Section("Api")
            [$"Указать ссылку на метод можно несколькими способами"]
            [new UnorderedList()
                [$"Полное имя {Api.Antilatency.DeviceNetwork.ILibrary.Methods.createNetwork.FullNameRefCode}"]
                [$"Имя {Api.Antilatency.DeviceNetwork.ILibrary.Methods.createNetwork.NameRefCode}"]
            ]
        ]

        /*[new Section("Скачиваемые файлы")
            [$"Скачать папку"]
            [DownloadableFolderTest]
            [$"Скачать ту же папку, но без '.png' файлов"]
            [DownloadableFolderTestWithoutPng]
            [$"Скачать ту же папку, но без '.txt' файлов"]
            [DownloadableFolderTestWithoutTxt]
            [$"Скачать файл"]
            [DownloadableFileTest]
        ]*/
        ;

    

}