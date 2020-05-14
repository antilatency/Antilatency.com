using Csml;

partial class Sdk : Scope {
    public static LanguageSelector<IMaterial> Configurator => new LanguageSelector<IMaterial>();

    public static Material Configurator_ru => new Material("Sdk", null, $"На этой странице вы сможите \"Приготовить\" Sdk, выбрав платформу и добавив ингредиенты на ваш вкус")

        [new Behaviour("SdkConfigurator").Modify().Wrap("div").AddClasses("SdkConfigurator")]
        
        ;

}