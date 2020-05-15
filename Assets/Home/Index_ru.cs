using Csml;
using System.Linq;
using static Root.Index_Assets;

public partial class Root {
    static Material Index_ru => new Material("Antilatency", null, $"Компания мечты")
        [TitleVideo.GetPlayer().ConfigureAsBackgroundVideo()]

        [Logo40Black]

        [new Section("Оборудование")
            [AllHardware]
        ]        

        [new Section("Уроки")
            [AllTutorials]
        ]
        
        

    ;    
}
