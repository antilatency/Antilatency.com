using System.Collections.Generic;
using Csml;
using HtmlAgilityPack;


namespace Csml {
    partial class Scope {
        public static ITemplate Template => new Csml.TemplateRegularMaterial(Root.MainMenu)
            [Root.LanguageMenu]
            [Root.Footer]
            ;
    }

    
}


partial class Root : Scope {

    public new static ITemplate Template => new Csml.TemplateLanding(MainMenu)
        [Root.LanguageMenu]
        [Root.Footer]
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


    public static Footer Footer => new Footer()
        [new Grid(250, 1, 2, 3, 4)
            [LogoGreenBlack]

            [new Section("SECTION 1")
                [new UnorderedList()
                    [Terms.Antilatency_Device_Network]
                    [Hardware.Alt]
                    [Internal.Debug]
                    [CsmlPredefined.Diagnostics]
                    [Software.Antilatency_Service]
                ]
            ]

            [new Section("SECTION 2")
                [new UnorderedList()
                    [Store.PresetEditor]
                    [Sdk.Configurator]
                    [Api.Material]
                ]
            ]

            [$"Copyright © 2020, ALT LLC. info@antilatency.com"]
        ]
        ;

}

