using Csml;

public partial class Software : Scope {
    public partial class Antilatency_Service{
        //todo new Material("Antilatency Service" -> nфw Material(null
        public static Material Material_ru => new Material("Antilatency Service",
        Title,
        $"Служебное приложение для управления настройками трекинга и для обновления прошивки. Antilatency Service сохраняет настройки зон трекинга, а также позволяет посмотреть дерево подключённых устройств.")

        [new Downloadable("AntilatencyService", "AntilatencyServiceBinaries",
                    Downloadable.PathFragment.Version, Downloadable.PathFragment.Directory, Downloadable.PathFragment.Directory)]

        [new Success($"После установки приложение необходимо запустить, чтобы выполнить первичную настройку устройств и зон трекинга.")]

        //[$"Подробнее про установку можно почитать тут:"]
        //[$"{How_to_install_Antilatency_Service}"]
        

        [new Section("Environments")
            [($"Во вкладке {(global::Software.Environments)} можно загрузить, отредактировать или создать зону трекинга.")]
            [EnvironmentsTabScreenshot]
        ]
    

        [new Section("Placements")
            [($"Во вкладке {(global::Software.Placements)} можно настроить расположение устройства Antilatency на шлеме виртуальной реальности. По умолчанию в приложении доступны решения для некоторых популярных моделей.")]
            [PlacementsTabScreenshot]
        ]
    

        [new Section("Device Network")
            [($"Во вкладке {(global::Software.Antilatency_Service.Device_Network)} можно посмотреть системные и настраиваемые характеристики каждого из подключённых устройств, получить данные о версии прошивки и обновить её при необходимости.")]
            [DeviceNetworkTabScreenshot]
        ]

       ;
    }


}