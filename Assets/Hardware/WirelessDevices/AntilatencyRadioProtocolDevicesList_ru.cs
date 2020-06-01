using Csml;
partial class Hardware {
    public static Material AntilatencyRadioProtocolDevicesList_ru => new Material(null,  null,
    $"Список устройств с поддержкой {Terms.Antilatency_Radio_Protocol}")
        [new Section("Список приемников")
           [new UnorderedList()
                [$"{Hardware.SocketUsbRadio}"]
            ]
        ]
        [new Section("Список передатчиков")
          [new UnorderedList()
              [$"{Hardware.Tag}"]
              [$"{Hardware.Bracer}"]
          ] 
        ]
    ;
    


}