using System.Collections.Generic;
using Csml;
using HtmlAgilityPack;


namespace Csml {
    partial class Scope {
        public static ITemplate Template => new Csml.TemplateRegularMaterial(Root.MainMenu)
            [Root.LanguageMenu]
            ;
    }

    
}


partial class Root : Scope {
    //public new static Template Template => Landing;

    //public Root() {
        //Material.DefaultTemplate = RegularPage;
    //}


    


    

    public static Menu MainMenu => new Menu()
        [Logo40Black]
        [Index]
        [Terms.Antilatency_Device_Network]
        [Terms.Alt]
        [Internal.Debug]
        [CsmlPredefined.Diagnostics]
        ;
    public static LanguageMenu LanguageMenu => new LanguageMenu();

    


    /*public static Template RegularPage => new Template(
        new Collection()
            [MainMenu]
            [LanguageMenu]
        ,
        null
        );

    static Template Landing => new Template(
        new Collection()
            [MainMenu]
            [LanguageMenu]
        ,
        null
        );*/



    //public AntilatencyGitHubGroup AntilatencyGitHub => new AntilatencyGitHubGroup();


}

