using Csml;
using System;
using static Tutorials.OpenVR_Plugin_Assets;

partial class Tutorials : Scope {

    public static Material OpenVR_Plugin_ru => new Material(null, TitleImage, 
    $"Драйвер добавляет в SteamVR поддержку системы трекинга Antilatency. После установки драйвера вы сможете использовать трекер и контроллеры Antilatency при работе с приложениями SteamVR.")

        
       /* [new Section("Структура плагина")
            [DirectoryStructure]
        ]*/

        [new Section("Установка")
            [new OrderedList()
                [$"Скопируйте папку с драйвером в любую директорию"]
               // [$"Вызвать `<SteamDirectory>/steamapps/common/SteamVR/bin/win64/vrpathreg.exe adddriver \"<DriverDirectory>/antilatency\"`"]
            ]
        ]

        [new Section("Работа с драйвером")
            [$"Драйвер добавляет поддрежку следующих типов устройств в SteamVR:"]
            [new UnorderedList()
                [$"Трекер ({Hardware.Alt} + любой {Hardware.SocketUsb} или {Hardware.Tag})"]
                [$"Контроллер ({Hardware.Bracer})"]
            ]

            [$@"{ Terms.Placement} для трекера ищется по имени  заданным в свойстве `Tag` у {Hardware.SocketUsb}, если свойство не задано или такой {Terms.Placement} не найдет, то берется установленный по умолчанию в {Software.AntilatencyService.Material}.
            {Terms.Placement} для {Hardware.Bracer} устанавливается автоматически в зависимости от свойства `Tag` у {Hardware.SocketUsb}, для левой и для правой руки свойство `Tag` должно быть задано как `LeftHand` или `RightHand`, соответственно."]

            [$"*Кнопки брейсера*"]
            [new OrderedList()
                [$"Trigger click - обычное нажатие на {Hardware.Bracer}"]
                [$"System click - нажатие на {Hardware.Bracer}, держа руку над головой и смотря прямо (Работает только если трекинг хедсета подменен на текинг Antilatency)"]
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