using Csml;


partial class Tutorials : Scope
{
    public static LanguageSelector<IMaterial> Environment_Editor => new LanguageSelector<IMaterial>();
    public partial class Environment_Editor_Assets : Scope
    {
        public static Image Environments => new Image("./Environments.png");
        public static Image AddRigidEnvironment => new Image("./AddRigidEnvironment.png");
        public static Image EnvironmentEditor => new Image("./EnvironmentEditor.png");
        public static Image DisplayEstimations => new Image("./DisplayEstimations.png");
        public static Image DisplayVisibility => new Image("./DisplayVisibility.png");
        public static Image FeaturesGenerator => new Image("./FeaturesGenerator.png");
        public static Image MultipleSelection => new Image("./MultipleSelection.png");
        public static Image Parameters => new Image("./Parameters.png");
        public static Image Routing => new Image("./Routing.png");
        public static Image SimulationSettings => new Image("./SimulationSettings.png");
        public static Image TrackingGenerator => new Image("./TrackingGenerator.png");
        public static Image Features => new Image("./Features.png");
    }
}