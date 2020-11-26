using Csml;
using System;
using static Tutorials.Firmware_Update_Assets;

partial class Tutorials : Scope {

    public static Material Firmware_Update_ru => new Material("Обновление прошивки Antilatency устройств",
     TitleImage, 
     $"Установить версию прошивки для устройства можно во вкладке {Software.AntilatencyService.Device_Network.Material} приложения AntilatencyService.")

     [$"Чтобы обновить прошивку устройства, подключите его к компьютеру. После этого вы получите доступ к конфигурации устройства через {Terms.Device_Tree}."]
     // мб, написать почему так. мастер и слэйв режимы работы

        [new Section("Видеоинструкция по обновлению прошивки")
        [TitleVideo.GetPlayer()]]

        [new Section("Пошаговая инструкция на примере HMD Radio Socket")
        
        [$"*Шаг 1.* Подключите устройство к компьютеру и запустите AntilatencyService."]

        [$"*Шаг 2.* Перейдите во вкладку Device Network и выберите нужное устройство в Device Tree."]

        [Step2]

        [$"*Шаг 3.* Нажмите на иконку в правом нижнем углу."]

        [Step3]

        [$"*Шаг 4.* Выберите опцию `Reflash firmware`."]

        [Step4]

        [$"*Шаг 5.* Выберите нужную версию прошивки в открывшемся окне."]
        [new Info($"Красная стрелочка указывает на текущую версию.")]

        [Step5]

        [$"*Шаг 6.* Нажмите `Flash` и дождитесь конца установки."]
        [new Warning($"Не закрывайте программу и не отключайте устройство во время обновления.")]

        [Step6]

        [new ToDo("move to troubleshooting")]

        // move : troubleshooting [new Warning($"Если вы обновляете несколько устройств подряд, то после каждого обновления обязательно возвращайтесь на основную вкладку Device Network.")]
                   
        ];
        
             
} 