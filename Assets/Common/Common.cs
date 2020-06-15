using System.Collections.Generic;
using Csml;
using System.Linq;
using HtmlAgilityPack;
using static Root.Common_Assets;


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
            [new Section("Products")
                [new UnorderedList()
                    [HardwareProducts]
                ]
            ]

             [new Section("Customer Support")
                [new UnorderedList()
                    [new ExternalReference("https://antilatency.com", "Get Started")]
                    [new ExternalReference("https://antilatency.com", "Care Center")]
                    [new ExternalReference("https://antilatency.com", "Downloads")]
                ]
            ]

            [new Section("For Developers")
                [new UnorderedList()
                    [new ExternalReference("https://antilatency.com", "API")]
                    [new ExternalReference("https://antilatency.com", "Tutorials")]
                    [new ExternalReference("https://antilatency.com", "Tools")]
                ]
            ]

            [new Section("Company")
                [new UnorderedList()
                    [new ExternalReference("https://antilatency.com", "About")]
                    [new ExternalReference("https://antilatency.com", "Contact Us")]
                    [new ExternalReference("https://antilatency.com", "Become a partner")]
                ]
            ]   
        ]


        [$"{new ExternalReference("https://antilatency.com", "Personal data processing policy")} | {new ExternalReference("https://antilatency.com", "Terms of Services")} | Copyright © {CopyrightYear}, ALT LLC. info@antilatency.com"]
        ;

}

