using Csml;
using static Tutorials.ConfiguringRadioDevices_Assets;

partial class Tutorials {
    public static Material ConfiguringRadioDevices_ru => new Material("Конфигурация беспроводных устройств",
    ConfiguringRadioDevices_Assets.TitleImage,
    $"")

    [$"Все устройства Antilatency, в зависимости от их роли в системе {Terms.Antilatency_Radio_Protocol}, можно разделить на две группы: "]
            [new UnorderedList()
                [$"`клиент` - подключается к точке доступа и передаёт данные подключённого трекера {Hardware.Alt}."]
                [$"`точка доступа` - собирает данные с клиентов, добавляет к ним собственные данные и отправляет всё на  Host через USB."]
            ]
            [new Info($"{Hardware.HMD_Radio_Socket} может работать в обоих режимах. Подробнее читайте тут:{Tutorials.HMDSocketMode}")]

        [new Warning($"Мы рекомендуем сначала настроить клиент-устройство, а потом точку доступа.")]

        [new Section("Свойства клиента")
                
                [@$"*ChannelsMask*
                 Клиент ищет точку доступа, используя маску каналов. Это строка длиной  в 141 символ, состоящая из `0` и `1`, где `1` означает, что соответствующий канал будет использован при поиске приемника, а `0` - что канал будет проигнорирован. Первый символ в строке отвечает за последний, 140-й канал.
                        Маска по умолчанию выглядит следующим образом:
                        `000000000000000000001000001000000000000000000000100000000000000000000000001000000000000000000000001000000000000000000000000000000000000000000`
                        
                        Вы можете использовать альтернативный формат записи: {new UnorderedList()
                        [$"`full` - для поиска активны все каналы"]
                        [$"`default` - для поиска активны только 5 каналов по умолчанию"]
                        [$"`N` - для поиска активен только один канал, N - номер этого канала"]
                            }"]
                
                [@$"
                *MasterSN*
                    Свойство позволяет установить конкретную точку доступа, к которой будет подключаться клиент. Настроить MasterSN можно {new ExternalReference("#SetMasterHard", "несколькими способами")}."]
            
            [new Info($"Свойство `MasterSN` позволяет в некоторых случаях сократить время подключения устройств. Если задан серийный номер точки доступа, поиск будет завершён сразу после её обнаружения. Если же это свойство не задано, поиск завершится только после сканирования всех доступных каналов.")]
        ]

        [new Section("Свойства точки доступа")
       
                [@$"*RadioChannel*
                    Устанавливает конкретный радиоканал, через который будет работать точка доступа. С помощью этого свойства вы можете выбрать менее шумный канал или настроить несколько точек доступа на разные частоты.
                    Значение по умолчанию `-1` – точка доступа случайно выбирает первый свободный радиоканал.
                    Подробнее о радиоканалах и радиопротоколе читайте тут:{Terms.Antilatency_Radio_Protocol}
                "]
                [@$"
                *ConnLimit*
                    Определяет максимальное количество клиентов, которые могу быть подключены к этой точке доступа. Значение `0` полностью отключает радио на устройстве.
                "]
                
            [new Info($"Мы рекомендуем указывать точное количество устройств, которое вы планируете подключить. Если вы пропишете большее значение, то часть траффика будет тратиться на поиск новых устройств.")]
        ]

      [new Section("Восстановление связи с клиентом")
            [$"В некоторых случаях клиент может не подключаться к точке доступа и не отображаться в AntilatencyService. Возможные ситуации:"]
            [new UnorderedList()
            [$"Свойство `MasterSN` содержит серийный номер неизвестной точки доступа или устройства, которого нет в наличии. В таком случае, можно {new ExternalReference("#ResetMaster", "сбросить MasterSN")} с помощью кнопки включения."]                    
            [$"На клиенте установлена неизвестная маска каналов. Настройте точку доступа для работы на `92` радиоканале через свойство `RadioChannel`. Этот канал всегда активен для поиска, вне зависимости от настроек маски каналов."]
            ]
        ]

       [new Section("Как сбросить свойство MasterSN", "ResetMaster") 
            [$"Включите устройство, на котором вы хотите сбросить серийный номер точки доступа. После этого на `5 секунд` зажмите кнопку включения. Устройство перезагрузится, при этом свойство MasterSN будет сброшено."]
        ]

        [new Section($"Как назначить свойство MasterSN", "SetMasterHard")
        [$"Настроить клиент для подключения к конкретной точке доступа можно двумя способами:"]
        [new UnorderedList()
                [@$"*c помощью AntilatencyService* 
                Для этого найдите во вкладке {Software.AntilatencyService.Device_Network.Material} нужную точку доступа и скопируйте её серийный номер.
                        {accessPointSN}
                О том, как редактировать пользовательские свойства читайте тут: {Tutorials.Set_Device_Custom_Properties}"]
                
                [@$"*c помощью кнопки включения устройства* {new OrderedList()
                    [$"Подключите точку доступа к  Host."]
                    [$"Включите клиент-устройство коротким нажатием на кнопку включения."]
                    [$"Дождитесь, пока клиент подключится к точке доступа. Светодиоды обоих устройств будут равномерно моргать одним и тем же цветом."]
                    [$"Зажмите кнопку включения клиента на `5 секунд`. Устройство перезагрузится, а серийный номер точки доступа автоматически запишется в свойство MasterSN."]
                }"]
                
        ]
        ]

    ;
    


}