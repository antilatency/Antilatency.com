using Csml;


partial class Root {
    Material MissingPages {
        get {
            var result = new Material(null, null, $"");
            var refs = new Section("References");
            
            
            
            return result[refs];
        }
    }

}