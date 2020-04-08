using Csml;


partial class Root {

    static Material MissingPages {
        get {
            var result = new Material(null, null, $"");
            var refs = new Section("References");
            
            
            return result[refs];
        }
    }

}