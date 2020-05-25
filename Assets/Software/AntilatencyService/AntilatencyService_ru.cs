using Csml;

partial class Software : Scope {
    public static Material Antilatency_Service_ru => new Material(null,null,$"Служебное приложение Antilatency для управления настройками трекинга и обновления устройств")
        
        [new Downloadable("AntilatencyService", "AntilatencyServiceBinaries", 
            Downloadable.PathFragment.Version, Downloadable.PathFragment.Directory, Downloadable.PathFragment.Directory)]

        [new Downloadable(null, "Alt3DModel", Downloadable.PathFragment.Directory | Downloadable.PathFragment.CanSelectAll)]
        //[new Downloadable(null, "Alt3DModel")]
        //[new Downloadable(null, "Alt3DModel/Step/Alt.stp")]

        ;

}