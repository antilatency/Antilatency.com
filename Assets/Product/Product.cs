using Htmlilka;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Csml {

    public class Product : Element<Product> {
        private ILanguageSelector<IMaterial> _description = null;
        private string _id;
        private List<KeyValuePair<int, float>> _priceBreaks = new List<KeyValuePair<int, float>>();

        public Product(ILanguageSelector<IMaterial> description, string id, float initialPrice) {
            _description = description;
            _id = id;
            _priceBreaks.Add(new KeyValuePair<int, float>(1, initialPrice));
        }

        public Product AddPriceBreak(int quantity, float price) {
            _priceBreaks.Add(new KeyValuePair<int, float>(quantity, price));
            
            return this;
        }

        public override void AfterInitialization(PropertyInfo propertyInfo) {
            base.AfterInitialization(propertyInfo);
        }

        public override Node Generate(Context context) {
            var material = _description[context.Language];
            var name = material != null ? material.Title : _description.Title;
            var materialImage = material != null ? material.TitleImage : null;

            var data = new Tag("product-data")
                .AddClasses("ProductData")
                .Attribute("id", _id)
                .Attribute("name", name);


            if (materialImage != null) {
                var cache = materialImage.GetCache();
                var image = new Tag("image")
                    .Attribute("source", cache.GetFileUri(cache.Mips.First().Value).ToString())
                    .Attribute("aspect", cache.Aspect.ToString());

                if (cache.Roi != null) {
                    image.Attribute("roi", Newtonsoft.Json.JsonConvert.SerializeObject(cache.Roi));
                }

                data.Add(image);
            }

            foreach (var kv in _priceBreaks) {
                data.Add(new Tag("price")
                    .Attribute("count", kv.Key.ToString())
                    .AddText(kv.Value.ToString())
                );
            }

            return data;
        }
    }
}