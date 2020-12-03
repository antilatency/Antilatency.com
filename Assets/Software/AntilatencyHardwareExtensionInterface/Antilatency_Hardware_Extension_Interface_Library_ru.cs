using Csml;
using static Software.Antilatency_Hardware_Extension_Interface_Library_Assets;
using static Api.Antilatency.HardwareExtensionInterface;

partial class Software : Scope {
    

    public static Material Antilatency_Hardware_Extension_Interface_Library_ru => new Material(null, null,
    $"Библиотека для работы с {Terms.Antilatency_Hardware_Extension_Interface}.")
        [new Section("Использование библиотеки")
            [new OrderedList()
                [$"Загрузка библиотеки."]
                [$"Получение {ILibrary.NameRefCode}."]
                [$"Получение {ICotaskConstructor.NameRefCode} с помощью {ILibrary.Methods.getCotaskConstructor.NameRefCode}."]
                [$"Запуск {Terms.Task} через {ICotaskConstructor.Methods.startTask.NameRefCode}"]
                [$"Декларирование режимов работы нужных пинов с помощью {new UnorderedList()[createPinMethods]}"]
                [$"Перевод Task в режим {Modes.Run} с помощью метода {ICotask.Methods.run.NameRefCode}."]
                [$"Работа с полученными ранее интерфейсами({IInputPin.NameRefCode}, {IOutputPin.NameRefCode} и т.д.)"]
            ]
        ]

        [new Section("IInputPin")
            [IInputPin.CodeBlock]
            [$"{IInputPin.Methods.getState.NameRefCode} возвращает актуальное состояние пина (изменяется не чаще, чем раз в 5мс)."]
        ]

        [new Section("IOutputPin")
            [IOutputPin.CodeBlock]
            [$"{IOutputPin.Methods.setState.NameRefCode} отправляет устройству запрос на изменение состояния пина. Кидает исключение, если не удалось отправить запрос."]
            [$"{IOutputPin.Methods.getState.NameRefCode} возвращает последнее состояние, модифицированное с помощью {IOutputPin.Methods.setState.NameRefCode}. Запрос на устройство при этом не отправляется."]
        ]

        [new Section("IAnalogPin")
            [IAnalogPin.CodeBlock]
            [$"{IAnalogPin.Methods.getValue.NameRefCode} возвращает актуальное напряжение на пине в вольтах."]
        ]

        [new Section("IPulseCounterPin")
            [IPulseCounterPin.CodeBlock]
            [$"{IPulseCounterPin.Methods.getValue.NameRefCode} возвращает количество импульсов за последний период."]
        ]

        [new Section("IPwmPin")
            [IPwmPin.CodeBlock]
            [$"{IPwmPin.Methods.setDuty.NameRefCode} отправляет устройству запрос на изменение скважности ШИМ сигнала. Кидает исключение, если не удалось отправить запрос."]
            [$"{IPwmPin.Methods.getDuty.NameRefCode} возвращает текущую скважность ШИМ сигнала, не отправляя запрос на устройство."]
            [$"{IPwmPin.Methods.getFrequency.NameRefCode} возвращает актуальную частоту ШИМ сигнала."]
            [$"Для более высокой частоты `duty` будет иметь больше градаций. Но сама частота для некоторых может быть установлена менее точно. Список рекомендованных частот:"]
            [new UnorderedList()[$"20"][$"100"][$"500"][$"1000"][$"2000"][$"5000"][$"10000"]]
            [$"Узнать реальную частоту и скважность можно с помощью {IPwmPin.Methods.getFrequency.NameRefCode} и {IPwmPin.Methods.getDuty.NameRefCode} соответственно."]
        ]

        [new Info()[$"До перехода Task в состояние {Modes.Run}, все методы данных интерфейсов будут возвращать значение по умолчанию."]
        ]

        [new Section("ICotask")
            [ICotask.CodeBlock]
            [new Info()[$"Методы по созданию пинов только формируют таблицу инициализации, которая будет отправлена на устройство в методе {ICotask.Methods.run.NameRefCode}."]]
            [$"Сразу после запуска Task находится в состоянии {Modes.Init}. Только в этом состоянии работают методы по созданию пинов."]
            [$"{ICotask.Methods.createInputPin.NameRefCode} создаёт пин в режиме входа."]
            [$"{ICotask.Methods.createOutputPin.NameRefCode} создаёт пин в режиме выхода. Вам необходимо указать состояние, которое примет пин сразу после инициализации ({ICotask.Methods.createOutputPin.Parameters.initialState.NameCode})."]
            [$"{ICotask.Methods.createAnalogPin.NameRefCode} создаёт пин в режиме аналогового входа."]
            [$"{ICotask.Methods.createAnalogPin.Parameters.refreshIntervalMs.NameCode} - время обновления в миллисекундах. Значение должно быть в интервале [{Constants.Fields.AnalogMinRefreshIntervalMs.Value}..{Constants.Fields.AnalogMaxRefreshIntervalMs.Value}] См. {Constants.NameRefCode}"]
            [$"{ICotask.Methods.createPulseCounterPin.NameRefCode} создаёт пин в режиме счётчика импульсов. {ICotask.Methods.createPulseCounterPin.Parameters.refreshIntervalMs.NameCode} - время обновления в миллисекундах. Должно быть в рамках интервала [{Constants.Fields.PulseCounterMinRefreshIntervalMs.Value}..{Constants.Fields.PulseCounterMaxRefreshIntervalMs.Value}] См. {Constants.NameRefCode}"]
            [new Info()[$"Для двух пинов в режиме счётчика импульсов время обновления должно быть одинаковым."]]
            [$"{ICotask.Methods.createPwmPin.NameRefCode} создаёт пин в режиме ШИМ выхода. {ICotask.Methods.createPwmPin.Parameters.frequency.NameCode} - частота сигнала в герцах из интервала [{Constants.Fields.PwmMinFrequency.Value}..{Constants.Fields.PwmMaxFrequency.Value}]. {ICotask.Methods.createPwmPin.Parameters.initialDuty.NameCode} - скважность ШИМ сигнала сразу после инициализации в интервале [0;1]."]
            [new Info()[$"Частота для всех ШИМ пинов должна быть одинаковая."]]
            [$"Причины исключений в методах создания пинов:"]
            [new OrderedList()
                [$"Был уже вызван метод {ICotask.Methods.run.NameRefCode}."]
                [$"Указанный пин уже используется."]
                [$"Указанный пин не поддерживает требуемый режим."]
                [$"Refresh interval/frequency не входит в допустимый интервал(см. {Constants.NameRefCode})."]
                [$"Уже создано максимальное количество пинов данного типа."]
                [$"Указаны разные refresh interval для пинов в режиме счетчика импульсов или frequency для ШИМ пинов."]]
            [$"{ICotask.Methods.run.NameRefCode} отправляет на устройство сформированную таблицу инициализации и ждёт подтверждения. Таск переходит в режим {Modes.Run}. Гарантируется, что после выхода из метода, будут получены актуальные состояния всех пинов в режиме входа и аналогового входа, а также установлены начальные состояния всех пинов в режиме выхода."]
            [$"После перехода в режим {Modes.Run} можно пользоваться необходимыми методами из полученных ранее интерфейсов({IInputPin.NameRefCode}, {IOutputPin.NameRefCode} и т.д.)."]
            [$"После завершения таска, все пины деинициализируются и переходят в высокоимпедансное состояние(Hi-Z)."]
        ]
    ;   


}