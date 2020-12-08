using Csml;
using System;
using static Tutorials.Alt_HMD_Placement_Assets;

partial class Tutorials : Scope {

    public static Material Alt_HMD_Placement_ru => new Material("Как создать Placement для HMD",
     TitleImage, 
     $"Настроить {Terms.Placement} для {Hardware.Alt} можно во вкладке {Software.AntilatencyService.Placements.Material} приложения {Software.AntilatencyService.Material}. Если среди предустановленных решений нет нужного вам устройства, настройте расположение трекера вручную.")

    [$"Чтобы вручную задать Placement в AntilatencyService, нужно знать позицию трекера Alt относительно опорной точки физического объекта, на котором трекер будет установлен. Возьмём в качестве примера физического объекта шлем виртуальной реальности. Опорная точка HMD расположена между глазами пользователя. "]

    [new Info($"Мы рекомендуем располагать трекер на HMD настолько близко к опорной точке шлема, насколько возможно.")]

    [$"Чтобы создать новый Placement, нажмите на иконку в нижнем правом углу и выберите опцию *Custom*."]

    [CreateCustomPlacement]

    [$"В открывшейся форме введите имя Placement и нажмите *Next*."]

    [CreateCustomPlacement2]

    [$"Теперь нужно выставить позицию опорной точки трекера Alt относительно условной точки между глазами пользователя."]

    [SetPlacement]

    [new Info($"Обратите внимание, что опорная точка трекера находится со смещением в 2,62 мм от задней стороны трекера")]
      [Axises]
      
   [new ToDo("доработать материал и вынести в отдельную статью")]
   /*[new Section("Установка трекера на OculusQuest")
        [$"1. Прикрепите {Hardware.HMD_Radio_Socket} к VR гарнитуре, используя фото. "]
        [OculusQuestPlacement]
        [$"2. Выберите _OculusQuest_ во вкладке _Placement_"]
      ]

      [new Section("Установка трекера на OculusRiftS")
        [$"1. Прикрепите {Hardware.HMD_Radio_Socket} к VR гарнитуре, используя фото. "]
        [OculusRiftS]
        [$"2. Выберите _OculusRiftS_ во вкладке _Placement_"]
      ]

      [new Section("Установка трекера на OculusGo")
        [$"1. Прикрепите {Hardware.HMD_Radio_Socket} к VR гарнитуре, используя фото. "]
        [OculusGoPlacement]
        [$"2. Выберите _OculusGoUniversal_ во вкладке _Placement_"]
      ]

      [new Section("Установка трекера на OculusRift")
        [$"1. Прикрепите {Hardware.HMD_Radio_Socket} к VR гарнитуре, используя фото. "]
        [OculusRiftPlacement]
        [$"2. Выберите _OculusRiftUniversal_ во вкладке _Placement_"]
      ]

      [new Section("Установка трекера на VivePro")
        [$"1. Прикрепите {Hardware.HMD_Radio_Socket} к VR гарнитуре, используя фото. "]
        [ViveProPlacement]
        [$"2. Выберите _ViveProUniversal_ во вкладке _Placement_"]
      ]

      [new Section("Установка трекера на Pico G2")
        [$"1. Мы разработали проприетарный {Hardware.PicoG2Socket}, который облегчает размещение трекера. Он присоединяется через USB снизу VR гарнитуры. Если вы используете этот сокет, выберите _PicoGoblin2_ во вкладке _Placement_ "]
        [PicoG2Socket]
        [$"Если вы решили использовать универсальный {Hardware.HMD_Radio_Socket}, выполните следующие шаги:"]
        [$"1. Прикрепите {Hardware.HMD_Radio_Socket} к VR гарнитуре, используя фото."]
        [PicoG2Placement]
        [$"2. Выберите _PicoGoblin2Universal_ во вкладке _Placement_"]
        
      ]
      */

      [new ToDo("move to troubleshooting")]
    /* move : troubleshooting 
    [new Section("Расположение (placement) трекера")
     [$"Правильное расположение трекера на VR гарнитуре полностью определяет качество виртуального опыта, так как определяет главную точку восприятия виртуального мира пользователем."]
     [$"Неправильное, даже на несколько градусов, расположение может вызвать у пользователя дискомфорт."]
     [CorrectPlacementScene]
     [$"Отображение демо сцены из Unity с правильным расположением трекера"]
     [IncorrectPlacementScene]
     [$"Отображение демо сцены с ошибкой в расположении на 2 градуса по оси Z"]
     ]
     */

    ;
   
     
} 