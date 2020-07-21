function PresetEditor(presetEditor) {
    var _this = this;

    //window.addEventListener("hashchange", funcRef, false);
    console.log(location.hash)

    var sourceJson =
        `{
            "Demo: 10 FullbodyUsingPicoG2~2":{
                "Fullbody~10":{
                    "Head":{
                        "ACHA0Alt__A":1,
						"ACHA0PicoG2Socket__A": 1
                    },
                    "Hand~2":{
                        "ACHA0Alt__A":1,
                        "ACHA0Bracer__RA":1
                    },
                    "Leg~2":{
                        "ACHA0Alt__A":1,
                        "ACHA0Socket__RA":1
                    }
                },
                "TrackingArea10m2":10
            }
        
        }`;

    function IsEmptyObject(obj) {
        if (obj && obj !== null && obj !== undefined) {
            return false;
        }

        return true;
    }

    function GetClosestParent(element, selector) {
        for (; element && element !== document; element = element.parentNode) {
            if (element.matches(selector)) {
                return element;
            }
        }

        return null;
    }

    function CreateElement(tag, className) {
        var element = document.createElement(tag);
        element.className = className;

        return element;
    }

    function UpdatePrices() {
        var productsQuantity = {}
        var presetEditorRootGroup = document.querySelector(".PresetEditorTree > .Group");

        var UpdateGroupPriceTitles = function (item, price, priceTotal) {
            /*var priceTitle = item.querySelector("div#price");
            var priceTotalTitle = item.querySelector("div#priceTotal");

            priceTitle.textContent = "$" + price;
            priceTotalTitle.textContent = "$" + priceTotal;*/
        }

        var UpdateProductPriceTitles = function (item, price, priceTotal, priceOld, quantity) {
            var priceTitle = item.querySelector("div#price");
            var priceTotalTitle = item.querySelector("div#priceTotal");
            var priceBreakTitle = item.querySelector("div#priceBreak");

            priceTitle.textContent = "$" + price;

            if (!IsEmptyObject(priceTotalTitle)) {
                if (quantity > 1) {
                    priceTotalTitle.classList.remove("Hide");
                    priceTotalTitle.textContent = "$" + price + " x " + quantity + " = $" + priceTotal;
                } else {
                    priceTotalTitle.classList.add("Hide");
                }
            }

            if (!IsEmptyObject(priceBreakTitle)) {
                if (price != priceOld) {
                    priceBreakTitle.classList.remove("Hide");
                    priceBreakTitle.textContent = "$" + priceOld;
                } else {
                    priceBreakTitle.classList.add("Hide");
                }
            }
        }

        var CountProducts = function (group, quantityMultiplier) {
            var groups = group.querySelectorAll(":scope > .GroupContainer > .Group");
            var products = group.querySelectorAll(":scope > .GroupContainer > .Product");

            quantityMultiplier *= group.getAttribute("quantity");

            for (let i = 0; i < products.length; i++) {
                var productName = products[i].getAttribute("name");
                var productQuantity = products[i].getAttribute("quantity");

                if (productsQuantity.hasOwnProperty(productName)) {
                    productsQuantity[productName] = productsQuantity[productName] + (productQuantity * quantityMultiplier);
                } else {
                    productsQuantity[productName] = productQuantity * quantityMultiplier;
                }
            }

            for (let i = 0; i < groups.length; i++) {
                CountProducts(groups[i], quantityMultiplier);
            }
        }

        var UpdateGroupPricesRecursively = function (group) {
            var groups = group.querySelectorAll(":scope > .GroupContainer > .Group");
            var products = group.querySelectorAll(":scope > .GroupContainer > .Product");

            var groupPrice = 0;

            for (let i = 0; i < groups.length; i++) {
                groupPrice += UpdateGroupPricesRecursively(groups[i]);
            }

            for (let i = 0; i < products.length; i++) {
                var product = products[i];
                var productName = product.getAttribute("name");
                var productQuantity = product.getAttribute("quantity");
                var productQuantityGlobal = productsQuantity[productName];
                const { productPrice, productPriceOld } = Store.GetProductUnitPrice(productName, productQuantityGlobal);

                product.setAttribute("price", productPrice);

                var productPriceTotal = productPrice * productQuantity;

                groupPrice += productPriceTotal;

                UpdateProductPriceTitles(product, productPrice, productPriceTotal, productPriceOld, productQuantity);
            }

            group.setAttribute("price", groupPrice);

            var groupPriceTotal = groupPrice * group.getAttribute("quantity");

            UpdateGroupPriceTitles(group, groupPrice, groupPriceTotal);

            return groupPriceTotal;
        }

        var UpdateProductsViewPrices = function () {
            var products = document.querySelector(".ProductsView").querySelectorAll(".Product");

            for (let i = 0; i < products.length; i++) {
                var product = products[i];
                var productName = product.getAttribute("name");
                var productQuantityGlobal = productsQuantity[productName];
                const { productPrice, productPriceOld } = Store.GetProductUnitPrice(productName, productQuantityGlobal);

                product.setAttribute("price", productPrice);

                UpdateProductPriceTitles(product, productPrice, productPrice, productPriceOld, 1);
            }
        }

        CountProducts(presetEditorRootGroup, 1);
        UpdateGroupPricesRecursively(presetEditorRootGroup);
        UpdateProductsViewPrices();
    }

    function EnableDragAndDrop() {
        var draggedItem = null;
        var draggedItemName = "";
        var draggedItemIsProduct = false;
        var draggedItemFromProductsView = false;
        var draggedItemPlaceholder = null;

        var IsDraggable = (element) => !IsEmptyObject(element) && element.classList.contains("DragArea");
        var IsDropArea = (element) => !IsEmptyObject(element) && element.classList.contains("DropArea");

        var DragStart = function (event) {
            if (IsDraggable(event.target)) {
                draggedItem = GetClosestParent(event.target, "item");
                draggedItemName = draggedItem.getAttribute("name");
                draggedItemIsProduct = draggedItem.classList.contains("Product");
                draggedItemFromProductsView = draggedItem.parentElement.classList.contains("ProductsView");

                presetEditor.classList.add("ItemInTheAir");

                draggedItemPlaceholder = document.createElement("div");
                draggedItemPlaceholder.className = "ItemPlaceholder";
                //draggedItemPlaceholder.className = draggedItemIsProduct ? "ProductCardPlaceholder" : "DragPlaceholder"
                draggedItemPlaceholder.style.width = draggedItem.offsetWidth + "px";
                draggedItemPlaceholder.style.height = draggedItem.offsetHeight + "px";

                draggedItem.parentElement.insertBefore(draggedItemPlaceholder, draggedItem);

                draggedItem.classList.add("Dragged");

                Drag(event);
            }
        }

        var Drag = function (event) {
            if (!IsEmptyObject(draggedItem)) {
                var left = 0, top = 0;

                if (event.type === "touchmove") {
                    left = event.touches[0].clientX;
                    top = event.touches[0].clientY;
                } else {
                    left = event.clientX;
                    top = event.clientY;
                }

                draggedItem.style.left = left + 'px';
                draggedItem.style.top = top + 40 + 'px';
            }
        }

        var Drop = function (event) {
            if (IsDropArea(event.target) && !IsEmptyObject(draggedItem)) {
                let target = GetClosestParent(event.target, ".Group");
                let container = target.querySelector(".GroupContainer");
                let dropToTarget = true;

                if (draggedItemIsProduct) {
                    let sameItemInTargetGroup = container.querySelector(":scope > item[name=\"" + draggedItemName + "\"]");

                    if (!IsEmptyObject(sameItemInTargetGroup)) {
                        if (sameItemInTargetGroup != draggedItem) {
                            let newQuantityValue = Number(draggedItem.getAttribute("quantity")) +
                                Number(sameItemInTargetGroup.getAttribute("quantity"));

                            sameItemInTargetGroup.setAttribute("quantity", newQuantityValue);
                            sameItemInTargetGroup.querySelector("input#counter").value = newQuantityValue;

                            if (!draggedItemFromProductsView) {
                                draggedItem.parentNode.removeChild(draggedItem);
                                draggedItem = null;
                            }
                        }

                        dropToTarget = false;
                    }
                }

                if (dropToTarget) {
                    if (draggedItemFromProductsView) {
                        if (draggedItemIsProduct) {
                            container.insertBefore(_this.CreateProductItem(container, draggedItemName, 1), container.firstChild);
                        } else {
                            container.insertBefore(_this.CreateGroupItem(container, draggedItemName), container.firstChild);
                        }
                    } else {
                        container.insertBefore(draggedItem, container.firstChild);
                    }
                }

                UpdatePrices();
            }
        }

        var DragEnd = function (event) {
            presetEditor.classList.remove("ItemInTheAir");

            Drop(event);

            if (!IsEmptyObject(draggedItem)) {
                draggedItem.classList.remove("Dragged");
                draggedItem.style.left = 0;
                draggedItem.style.top = 0;
                draggedItem = null;
            }

            if (!IsEmptyObject(draggedItemPlaceholder)) {
                draggedItemPlaceholder.parentNode.removeChild(draggedItemPlaceholder);
                draggedItemPlaceholder = null;
            }
        }


        document.addEventListener("touchstart", DragStart, false);
        document.addEventListener("touchmove", Drag, false);
        document.addEventListener("touchend", DragEnd, false);

        document.addEventListener("mousedown", DragStart, false);
        document.addEventListener("mousemove", Drag, false);
        document.addEventListener("mouseup", DragEnd, false);
    }

    function CreateItemCounter(item, quantity) {
        var spinbox = new Spinbox(quantity, "counter", (value) => {
            item.setAttribute("quantity", value);
            UpdatePrices();
        });

        return spinbox.container;
    }

    this.CreateItem = function (parent, name, quantity) {
        var item = parent.appendChild(document.createElement("item"));
        item.setAttribute("quantity", quantity);
        item.setAttribute("name", name);

        return item;
    }

    this.CreateProductItem = function (parent, name, quantity) {
        var item = this.CreateItem(parent, name, quantity);
        item.className = "Product";

        const defaultImage = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAIAAACQd1PeAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAAMSURBVBhXY2BgYAAAAAQAAVzN/2kAAAAASUVORK5CYII=";

        var productView = item.appendChild(CreateElement("div", "ProductViewContainer"));
        var badge = productView.appendChild(CreateElement("div", "ProductBadge DragArea"));
        var badgeImage = badge.appendChild(CreateElement("img", "ProductBadgeImage"));
        var badgeTitle = badge.appendChild(CreateElement("div", "ProductBadgeTitle"));

        badgeImage.src = defaultImage;
        badgeTitle.textContent = Store.PRODUCTS[name].Name;

        var card = productView.appendChild(CreateElement("div", "ProductCard"));
        var cardContent = card.appendChild(CreateElement("div", "ProductCardContent DragArea"));
        var cardContentImage = cardContent.appendChild(CreateElement("img", "ProductCardImage"));
        var cardContentInfo = cardContent.appendChild(CreateElement("div", "ProductCardInfoBody"));
        var cardContentInfoPriceBreak = cardContentInfo.appendChild(CreateElement("div", "ProductCardPriceBreak"));
        var cardContentInfoPrice = cardContentInfo.appendChild(CreateElement("div", "ProductCardPrice"));
        var cardContentInfoTitle = cardContentInfo.appendChild(CreateElement("div", "ProductCardTitle"));
        var cardContentPriceTotal = cardContent.appendChild(CreateElement("div", "ProductCardPriceTotal"));

        var viewCounter = card.appendChild(CreateItemCounter(item, quantity));

        cardContentImage.src = defaultImage;

        cardContentInfoPriceBreak.textContent = "$000";
        cardContentInfoPriceBreak.id = "priceBreak";

        cardContentInfoPrice.textContent = "$000";
        cardContentInfoPrice.id = "price";

        cardContentInfoTitle.textContent = Store.PRODUCTS[name].Name;

        cardContentPriceTotal.textContent = "$000";
        cardContentPriceTotal.id = "priceTotal";

        return item;
    }

    function CreateGroupHead(group, name, quantity) {
        var head = group.appendChild(CreateElement("div", "GroupHead DragArea"));

        var title = head.appendChild(CreateElement("div", "GroupTitle"));
        var titleEditor = head.appendChild(CreateElement("input", "GroupTitleEditor Hide"));
        title.textContent = name;
        titleEditor.value = name;

        var dropArea = head.appendChild(CreateElement("span", "DropArea"));

        var counter = head.appendChild(CreateElement("div", "GroupCounter"));
        counter.id = "counter";
        counter.textContent = quantity;


        title.ondblclick = function (event) {
            titleEditor.classList.remove("Hide");
            titleEditor.focus();
            title.classList.add("Hide");
            counter.classList.add("Hide");
        };

        titleEditor.onchange = function () {
            group.setAttribute("name", titleEditor.value);
            title.textContent = titleEditor.value;
            titleEditor.blur();
        }

        titleEditor.onblur = function () {
            title.classList.remove("Hide");
            counter.classList.remove("Hide");
            titleEditor.classList.add("Hide");
        }

        return head;
    }


    this.CreateGroupItem = function (parent, rawName) {
        var nameParsed = rawName.match(/^([^~]*)(~(\d+))?$/);
        if (nameParsed == null) throw new Error("Invalid group name:" + rawName);
        var name = nameParsed[1];
        var quantity = (nameParsed[3] != undefined) ? parseInt(nameParsed[3], 10) : 1;

        var item = this.CreateItem(parent, name, quantity);
        item.className = "Group DragArea";
        item.appendChild(CreateElement("div", "GroupSpacer"));

        CreateGroupHead(item, name, quantity);
        item.appendChild(CreateElement("div", "GroupContainer"));

        return item;
    }

    this.ObjToDom = function (parent, obj) {
        var keys = Object.keys(obj);
        for (let i = 0; i < keys.length; i++) {
            var value = obj[keys[i]];
            if (typeof (value) == "number") {
                this.CreateProductItem(parent.querySelector(".GroupContainer"), keys[i], value);
            } else {
                if (typeof (value) == "object") {
                    let group = this.CreateGroupItem(parent.querySelector(".GroupContainer") || parent, keys[i]);
                    this.ObjToDom(group, value);
                }
            }
        }
    }

    this.CreateTitle = function (name) {
        var title = presetEditor.appendChild(document.createElement("h3"));
        title.textContent = name;
    }

    this.CreatePresetEditorTree = function (presetJson) {
        //this.CreateTitle("Editor");

        var presetEditorTree = presetEditor.appendChild(document.createElement("div"));
        presetEditorTree.className = "PresetEditorTree";
        presetEditorTree.style.overflow = "auto";

        this.ObjToDom(presetEditorTree, JSON.parse(presetJson));

        UpdatePrices();
    }

    this.CreateProductsList = function () {
        //this.CreateTitle("Products");

        var productsView = presetEditor.appendChild(document.createElement("div"));
        productsView.className = "ProductsView";
        productsView.style.overflow = "auto";

        var keys = Object.keys(Store.PRODUCTS);
        for (let i = 0; i < keys.length; i++) {
            this.CreateProductItem(productsView, keys[i], 1);
        }

        this.CreateGroupItem(productsView, "Group");
    }

    presetEditor.style.overflow = "auto";
    this.CreateProductsList();
    this.CreatePresetEditorTree(sourceJson);

    EnableDragAndDrop();


    this.Head = new RegExp('((".+")|(\w+))\s*(\:\s*\d+)?\s*');


    this.OnWindowResize = function () {

    }

    this.OnDOMContentLoaded = function (event) {
        this.OnWindowResize();
    }

}