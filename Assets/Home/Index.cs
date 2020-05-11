using Csml;
public partial class Root {
    public static LanguageSelector<IMaterial> Index => new LanguageSelector<IMaterial>();
    public partial class Index_Assets : Scope {
        public static YoutubeVideo SquareVideo => new YoutubeVideo("_xKCwzgI68s",1);
        public static YoutubeVideo TitleVideo => new YoutubeVideo("szSk7IaUUa0");


    }

}