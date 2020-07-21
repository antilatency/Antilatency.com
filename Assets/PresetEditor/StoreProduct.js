function CreateStoreProductCard(name, quantity) {
    var view = CreateElement("div", "ProductCard");
    var viewCard = view.appendChild(CreateElement("div", "ProductCardContent DragArea"));
    var viewCardImage = viewCard.appendChild(CreateElement("img", "ProductCardImage"));
    var viewCardInfo = viewCard.appendChild(CreateElement("div", "ProductCardInfoBody"));
    var viewCardInfoPriceBreak = viewCardInfo.appendChild(CreateElement("div", "ProductCardPriceBreak"));
    var viewCardInfoPrice = viewCardInfo.appendChild(CreateElement("div", "ProductCardPrice"));
    var viewCardInfoTitle = viewCardInfo.appendChild(CreateElement("div", "ProductCardTitle"));
    var viewCardPriceTotal = viewCard.appendChild(CreateElement("div", "ProductCardPriceTotal"));

    var viewCounter = view.appendChild(CreateItemCounter(item, quantity));

    viewCardImage.src = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAIAAACQd1PeAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAAMSURBVBhXY2BgYAAAAAQAAVzN/2kAAAAASUVORK5CYII=";

    viewCardInfoPriceBreak.textContent = "$000";
    viewCardInfoPriceBreak.id = "priceBreak";

    viewCardInfoPrice.textContent = "$000";
    viewCardInfoPrice.id = "price";

    viewCardInfoTitle.textContent = Store.PRODUCTS[name].Name;

    viewCardPriceTotal.textContent = "$000";
    viewCardPriceTotal.id = "priceTotal";

    return item;
}