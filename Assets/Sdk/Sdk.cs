using Csml;

partial class Sdk : Scope {
    public static LanguageSelector<IMaterial> This => new LanguageSelector<IMaterial>();

    public static Material This_ru => new Material("Sdk", null, $"На этой странице вы сможите \"Приготовить\" Sdk, выбрав платформу и добавив ингридиенты на ваш вкус")
        [new Collection()
            [new Behaviour("SdkEditor").Modify().Wrap("div").AddClasses("SdkEditor")]
        ]
        ;

}