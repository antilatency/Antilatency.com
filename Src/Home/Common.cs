using Csml;


partial class Root : Scope<Root> {
    

    public Root() {
        Material.DefaultTemplate = RegularPage;
    }

    static Menu MainMenu => new Menu()
        [Index]
        [Antilatency_Device_Network]
        [Alt]
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
        static public Csml.GitHub.RepositoryBranch AntilatencyCom_Master => Owner.GetRepositoryBranchPinned("Antilatency.com");
    }

    //public AntilatencyGitHubGroup AntilatencyGitHub => new AntilatencyGitHubGroup();


}