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
    public new static ITemplate Template => new Csml.TemplateLanding(MainMenu);

    //public Root() {
        //Material.DefaultTemplate = RegularPage;
    //}


    public static Menu MainMenu => new Menu()
        [Logo40Black]
        [Index]
        [Store.PresetEditor]
        [Terms.Antilatency_Device_Network]
        [Hardware.Alt]
        [Internal.Debug]
        [CsmlPredefined.Diagnostics]
        ;
    public static LanguageMenu LanguageMenu => new LanguageMenu();




}

