using System.Collections.Generic;
using Csml;
using HtmlAgilityPack;


namespace Csml {
    partial class Scope {
        public static ITemplate Template => new Root.RegularPage();
    }
}


partial class Root : Scope {
    //public new static Template Template => Landing;

    //public Root() {
        //Material.DefaultTemplate = RegularPage;
    //}


    


    

    static Menu MainMenu => new Menu()
        [Logo40Black]
        [Index]
        [Terms.Antilatency_Device_Network]
        [Terms.Alt]
        [Internal.Debug]
        [CsmlPredefined.Diagnostics]
        [CsmlPredefined.ToggleButton]
        ;
    static LanguageMenu LanguageMenu => new LanguageMenu();

    public class RegularPage : Template {
        public override void ModifyBody(HtmlNode x, Context context, IMaterial material) {
            base.ModifyBody(x, context, material);
            x.Add(MainMenu.Generate(context));
            x.Add(LanguageMenu.Generate(context));
        }
    }


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

