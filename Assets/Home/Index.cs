using Csml;
using System.Linq;

public partial class Root {
    public static LanguageSelector<IMaterial> Index => new LanguageSelector<IMaterial>();
    public partial class Index_Assets : Scope {
        public static YoutubeVideo TitleVideo => new YoutubeVideo("qj6S37xIqK0");

        public static IElement AllHardware => new Grid(320, 1, 2, 3, 4)
            [ScopeHelper.GetScopePropertiesOfType<Hardware, ILanguageSelector<IMaterial>>().Where(x=>x.HasTarget).Select(x => new MaterialCard(x))];
        public static IElement AllTutorials => new Grid(320, 1, 2, 3, 4)
            [ScopeHelper.GetScopePropertiesOfType<Tutorials, ILanguageSelector<IMaterial>>().Where(x => x.HasTarget).Select(x => new MaterialCard(x))];
        

    }

}