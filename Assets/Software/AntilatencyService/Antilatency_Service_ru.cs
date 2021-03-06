﻿using Csml;

public partial class Software : Scope {
    public partial class AntilatencyService{
        //todo new Material("Antilatency Service" -> nфw Material(null
        public static Material Material_ru => new Material("AntilatencyService",
        Title,
        $"Служебное приложение для обновления прошивки и просмотра дерева подключённых устройств. Кроме этого, AntilatencyService сохраняет настройки зон трекинга и {Terms.Placement} для разных VR устройств.")

        [InstallFile]

        [new Success($"После установки приложение необходимо запустить, чтобы выполнить первичную настройку устройств и зон трекинга.")]
        [new Warning($"AntilatencyService не поддерживает параллельную работу двух и более приложений. Поэтому, прежде чем начать работу с новым приложением, закройте предыдущее.")]

        //[$"Подробнее про установку можно почитать тут:"]
        //[$"{How_to_install_Antilatency_Service}"]
        

        [new Section("Environments")
            [($"Во вкладке {(global::Software.AntilatencyService.Environments.Material)} можно загрузить, отредактировать или создать зону трекинга.")]
            [EnvironmentsTabScreenshot]
        ]
    

        [new Section("Placements")
            [($"Во вкладке {(global::Software.AntilatencyService.Placements.Material)} можно настроить расположение трекера Antilatency на устройствах для VR. По умолчанию в приложении доступны решения для некоторых популярных моделей шлемов виртуальной реальности.")]
            [PlacementsTabScreenshot]
        ]
    

        [new Section("Device Network")
            [($"Во вкладке {(global::Software.AntilatencyService.Device_Network.Material)} можно посмотреть системные и пользовательские свойства каждого из подключённых устройств, получить данные о версии прошивки и обновить её при необходимости.")]
            [DeviceNetworkTabScreenshot]
        ]

       ;
    }

    
}
