using System.Collections.Generic;
using Csml;
using HtmlAgilityPack;


namespace Csml {
    partial class Scope {
        public static ITemplate Template => new Csml.TemplateRegularMaterial(Root.MainMenu)
            [Root.LanguageMenu]
            [Root.CommonFooter]
            ;
    }

    
}


partial class Root : Scope {

    public new static ITemplate Template => new Csml.TemplateLanding(MainMenu)
        [Root.LanguageMenu]
        [Root.CommonFooter]
            ;

    //public Root() {
    //Material.DefaultTemplate = RegularPage;
    //}


    public static Menu MainMenu => new Menu()
        [LogoGreenBlack]
        [Index]

        [Terms.Antilatency_Device_Network]
        [Hardware.Alt]
        [Internal.Debug]
        [CsmlPredefined.Diagnostics]
        [Software.Antilatency_Service]

        [Store.PresetEditor]
        [Sdk.Configurator]
        [Api.Material]
        ;
    public static LanguageMenu LanguageMenu => new LanguageMenu();


    public static Footer CommonFooter => new Footer()
        [new FooterMenu()
            [LogoGreenBlack]
        ]
        
        [new FooterMenu()
            [new FooterMenuSection("SECTION 1")
                [new UnorderedList()
                    [Terms.Antilatency_Device_Network]
                    [Hardware.Alt]
                    [Internal.Debug]
                    [CsmlPredefined.Diagnostics]
                    [Software.Antilatency_Service]
                ]
            ]

            [new FooterMenuSection("SECTION 2")
                [new UnorderedList()
                    [Store.PresetEditor]
                    [Sdk.Configurator]
                    [Api.Material]
                ]
            ]

            [new FooterMenuSection("")
                [$"Copyright © 2020, ALT LLC. info@antilatency.com"]
            ]
        ]

        ;

}

