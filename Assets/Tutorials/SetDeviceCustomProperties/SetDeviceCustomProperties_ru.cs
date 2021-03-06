using Csml;
using System;
using static Tutorials.Set_Device_Custom_Properties_Assets;

partial class Tutorials : Scope {

    public static Material Set_Device_Custom_Properties_ru => new Material("Конфигурация пользовательских свойств",
     TitleImage, 
     $"Устройства Antilatency имеют ряд системных и пользовательских свойств. Управляя пользовательскими свойствами, вы можете настроить устройство для конкретной задачи.")
     
    [$"Все свойства устройств Antilatency отображаются во вкладке {Software.AntilatencyService.Device_Network.Material} приложения AntilatencyService. Чтобы их увидеть, подключите устройство к  Host (например, к компьютеру)."] 
    [$"\nВо вкладке Device Network вы можете:"]
    [new UnorderedList()
    [$"{new ExternalReference("#edit","отредактировать пользовательское свойство")}"]
    [$"{new ExternalReference("#addNew","добавить новое свойство")}"]
    [$"{new ExternalReference("#delete","удалить пользовательское свойство")}"]
    ]
    
    [new Section("Как отредактировать пользовательское свойство","edit")

    [$"Представим, что у вас есть два {Hardware.Bracer}: для левой руки и для правой. Чтобы определить, какое из устройств за какой рукой будет закреплено, нужно назначить для каждого Bracer свойство Tag со значениями `LeftHand` и `RightHand` соответственно."]

        [$"В списке справа выберите свойство `Tag` и пропишите в нём `LeftHand`. Обратите внимание, значок свойства изменился."]
            [EditStep1]

        [$"Чтобы отправить свойство на устройство, нажмите на иконку в правом нижнем углу и выберите опцию `Send settings to device`. Когда процесс загрузки закончится, значок свойства изменится на стандартный."]
            [EditStep2]
            [EditResult]
        [new Info($"Если в процессе работы со свойствами вам нужно отменить изменения, воспользуйтесь опцией `Reload settings from device`, чтобы повторно загрузить данные с устройства.")]
    ]

    [new Section("Как создать новое пользовательское свойство","addNew")

        [$"Чтобы добавить новое свойство для устройства, нажмите на значок `+`."]
            [addNewStep1]

        [$"Присвойте свойству имя и значение."]
            [addNewStep2]

        [$"Затем с помощью опции `Send settings to device` запишите новое свойство на устройство. Когда процесс загрузки закончится, значок свойства изменится на стандартный."]
            [addNewStep3]
            [addNewResult]

        ]

    [new Section("Как удалить пользовательское свойство","delete")

        [$"Чтобы убрать свойство, нажмите на значок `x`. Если вы передумали, нажмите на значок повторно."]
            [DeleteStep1]
        
        [$"Используйте опцию `Send settings to device`, чтобы отправить изменённый набор свойств на устройство."]
            [DeleteStep2]
        ]

    ;
             
} 