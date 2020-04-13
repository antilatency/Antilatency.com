using System.Collections.Generic;
using Csml;
using HtmlAgilityPack;

partial class Root : Scope<Root> {
    

    public Root() {
        Material.DefaultTemplate = RegularPage;
    }


    


    

    static Menu MainMenu => new Menu()
        [Logo40Black]
        [Index]
        [Antilatency_Device_Network]
        [Alt]
        //[MenuButton]
        ;
    static LanguageMenu LanguageMenu => new LanguageMenu();

    static Template RegularPage => new Template(
        new Collection()
            [MainMenu]
            [LanguageMenu]
        ,
        null
        );



    public class AntilatencyGitHub : Scope<AntilatencyGitHub> {
        static private Csml.GitHub.Owner Owner => new Csml.GitHub.Owner("antilatency");
        
        public class AntilatencyCom_Master : Scope<AntilatencyCom_Master> {
            static public Csml.GitHub.RepositoryBranch RepositoryBranch => Owner.GetRepositoryBranchPinned("Antilatency.com");
            static public CSharpCode Programm => new CSharpCode(RepositoryBranch.GetFile("Program.cs"));
        }
    }

    //public AntilatencyGitHubGroup AntilatencyGitHub => new AntilatencyGitHubGroup();


}