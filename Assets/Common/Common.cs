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

    public new static ITemplate Template => new Csml.TemplateLanding(MainMenu)
        [Root.LanguageMenu]
            ;

    //public Root() {
        //Material.DefaultTemplate = RegularPage;
    //}


    public static Menu MainMenu => new Menu()
        [LogoGreenBlack]
        [Index]
        [Store.PresetEditor]
        [Sdk.Configurator]
        [Terms.Antilatency_Device_Network]
        [Hardware.Alt]
        [Internal.Debug]
        [CsmlPredefined.Diagnostics]
        [Software.Antilatency_Service]
        ;
    public static LanguageMenu LanguageMenu => new LanguageMenu();




}

