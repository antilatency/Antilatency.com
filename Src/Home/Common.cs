using Csml;

partial class Root {

    public Root() {
        Material.DefaultTemplate = RegularPage;
    }

    Menu MainMenu => new Menu()
        [Index]
        [Antilatency_Device_Network]
        [Alt]
        ;
    LanguageMenu LanguageMenu => new LanguageMenu();

    Template RegularPage => new Template(
        new Collection()
            [MainMenu]
            [LanguageMenu]
        ,
        null
        );


    [GetOnce]
    public class AntilatencyGitHubGroup {
        private Csml.GitHub.Owner Owner => new Csml.GitHub.Owner("antilatency");
        public Csml.GitHub.RepositoryBranch AntilatencyCom_Master => Owner.GetRepositoryBranchPinned("Antilatency.com");
    }

    public AntilatencyGitHubGroup AntilatencyGitHub => new AntilatencyGitHubGroup();


}