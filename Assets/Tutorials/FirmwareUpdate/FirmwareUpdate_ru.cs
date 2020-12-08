using Csml;
using System;
using static Tutorials.Firmware_Update_Assets;

partial class Tutorials : Scope {

    public static Material Firmware_Update_ru => new Material("Обновление прошивки Antilatency устройств",
     TitleImage, 
     $"Установить версию прошивки для устройства можно во вкладке {Software.AntilatencyService.Device_Network.Material} приложения AntilatencyService.")

     [$"Подключите устройство к {Terms.Host}. После этого вы получите доступ к конфигурации устройства через {Terms.Device_Tree}."]

     [new UnorderedList()
                [$"{Hardware.HMD_Radio_Socket}, {Hardware.SocketUsb} и {Hardware.PicoG2Socket} можно подключить напрямую через USB."]
                [$"{Hardware.Tag} и {Hardware.Bracer} нужно подключить через HMD Radio Socket."]
                [$"{Hardware.Alt} можно подключить через любой совместимый {Terms.Socket}."]
            ]

        [TitleVideo.GetPlayer()]
        
        [$"Запустите {Software.AntilatencyService.Material} и перейдите во вкладку Device Network. Затем выберите нужное устройство в Device Tree."]

        [Step2]

        [$"Нажмите на иконку в правом нижнем углу и выберите опцию `Reflash firmware`."]

        [Step4]

        [$"В открывшемся окне вы видите список доступных для загрузки версий прошивки. Текущая версия будет отмечена красной стрелочкой."]

        [Step5]

        [$"Выберите нужную версию прошивки и нажмите `Flash`. Дождитесь конца установки."]
        [new Warning($"Не закрывайте программу и не отключайте устройство во время обновления.")]

        [Step6]

       [new ToDo($"troubleshooting [new Warning(Если вы обновляете несколько устройств подряд, то после каждого обновления обязательно возвращайтесь на основную вкладку Device Network.")] 
                   
        ;
        
             
} 