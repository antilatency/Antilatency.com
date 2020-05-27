﻿using Csml;
using static Software.Antilatency_Hardware_Extension_Interface_Library_Assets;
using static Api.Antilatency.HardwareExtensionInterface;

partial class Software : Scope {
    

    static Material Antilatency_Hardware_Extension_Interface_Library_ru => new Material(null, null,
    $"Библиотека для {Terms.Antilatency_Hardware_Extension_Interface}")
        [new Section("Использование библиотеки")
            [new OrderedList()
                [$"Загрузка библиотеки."]
                [$"Получение {ILibrary.NameRefCode}."]
                [$"Получение {ICotaskConstructor.NameRefCode}, с помощю {ILibrary.Methods.getCotaskConstructor.NameRefCode}."]
                [$"Запуск таска с помощью {ICotaskConstructor.Methods.startTask.NameRefCode}"]
                [$"Декларирование режимов работы нужных пинов, вызывая методы {new UnorderedList()[createPinMethods]}"]
                [$"Перевод таска в режим *Run* с помощью {ICotask.Methods.run.NameRefCode}."]
                [$"Работа с полученными ранее интерфейсами({IInputPin.NameRefCode}, {IOutputPin.NameRefCode} и т.д.)"]
            ]
        ]

        [new Section("IInputPin")
            [IInputPin.CodeBlock]
            [IInputPinCode]// <- delete variables
            [$"`getState()` возвращает актуальное состояние пина(изменяется не чаще, чем раз в 5мс)."]
        ]

        [new Section("IOutputPin")
            [IOutputPinCode]
            [$"`getState()` возвращает последние состояние, модифицированное с помощью `setState()`(запрос на устройство не отправляется)."]
            [$"`setState()` отправляет устройству запрос на изменение состояния пина. Кидает исключение, если не удалось отправить запрос."]
        ]

        [new Section("IAnalogPin")
            [IAnalogPinCode]
            [$"`getValue()` возвращает актуальное напряжение на пине в вольтах."]
        ]

        [new Section("IPulseCounterPin")
            [IPulseCounterPinCode]
            [$"`getValue()` возвращает количество импульсов за последний период."]
        ]

        [new Section("IPwmPin")
            [IPwmPinCode]
            [$"`setDuty()` отправляет устройству запрос на изменение скважности ШИМ сигнала. Кидает исключение, если не удалось отправить запрос."]
            [$"`getDuty()` возвращает текущую скважность ШИМ сигнала.(без запроса к устройству)"]
            [$"`getFrequency()` возвращает актуальную частоту ШИМ сигнала."]
            [$"Для более высокой частоты `duty` будет иметь больше градаций. Но сама частота может быть установлена менее точно(для некоторых значений). Частоты из ряда 20, 100, 500, 1000, 2000, 5000, 10000 герц будут установлены со 100% точностью. Узнать реальную частоту и скважность можно с помощью `getFrequency()` и `getDuty()` соответственно."]
        ]

        [new Info()[$"До перехода таска в состояние *Run* все методы данных интерфейсов будут возвращать значение по умолчанию."]
        ]

        [new Section("ICotask")
            [ICotaskCode]
            [new Info()[$"Методы по созданию пинов только формируют таблицу инициализации, которая будет отправлена на устройство в методе `run()`."]]
            [$"Сразу после запуска таск находится в состоянии *Init*. Только в этом состоянии работают методы по созданию пинов."]
            [$"`createInputPin()` создаёт пин в режиме входа."]
            [$"`createOutputPin()` создаёт пин в режиме выхода. Необходимо указать состояние, которое примет пин сразу после инициализации."]
            [$"{ICotask.Methods.createAnalogPin.NameRefCode} создаёт пин в режиме аналогового входа."]
            [$"{ICotask.Methods.createAnalogPin.Parameters.refreshIntervalMs.NameCode} - время(в миллисекундах) обновления значение. Значение должно быть в диапазоне{Constants.Fields.AnalogMinRefreshIntervalMs.NameCode}..{Constants.Fields.AnalogMaxRefreshIntervalMs.NameCode} См. {Constants.NameRefCode}"]
            [$"`createPulseCounterPin()` создаёт пин в режиме счетчика импульсов. `refreshIntervalMs` - время(в миллисекундах) обновления значение. *Todo add from api* См. Constants::PulseCounterMinRefreshIntervalMs и Constants::PulseCounterMaxRefreshIntervalMs."]
            [new Info()[$"На текущий момент поддерживается только одинаковое время обновления для двух пинов в режиме счетчика импульсов."]]
            [$"`createPwmPin()` создаёт пин в режиме ШИМ выхода.`frequency` - частота сигнала в герцах *Todo add from api* См. Constants::PwmMinFrequency и Constants::PwmMaxFrequency. `initialDuty` - скважность ШИМ сигнала сразу после инициализации в интервале [0;1]."]
            [new Info()[$"Частота для всех ШИМ пинов должна быть одинаковая."]]
            [$"Причины исключений, которые могут быть кинуты в методах создания пинов:"]
            [new OrderedList()
                [$"Был уже вызван метод run()."]
                [$"Указанный пин уже используется."]
                [$"Указанный пин не поддерживает требуемый режим."]
                [$"Refresh interval/frequency не входит в допустимый диапазон(см. Constants)."]
                [$"Уже создано максимальное количество пинов данного типа."]
                [$"Указаны разные refresh interval для пинов в режиме счетчика импульсов или frequency для ШИМ пинов."]]
            [$"`run()` отправляет на устройство сформированную таблицу инициализации и ждёт подтверждения. Таск переходит в режим *Run*. Гарантируется, что после выхода из метода, будут получены актуальные состояния всех пинов в режиме входа и аналогового входа, а также установлены начальные состояния всех пинов в режиме выхода."]
            [$"После перехода в режим *Run* можно пользоваться необходимыми методами из полученных ранее интерфейсов(`IInputPin`, `IOutputPin` и т.д.)."]
            [$"После завершения таска, все пины деинициализируются и переходят в высокоимпедансное состояние(Hi-Z)."]
        ]
    ;   


}