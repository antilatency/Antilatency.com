
function Store() {
    this.products = {
        Group: {
            Name: "Group",
            Prices: [{ From: 1, Price: 0 }]
        }
    };

    document.querySelectorAll("product-data").forEach(data => {
        var product = Object.create({});
        product.Name = data.getAttribute("name");
        product.Prices = Array.prototype.map.call(data.querySelectorAll("price"), element => ({
            From: parseInt(element.getAttribute("count")),
            Price: parseFloat(element.textContent)
        }));

        var image = data.querySelector("img");

        if (image != null) {
            product.Image = Object.create({});

            product.Image.Source = image.getAttribute("source");
            product.Image.Aspect = parseFloat(image.getAttribute("aspect"));
            product.Image.Roi = JSON.parse(image.getAttribute("Roi"));
        }

        Object.defineProperty(this.products, data.getAttribute("id"), {
            value: product,
            writable: false,
            enumerable: true
        });
    });

    //console.log(this.products);

    this.GetProductImage = function (productId) {
        var productInfo = this.products[productId];

        return productInfo ? productInfo.Image : null;
    }

    this.GetProductName = function (productId) {
        var productInfo = this.products[productId];

        return productInfo ? productInfo.Name : "";
    }

    this.GetProductUnitPrice = function(productId, productQuantityGlobal) {
        if (isNaN(productQuantityGlobal) || Number(productQuantityGlobal) <= 0) {
            productQuantityGlobal = 1;
        }

        var productInfo = this.products[productId];
        var productPrice = 0;
        var productPriceOld = 0;

        for (let i = 0; i < productInfo.Prices.length; i++) {
            let priceInfo = productInfo.Prices[i];
            productPriceOld = Math.max(productPriceOld, priceInfo.Price);

            if (priceInfo.From <= productQuantityGlobal) {
                /*if (productPriceOld == 0 || productPrice == 0) {
                    productPriceOld = Math.max(productPriceOld, productPrice);
                } else {
                    productPriceOld = Math.min(productPriceOld, productPrice);
                }*/

                productPrice = priceInfo.Price;
            }
        }

        if (productPriceOld == 0) {
            productPriceOld = productPrice;
        }

        return { productPrice, productPriceOld };
    }

}