using Htmlilka;
using System.Collections.Generic;

namespace Csml {

    public sealed class PresetEditor : PresetEditor<PresetEditor> { 
        
    }

    public class PresetEditorBehaviour : Behaviour {
        public PresetEditorBehaviour() : base("PresetEditor") { 
        }
    }

    public class PresetEditor<T> : Element<T> where T : PresetEditor<T> {
        public override Node Generate(Context context) {
            return new Tag("div")
                .AddClasses("PresetEditor")
                .Add(new PresetEditorBehaviour().Generate(context));
        }
    }
}