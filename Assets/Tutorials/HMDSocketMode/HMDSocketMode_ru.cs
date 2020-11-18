using Csml;
public partial class Tutorials : Scope {
    public static Material HMDSocketMode_ru => new Material("Режимы  работы HMD Socket",
    null, 
    $"{Hardware.HMD_Radio_Socket} - маленькое и лёгкое устройство, которое может работать как точка доступа, так и как клиент, если к нему подключено внешнее питание. Режим работы задаётся пользователем через приложение {Software.AntilatencyService.Material}.")

    [$"HMD Radio Socket может работать как `клиент`, передавая данные трекинга с модуля {Hardware.Alt} точке доступа, или как `точка доступа`, собирая данные трекинга с подключённых клиентов и передавая их по USB на  Host вместе с собственными данными."]


    [@$"
    Вы можете изменить режим работы HMD Radio Socket во вкладке {Software.AntilatencyService.Device_Network.Material} служебного приложения AntilatencyService.
    Для этого задайте свойству *Mode* нужное значение: {new UnorderedList() 
    [$"UsbRadioSocket (точка доступа)"] 
    [$"RadioSocket (клиент)"]}"] 
    [new Warning($"Обновление прошивки доступно только в режиме UsbRadioSocket. Подробнее читайте тут: {Tutorials.Firmware_Update}")]


    [$"\nУстройство в каждом из режимов имеет ряд системных и пользовательских свойств. Некоторые свойства общие для всех режимов работы. Например, Tag или серийный номер. Подробнее о конфигурации устройств Antilatency читайте тут: {Tutorials.ConfiguringRadioDevices}"]


    [new Section("Отображение в Device Tree")

        [$"С версии прошивки 5.0.0 HMD Radio Socket в режиме `RadioSocket` отображается дополнительным узлом в {Terms.Device_Tree} под именем *AltHmdRadioSocketShadow* при подключении к  Host через USB. Таким образом, можно настроить клиент, не подключая его к точке доступа."]

        [$"Обратите внимание, если подключить HMD Radio Socket в режиме клиента к точке доступа и одновременно через USB к Host, то устройство дважды отобразится в Device Tree под разными именами."]
        
        [RadioSocket]
        [RadioSocket1]

    ]
;
}
