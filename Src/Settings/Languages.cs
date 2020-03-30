namespace Csml {
    
    public partial class Language {
        [GetOnce]
        public static Language En => new Language("en","English");
        [GetOnce]
        public static Language Ru => new Language("ru","Русский");
        [GetOnce]
        public static Language Ch => new Language("ch","中文");
    }
}