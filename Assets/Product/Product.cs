using HtmlAgilityPack;
using System.Collections.Generic;
using System.Reflection;

namespace Csml {



    /*public class PresetEditorBehaviour : Behaviour {
        public PresetEditorBehaviour() : base("PresetEditor") {
        }
    }*/
    public class ProductName {
        
    }


    public class Product : Element<Product> {
        List<KeyValuePair<int, float>> priceBreaks = new List<KeyValuePair<int, float>>();

        public Product(ILanguageSelector<IMaterial> description, float initialPrice) { 
            
        }

        public Product AddPriceBreak(int quantity, float price) {
            priceBreaks.Add(new KeyValuePair<int, float>(quantity, price));
            return this;
        }

        public override void AfterInitialization(PropertyInfo propertyInfo) {
            base.AfterInitialization(propertyInfo);

        }

        public override IEnumerable<HtmlNode> Generate(Context context) {
            yield return HtmlNode.CreateNode("<div>").Do(x => {
                x.AddClass("PresetEditor");
                x.Add(new PresetEditorBehaviour().Generate(context));
            });
        }
    }
}