using Csml;

public partial class Software : Scope {
    public partial class AntilatencyService{
        //todo new Material("Antilatency Service" -> nфw Material(null
        public static Material Material_en => new Material("AntilatencyService",
        Title,
        $"A utility allows to configure the tracking parameters, to update the firmware and to look through the device tree. Besides, AntilatencyService keeps in the settings of the tracking areas and VR gadgets.")

        [new Downloadable("AntilatencyService", "AntilatencyServiceBinaries",
                    Downloadable.PathFragment.Version, Downloadable.PathFragment.Directory, Downloadable.PathFragment.Directory)]

        [new Success($"You need to run a utility at least once to initialize the system and to make the first-time setup.")]

        //[$"Extra info how to install AS:"]
        //[$"{How_to_install_Antilatency_Service}"]
        

        [new Section("Environments")
            [($"Using the tab {(global::Software.AntilatencyService.Environments.Material)} you can load and edit the tracking area or create a new one and then share it by the link.")]
            [EnvironmentsTabScreenshot]
        ]
    

        [new Section("Placements")
            [($"Using the tab {(global::Software.AntilatencyService.Placements.Material)} you can set the corresponding placement for Antilatency device on the VR gadget. The presets for some popular HMDs are available by default.")]
            [PlacementsTabScreenshot]
        ]
    

        [new Section("Device Network")
            [($"Using the tab {(global::Software.AntilatencyService.Device_Network.Material)} you can read and write device properties, update the firmware, and look through the device tree.")]
            [DeviceNetworkTabScreenshot]
        ]

       ;
    }


}