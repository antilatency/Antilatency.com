using Csml;
using System;
using static Tutorials.OpenVRPlugin_Assets;

partial class Tutorials : Scope {

    public static Material OpenVRPlugin_ru => new Material("OpenVR Plugin", null, $"")
        [new Section("Структура плагина")
            [DirectoryStructure]
        ]

        [new Section("Установка")
            [new OrderedList()
                [$"Скопировать папку с драйвером в любую желаемую директорию"]
                [$"Вызвать `<Steam directory>/steamapps/common/SteamVR/bin/win64/vrpathreg.exe adddriver \"<Driver directory>/antilatency\"`"]
            ]
        ]

        [new Section("Работа с драйвером")
            [$"Драйвер добавляет поддрежку следующих типов устройств в SteamVR:"]
            [new UnorderedList()
                [$"Трекер ({Terms.Alt} + любой {Terms.Socket} или {Terms.Tag})"]
                [$"Контроллер ({Terms.Bracer})"]
            ]

            [$@"{ Terms.Placement} для трекера ищется по имени  заданным в свойстве `Tag` у {Terms.Socket}, если свойство не задано или такой {Terms.Placement} не найдет, то берется установленный по умолчанию в {Terms.AntilatencyService}.
            {Terms.Placement} для {Terms.Bracer} устанавливается автоматически в зависимости от свойства `Tag` у {Terms.Socket}, для левой и для правой руки свойство `Tag` должно быть задано как `LeftHand` или `RightHand`, соответственно."]

            [$"*Кнопки брейсера*"]
            [new OrderedList()
                [$"Trigger click - обычное нажатие на {Terms.Bracer}"]
                [$"System click - нажатие на {Terms.Bracer}, держа руку над головой и смотря прямо (Работает только если трекинг хедсета подменен на текинг Antilatency)"]
            ]
        ]

        [new Section("Замена стандартого трекинга в SteamVR")
            [$"Замена стандартного трекинга осуществляется в секции `TrackingOverrides` в файле `<Steam directory>/config/steamvr.vrsettings`"]
            [$"Пример:"]
            [SteamVrConfigExample]
            [$"В данном примере устройство созданое драйвером `antilatency` с серийным номером `Head`, предоставляет позы для хедсета с серийным номером `LHR-979B50DB`."]
            [$"_Все устройства Antilatency регистрируется в системе SteamVR под *хардварным серийным* номером сокета, *либо вместо серйного номера используется свойство `Tag`*, если оно задано._"]

            [$"Помимо секции `TrackingOverrides`, необходимо установить параметр `activateMultipleDrivers`(в секции `steamvr`)  и параметр `enable`(в секции `driver_antilatency`) в значение `true`."]
            [$"Так же для стабильной работы рекомендуется, для каждого устройства подменяющего трекинг, устновить значение `TrackerRole_None` в секции `trackers`(как показано в примере)."]

            [$"Больше информации о замене трекинга SteamVR доступно {new ExternalReference("https://github.com/ValveSoftware/openvr/wiki/TrackingOverrides", "в документации.")}"]
        ]


        [new Section("Как узнать серийный номер хедсета?")
            [$"Серийные номера всех устройств в системе SteamVR можно получить создав `System Report`, выбрав пункт `Create System Report` в меню SteamVR:"]
            [CreateSystemReportScreen] [SystemReportScreen]
        ]
        ;




}