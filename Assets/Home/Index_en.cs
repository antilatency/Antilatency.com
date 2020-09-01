using Csml;
using static Root.Index_Assets;

public partial class Root {    
    public static Material Index_en => new Material("Antilatency", null, $"")
        [TitleVideo.GetPlayer().ConfigureAsBackgroundVideo()]

        [LogoWhiteBlack]

        [new Section("Hardware")
            [AllHardware]
        ]

        [new Section("Tutorials")
            [AllTutorials]
        ]
        ;

}