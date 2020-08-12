using Csml;
using System.Linq;
using static Root.Index_Assets;

public partial class Root {
    public static Material Index_ru => new Material("Antilatency", null, $"Компания мечты CI test")
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
