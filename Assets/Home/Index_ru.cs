using Csml;
using static Root.Index_Assets;

public partial class Root {
    static Material Index_ru => new Material("Antilatency", null, $"Компания мечты")
        [TitleVideo.GetPlayer().ConfigureAsBackgroundVideo()]

        [Logo40Black]

        [new Section("Уроки")]

        [new Grid(320,1,2,3,4)
            [new MaterialCard(Hardware.Alt)][new MaterialCard(Hardware.Alt)]
            [new MaterialCard(Hardware.Alt)][new MaterialCard(Hardware.Alt)]
        
        ]

    ;    
}
