using Csml;
public partial class Tutorials : Scope {
    public static Material HMDSocketMode_ru => new Material("Режим работы HMD Socket",
    null, 
    $"{Hardware.HMD_Radio_Socket} работает в одном из двух режимов: radio master или radio slave. Используя системное приложение {Software.AntilatencyService.Material}, вы можете настроить режим работы любого подключённого устройства.")

    [$"Начиная с версии прошивки 1.3.0, HMD_Radio_Socket поддерживает два режима работы:"]

        [new UnorderedList()
            [$"radio master - устройство подключает к себе другие slave {Terms.Socket}, а данные передаёт через USB;"]
            [$"radio slave - устройство подключается к master HMD_Radio_Socket, а данные передаёт по радиоканалу."]
        ]

    [@$"
    Вы можете изменить режим работы HMD_Radio_Socket во вкладке {Software.AntilatencyService.Device_Network.Material} служебного приложения AntilatencyService. Для этого задайте свойству *Mode* нужное значение: {new UnorderedList() 
    [$"UsbRadioSocket (radio master)"] 
    [$"RadioSocket (radio slave)"]}"] 
    [new Warning($"Обновление прошивки доступно только в режиме UsbRadioSocket.")]
    [$"\nУстройство в каждом из режимов обладает независимым набором свойств для конфигурации. Пользовательские свойства, к примеру, Tag, - общие для всех режимов работы."]
    [new Info($"Подробнее о свойствах читайте тут: {ConfiguringRadioDevices:SetMasterSoft}.")]

    [new Section("UsbRadioSocket")

        [UsbRadioSocket]

        [new Section("Уникальные свойства")]
        
        [new UnorderedList()
                [new Paragraph(@$"`RadioChannel` - по умолчанию приёмник в случайном порядке выбирает первый свободный радиоканал из доступных. Подробнее о передаче данных по радиоканалу см. {Terms.Antilatency_Radio_Protocol:channels}")]

                [$"`ConnLimit` - максимальное количество передатчиков, которые могу быть подключены к этому приёмнику."]
        ]
                [new Info($"Мы рекомендуем указывать точное количество устройств, которое вы планируете подключить. Если вы пропишете большее значение, то часть траффика будет тратиться на поиск новых устройств.")]
                
        ]
    

    [new Section("RadioSocket")


        [$"С версии прошивки 5.0.0 {Hardware.HMD_Radio_Socket} в беспроводном режиме отображается дополнительным узлом в {Terms.Device_Tree} под именем *AltHmdRadioSocketShadow*. Для этого устройство необходимо подключить через USB.  \nПри этом вам доступны все возможности для настройки параметров беспроводного режима: можно установить маску каналов, прописать серийный номер приёмника или изменить режим работы."]
            [new Info($"Если вы подключите Socket в беспроводном режиме одновременно через USB и к Socket в режиме radio master, то устройство дважды отобразится в дереве устройств под разными именами.")]
        [RadioSocket]
        [RadioSocket1]

        [new Section("Уникальные свойства")]

        [new UnorderedList()
            [$"`MasterSN` - свойство содержит серийный номер приёмника, к которому будет подключаться конкретный передатчик."]
            [$"`ChannelsMask` - свойство задаёт маску каналов, по которой передатчик будет искать приёмник."]
        ]
    
    ]
;
}
