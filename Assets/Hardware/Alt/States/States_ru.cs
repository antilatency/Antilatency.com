using System.Drawing;
using Csml;

partial class Hardware : Scope {
    partial class AltDescription : Scope {
        public static Material ColorCodes_ru => new Material("Alt: Цветовые коды", null, $"Возможные состояния {Alt}")
        [new Section($"Отображение при помощи LED")
            [$"При наличии питания {Alt}, светодиод отображает его текущее состояние. Состояния кодируются комбинацией двух признаков: цветом светодиода и пульсом светодиода."]
        ]

        [new Section("Нормальные состояния прошивки")
            [new Table("Отображение", "Описание")
                [new ColorSequenceCos(Color.Black, Color.FromArgb(0xa8, 0x00, 0xff), 1.792f)][$"*Loading* - Первое состояние {Alt} при подаче питания или перезагрузке, происходит инициализация периферии и применение настроек."]
                [new ColorSequenceCos(Color.Black, Color.FromArgb(0x7f, 0xba, 0xd9), 1.792f)][$"*Idle* - Ожидание задачи."]
                [new ColorSequenceCos(Color.Black, Color.FromArgb(0x00, 0xff, 0x00), 1.792f)][$"*Task running* - {Alt} выполняет задачу. Это может быть задача трекинга, обращение к свойствам или любая другая доступная задача."]
            ]
        ]

        [new Section("Состояние ошибки")
            [$"{Alt} может войти в состояние ошибки в случае выхода из строя электронных компонентов, отсутствия конфигурационных данных, ошибки в прошивке или неправильного использования."]
            [$"Ошибка выводится в виде повторяющейся серии цветных пульсов светодиода прямоугольной формы с паузой 2 секунды перед последующим повторением. Номер пульса обозначает номер подсистемы, в которой произошла ошибка. Цвет обозначает номер ошибки внутри подсистемы."]
            [new Table("Номер ошибки в подсистеме", "Цвет")
                [$"0"][$"Lime (0x00, 0xff, 0x00)"]
                [$"1"][$"Red (0xff, 0x00, 0x00)"]
                [$"2"][$"Blue (0x00, 0x00, 0xff)"]
                [$"3"][$"Fuchsia (0xff, 0x00 , 0xff)"]
                [$"4"][$"Yellow (0xff, 0xff , 0x00)"]
                [$"5"][$"White (0xff, 0xff , 0xff)"]
                [$"6"][$"Silver (0xc0, 0xc0 , 0xc0)"]
                [$"7"][$"Navy (0x00, 0x00 , 0x80)"]
            ]
            [new Info($"Код ошибки #0 сигнализирует об отсутствии ошибки. Все остальные коды сигнализируют о наличии ошибки.")]
        ]

         [new Section("Примеры ошибки")
            [$"Ошибка #1 в подсистеме #1"]
            [new ColorSequence()
                [Color.Green, 0.3f]
                [Color.Black, 0.3f]
                [Color.Red, 0.3f]
                [Color.Black, 0.3f]
                [Color.Green, 0.3f]
                [Color.Black, 2.0f]
            ]
        
            [$"Ошибка #3 в подсистеме #0"]
            [new ColorSequence()
                [Color.FromArgb(0xff, 0x00, 0xff), 0.3f]
                [Color.Black, 0.3f]
                [Color.Green, 0.3f]
                [Color.Black, 0.3f]
                [Color.Green, 0.3f]
                [Color.Black, 2.0f]
            ]
        
            [$"Ошибка #4 в подсистеме #2"]
            [new ColorSequence()
                [Color.Green, 0.3f]
                [Color.Black, 0.3f]
                [Color.Green, 0.3f]
                [Color.Black, 0.3f]
                [Color.FromArgb(0xff, 0xff, 0x00), 0.3f]
                [Color.Black, 2.0f]
            ]
        ]

        [new Section("Состояния загрузчика")
            [$"{Alt} находится в режиме загрузчика во время обновления прошивки, а также если прошивка отсутствует или повреждена."]
            [new Table("Отображение", "Описание")
                [new ColorSequence()
                    [Color.FromArgb(0xff, 0x00, 0x00), 1.0f]
                    [Color.FromArgb(0xff / 2, 0x00, 0x00), 1.0f]
                ][$"*Normal* - режим, сигнализирующий о готовности загрузчика к работе."]
            ]
        ];

    }
}