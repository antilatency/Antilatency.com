using Csml;

public partial class Software : Scope {
    public partial class Antilatency_Service{
        //todo new Material("Antilatency Service" -> nфw Material(null
        public static Material Material_en => new Material("Antilatency Service",
        Title,
        $"A utility allows to configure the tracking, to update the firmware and to look through the device tree. Besides Antilatency Service keeps in the settings of the tracking areas and HMDs.")

        [new Downloadable("AntilatencyService", "AntilatencyServiceBinaries",
                    Downloadable.PathFragment.Version, Downloadable.PathFragment.Directory, Downloadable.PathFragment.Directory)]

        [new Success($"You need to run a utility at least once to initialize the system and to make the first-time setup.")]

        //[$"Extra info how to install AS:"]
        //[$"{How_to_install_Antilatency_Service}"]
        

        [new Section("Environments")
            [($"Using the tab {(global::Software.Environments)} you can load and edit the tracking area or create a new one and then share it by the link.")]
            [EnvironmentsTabScreenshot]
        ]
    

        [new Section("Placements")
            [($"Using the tab {(global::Software.Placements)} you can set the corresponding placement for Antilatency device on the HMD. The presets for some popular HMDs are available by default.")]
            [PlacementsTabScreenshot]
        ]
    

        [new Section("Device Network")
            [($"Using the tab {(global::Software.Antilatency_Service.Device_Network)} you can read and write device properties, update the firmware, and look through the device tree.")]
            [DeviceNetworkTabScreenshot]
        ]

       ;
    }


}