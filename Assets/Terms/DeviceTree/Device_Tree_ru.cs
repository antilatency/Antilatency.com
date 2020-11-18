using Csml;
using static Api.Antilatency.DeviceNetwork;
partial class Terms {
    public static Material Device_Tree_ru => new Material("Device Tree", null,
    $"Дерево устройств - это способ подключения устройств Antilatency друг к другу и объединения их в одну сеть.")

            [$"Все устройства Antilatency, подключённые к одному Host, образуют сеть в виде дерева устройств. Корневой точкой (root) является Host, а остальные устройства образуют узлы. В каждом из узлов этого дерева может находится Node, выполняющий {Terms.Task}."]
            [$"Дерево устройств формирует иерархию подключения устройств и порядок передачи данных на Host."]

            [new UnorderedList()
                [$"Чтобы {Hardware.Tag} и {Hardware.Bracer} отобразились в Device Tree, нужно подключить их через HMD Radio Socket."]
                [$"{Hardware.HMD_Radio_Socket}, {Hardware.SocketUsb} и {Hardware.PicoG2Socket} можно подключить напрямую через USB. "]
                [$"Чтобы управлять настройками {Hardware.Alt}, можно использовать любой совместимый с ним {Terms.Socket}."]
            ]

            [$"Между собой устройства обмениваются данными с помощью {Terms.Antilatency_Radio_Protocol}. В рамках радиопротокола устройство может выступать как клиент или как точка доступа. Точка доступа собирает с подключённых клиентов данные трекинга, полученные с модуля {Hardware.Alt}, добавляет к ним свои собственные и отправляет все данные на Host через USB."]

            [$"Рассмотрим дерево девайсов на примере fullbody сетапа для виртуальной реальности"]
            [DeviceHierarchy]
            [$"Мастер сокет подключается к HMD или backpack PC, в обоих случаях возможно подключение Antilatency трекера к этому сокету для отслеживания головы или любой другой части тела."]
            [$"К мастер сокету подключаются четыре сокета - два Tag и два Bracer. Эти сокеты являются передатчиками данных своих трекеров к мастер - сокету. Таким образом создается сеть, позволяющая создать fullbody трекинг на основе знания о позиции пяти точек."]
            [DeviceTreeInAntilatencyService]
            [$"Вот так выглядит дерево девайсов для данного сетапа в AntilatencyService."]
        

       /* [new Section("Полезные ссылки")
        [$"{Tutorials.ConfiguringRadioDevices}"]
        [$"{Tutorials.Firmware_Update}"]
        [$"{Tutorials.Set_Device_Custom_Properties}"]
        ]
        */
        ;

        
        
    
    


}