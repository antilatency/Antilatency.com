namespace Csml {
    
    public partial class Language {
        [GetOnce]
        public static Language En => new Language("en");
        [GetOnce]
        public static Language Ru => new Language("ru");
    }
}