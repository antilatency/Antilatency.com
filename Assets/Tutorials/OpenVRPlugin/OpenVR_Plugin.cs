using Csml;


partial class Tutorials : Scope {
    public static LanguageSelector<IMaterial> OpenVR_Plugin => new LanguageSelector<IMaterial>();
    public partial class OpenVR_Plugin_Assets : Scope {
        public static Code DirectoryStructure => new Code(@"antilatency/
├── bin /
│   └── ...
├── resources /
│   └── ...
└── driver.vrdrivermanifest", ProgrammingLanguage.Markdown);

        public static Code SteamVrConfigExample => Code.FromFile("steamvr.json", ProgrammingLanguage.JavaScript);

        public static Image CreateSystemReportScreen => new Image("steamvr_create_system_report.png");
        public static Image SystemReportScreen => new Image("steamvr_system_report.png");
    }



}