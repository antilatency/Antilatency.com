using Csml;
using System;
using static Tutorials.Alt_HMD_Placement_Assets;

partial class Tutorials : Scope {

    public static Material Alt_HMD_Placement_ru => new Material("Как создать Placement для HMD",
     TitleImage, 
     $"Выбрать {Terms.Placement} для {Hardware.Alt} можно в приложении {Software.AntilatencyService.Material}. Если среди предустановленных решений нет нужного вам устройства, настройте расположение трекера вручную, следуя инструкции.")


     [$"Чтобы вручную задать расположение трекера Alt на HMD, нужно знать отношение его позиции к "] 
     [$"Чтобы создать новый Placement, откройте AntilatencyService и перейдите во вкладку `Placements`."]
    

     
     

     [new Warning()[$"При установке трекера на VR гарнитуру убедитесь, что трекер надежно закреплен. Важно, чтобы точка вращения трекера была расположена в правильном положении относительно глаз пользователя!"]]

     
     
      [$"1.Для этого используйте опцию \"Custom\".  Откройте вкладку _Placement_ в {Software.AntilatencyService.Material}. Нажмите на синий значок в правом нижнем углу экрана и выберите _Custom_"]
      [ASSelect]
      [$"В случае с VR гарнитурой, нам нужно знать позицию и поворот камеры, которая будет рендерить изображение для гарнитуры. В реальном мире эта точка расположена между глаз пользователя. Мы должны задать расположение, учитывая эту формулу: позиция центроглаза = позиция альта - смещение плейсмента и поворот центроглаза = поворот альта - поворот центроглаза."]
      [ASPlacement]
      [$"Система координат трекера"]
      [Axises]
      
      [new Info()[$"Обратите внимание, что точка вращения трекера находится со смещением в 2,62 мм от задней стороны трекера"]]
     
    /*[new Section("Установка трекера на OculusQuest")
        [$"1. Прикрепите {Hardware.HMD_Radio_Socket} к VR гарнитуре, используя фото. "]
        [OculusQuestPlacement]
        [$"2. Выберите _OculusQuest_ во вкладке _Placement_"]
      ]

      [new Section("Установка трекера на OculusRiftS")
        [$"1. Прикрепите {Hardware.HMD_Radio_Socket} к VR гарнитуре, используя фото. "]
        [OculusRiftSPlacement]
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