using Csml;
using static Api.Antilatency.DeviceNetwork;
partial class Terms {
    public static Material Device_Tree_ru => new Material("Device Tree", null,
    $"Способ подключения устройств Antilatency друг к другу и объединения их в одну сеть.")

            [$"Все устройства Antilatency, подключённые к одному {Terms.Host}, образуют сеть в виде дерева устройств. Корневой точкой является Host, а остальные устройства образуют узлы, или {Terms.Node}. Каждый узел этого дерева может выполнять {Terms.Task}. Дерево устройств формирует иерархию подключения устройств и порядок передачи данных на Host."]
           
            [$"Дерево устройств отображается в приложении {Software.AntilatencyService.Material} во вкладке {Software.AntilatencyService.Device_Network.Material}. Здесь вы можете управлять свойствами любого из подключённых устройств."]

            [new Info($"Подробнее о конфигурации устройств и работе с деревом устройств {new ExternalReference("#usefulLinks","читайте тут")}.")]


            [$"Для обмена данными устройства Antilatency могут использовать проприетарный радиопротокол. В зависимости от роли в процессе обмена данными, все устройства можно разделить на две группы: клиенты и точки доступа. Подробнее читайте тут: {Terms.Antilatency_Radio_Protocol}."]

            [$"Рассмотрим дерево устройств на примере полного комплекта устройств для одного пользователя:"]
                 [new UnorderedList() 
                     [$"HMD Radio Socket и трекер Alt - для отслеживания головы;"]
                     [$"два Bracer и два трекера Alt - для отслеживания рук;"]
                     [$"два Tag и два трекера Alt - для отслеживания ног."]
            ]
                     [DeviceHierarchy]

                     [$"HMD Radio Socket, подключённый к шлему виртуальной реальности по USB, выполняет роль точки доступа. А Tag и Bracer выступают как клиенты. Вместе устройства образуют сеть, с помощью которой можно отслеживать положение тела пользователя на основе знаний о позиции пяти точек."]
                     [$"Так выглядит дерево устройств для описанного выше комплекта в AntilatencyService:"]
            
        [DeviceTreeInAntilatencyService]


       [new Section("Полезные ссылки","usefulLinks")
            [$"{Tutorials.ConfiguringRadioDevices}"]
            [$"{Tutorials.Set_Device_Custom_Properties}"]
            [$"{Tutorials.Firmware_Update}"]
        ]
        ;



}