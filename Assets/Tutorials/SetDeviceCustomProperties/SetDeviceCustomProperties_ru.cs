using Csml;
using System;
using static Tutorials.Set_Device_Custom_Properties_Assets;

partial class Tutorials : Scope {

    public static Material Set_Device_Custom_Properties_ru => new Material("Назначение кастомных свойств для устройств Antilatency",
     TitleImage, 
     $"Инструкция по назначению кастомных свойств для устройств на примере назначения свойства _Tag_ для {Hardware.Tag}")

     
     [$"У каждого устройства Antilatency есть ряд {Terms.Device_Properties}. К примеру, кастомное свойство _Tag_ позволяет определить конкретное устройство среди прочих, что несомненно облегчает процесс разработки. В этом туториале мы рассмотрим назначение кастомных свойств на примере свойства _Tag_ у {Hardware.Tag}."]
     

    [new Section("Установка")
    [$"1. Подключите {Hardware.SocketUsbRadio} к компьютеру, или любому другому хосту."]
    
    [$"2. Подключите {Hardware.Tag} к {Hardware.SocketUsbRadio}. Подробнее о подключении можно узнать здесь: {Tutorials.ConfiguringRadioDevices}"]
    
    [$"3. Откройте {Software.AntilatencyService.Material}, вкладку Device Network"]
    [DeviceTreeAS]

    [$"4. Выберите {Hardware.Tag} в {Terms.Device_Tree}. Во вкладке справа назначьте нужное свойство _Tag_ (в нашем случае _Gun_). После ввода нового свойства слева от него появится значок жёлтой ручки."]
    [SetProperty]

    [$"5. Теперь отправим новое свойство на устройство. Для этого воспользуйтесь синей кнопкой в правом нижнем углу окна. Выберите _Send settings to device_"]
    [SendSettings]
    [$"После нажатия кнопки данные запишутся на устройство и пропадёт значок жёлтой ручки. Вы также можете воспользоаться _Reload settings from device_, чтобы заново загрузить данные с устройства."]

    ];

        
        
             
} 