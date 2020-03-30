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
}