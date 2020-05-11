using HtmlAgilityPack;
using System.Collections.Generic;

namespace Csml {

    public sealed class PresetEditor : PresetEditor<PresetEditor> { 
        
    }

    public class PresetEditorBehaviour : Behaviour {
        public PresetEditorBehaviour() : base("PresetEditor") { 
        }
    }

    public class PresetEditor<T> : Element<T> where T : PresetEditor<T> {
        public override IEnumerable<HtmlNode> Generate(Context context) {
            yield return HtmlNode.CreateNode("<div>").Do(x => {
                x.AddClass("PresetEditor");
                x.Add(new PresetEditorBehaviour().Generate(context));
            });
        }
    }
}