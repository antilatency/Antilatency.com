using Csml;
using System;
using static Tutorials.Firmware_Update_Assets;

partial class Tutorials : Scope {

    public static Material Firmware_Update_ru => new Material("Обновление прошивки Antilatency устройств",
     TitleImage, 
     $"В вкладке {Software.AntilatencyService.Device_Network.Material} приложения AntilatencyService вы можете управлять прошивкой подключённых устройств.")

     [$"Чтобы обновить прошивку устройства, подключите его к компьютеру. После этого вы получите доступ к конфигурации устройства через Device Tree."]
     // мб, написать почему так. мастер и слэйв режимы работы
     [$"{Hardware.HMD_Radio_Socket}, {Hardware.SocketUsb} и {Hardware.PicoG2Socket} можно подключить напрямую через USB. А для работы с {Hardware.Tag} и {Hardware.Bracer} вам потребуется HMD Radio Socket."]
     [$"Чтобы обновить {Hardware.Alt}, вы можете использовать любой совместимый с ним {Terms.Socket}."]


        [new Section("Видеоинструкция по обновлению прошивки")
        [TitleVideo.GetPlayer()]]

        [new Section("Пошаговая инструкция")
        
        [$"Шаг 1. Подключите устройство к компьютеру."]

        [$"Шаг 2. Откройте вкладку Device Network. Слева вы увидите дерево устройств, подключенных к компьютеру."]

        [$"Шаг 3. Выберите нужное вам устройство. В графе `sys/FirmwareVersion` указана текущая версия прошивки."]

        [$"Шаг 4. Выберите опцию `Reflash firmware`. Откроется окно с версиями прошивок, где красной стрелкой обозначена текущая версия."]

        [$"Шаг 5. Выберите нужную версию прошивки и нажмите `Flash`."]

        [$"Шаг 6. Дождитесь конца установки. Не закрывайте программу и не отключайте устройство во время обновления."]

        // move : troubleshooting [new Warning($"Если вы обновляете несколько устройств подряд, то после каждого обновления обязательно возвращайтесь на основную вкладку Device Network.")]
                   
        ];
        
             
} 