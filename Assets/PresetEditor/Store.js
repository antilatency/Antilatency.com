
function Store() {
    this.products = {
        ACHA0Alt__A: {
            Name: "Alt",
            Prices: [{ From: 1, Price: 650 }, { From: 4, Price: 598 }, { From: 16, Price: 550 }, { From: 64, Price: 506 }, { From: 256, Price: 466 }, { From: 1024, Price: 428 }]
        },
        ACHA0Socket__A: {
            Name: "USB PC Socket",
            Prices: [{ From: 1, Price: 50 }, { From: 4, Price: 46 }, { From: 16, Price: 42 }, { From: 64, Price: 39 }, { From: 256, Price: 36 }, { From: 1024, Price: 33 }]
        },
        ACHA0RadioSocket__A: {
            Name: "HMD Radio Socket",
            Prices: [{ From: 1, Price: 75 }, { From: 4, Price: 69 }, { From: 16, Price: 63 }, { From: 64, Price: 58 }, { From: 256, Price: 54 }, { From: 1024, Price: 49 }]
        },
        ACHA0Socket__RA: {
            Name: "Tag",
            Prices: [{ From: 1, Price: 75 }, { From: 4, Price: 69 }, { From: 16, Price: 63 }, { From: 64, Price: 58 }, { From: 256, Price: 54 }, { From: 1024, Price: 49 }]
        },
        ACHA0Bracer__RA: {
            Name: "Bracer",
            Prices: [{ From: 1, Price: 90 }, { From: 4, Price: 83 }, { From: 16, Price: 76 }, { From: 64, Price: 70 }, { From: 256, Price: 64 }, { From: 1024, Price: 59 }]
        },
        ACHA0PicoG2Socket__A: {
            Name: "Pico G2 Socket",
            Prices: [{ From: 1, Price: 75 }, { From: 4, Price: 69 }, { From: 16, Price: 63 }, { From: 64, Price: 58 }, { From: 256, Price: 54 }, { From: 1024, Price: 49 }]
        },
        TrackingArea10m2: {
            Name: "Tracking area 10m2",
            Prices: [{ From: 1, Price: 250 }]
        },

        Group: {
            Name: "Group",
            Prices: [{ From: 1, Price: 0 }]
        }
    };

    this.GetProductName = function(productId) {
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

            if (priceInfo.From <= productQuantityGlobal) {
                if (productPriceOld == 0 || productPrice == 0) {
                    productPriceOld = Math.max(productPriceOld, productPrice);
                } else {
                    productPriceOld = Math.min(productPriceOld, productPrice);
                }

                productPrice = priceInfo.Price;
            }
        }

        if (productPriceOld == 0) {
            productPriceOld = productPrice;
        }

        return { productPrice, productPriceOld };
    }

}