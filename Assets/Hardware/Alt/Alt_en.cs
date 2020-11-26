using Csml;
using static Hardware.Alt_Assets;

partial class Hardware : Scope {
        public static Material Alt_en => new Material("Alt", AltAndUsbSocket0,
        @$"The Alt is an optical inertial tracking module. The Alt is located on objects being tracked and determines their position in space in relation to infrared markers. 
            Alt is supplied as a bundle with a wired {Hardware.SocketUsb}.")
        [new Section("Sensor fusion")
            [$"The Alt is based on a sensor fusion approach. It's an inertial measurement unit (IMU) based tracking system with real-time IMU correction based on optical data."]
        ]

        [new Section("Latency compensation")
            [$"A tracking speed up to 2000 measurements per second and low hardware latency of 2ms allows extrapolating the position and compensating for rendering latency."]
        ]

        [new Section("Onboard processing")
            [$"The Alt is responsible for most of the data processing. This allows the headset to preserve its processing power for other tasks."]
        ]

        [new Section("Custom optics")
            [$"Custom designed lenses with a 240 degree field of view, factory calibrated."]
        ]


        [new Section("Technical specifications")
            [new Table(2)
                [$"Sensors"][$"Optical sensor,  accelerometer,  gyroscope"]
                [$"Position frequency"][$"2000Hz"]
                [$"Latency"][$"2 ms"]
                [$"Optics FOV"][$"240 degrees"]
                [$"Power consumption"][@$"In tracking mode: 175mA@3V
                                          In idle mode: 130mA@3V"]
                [$"Connectivity"][@$"No
                                    Connectivity is provided by {Terms.Socket}"]
                [$"Dimensions"][$"16x16x20.5 mm"]
                [$"Weight"][$"12 g"]
            ]
        ]

        ;
}