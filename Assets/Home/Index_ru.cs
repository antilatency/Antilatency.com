using Csml;
using static Root.Index_Assets;

public partial class Root {
    public static Material Index_ru => new Material("Antilatency", null, $"Компания мечты")
        [TitleVideo.GetPlayer().ConfigureAsBackgroundVideo()]

        [LogoWhiteBlack]

        [new Section("Оборудование")
            [AllHardware]
        ]        

        [new Section("Уроки")
            [AllTutorials]
        ]
        ;    
}
