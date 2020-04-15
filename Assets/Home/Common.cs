using System.Collections.Generic;
using Csml;
using HtmlAgilityPack;

partial class Root : Scope {
    

    public Root() {
        Material.DefaultTemplate = RegularPage;
    }


    


    

    static Menu MainMenu => new Menu()
        [Logo40Black]
        [Index]
        [Antilatency_Device_Network]
        [Alt]
        [Internal.Debug]
        [CsmlPredefined.ToggleButton]
        ;
    static LanguageMenu LanguageMenu => new LanguageMenu();

    static Template RegularPage => new Template(
        new Collection()
            [MainMenu]
            [LanguageMenu]
        ,
        null
        );



    

    //public AntilatencyGitHubGroup AntilatencyGitHub => new AntilatencyGitHubGroup();


}

