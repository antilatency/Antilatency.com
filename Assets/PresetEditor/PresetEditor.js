function PresetEditor(presetEditor) {
    var _this = this;

    //window.addEventListener("hashchange", funcRef, false);
    console.log(location.hash)

    var sourceJson =
        `{
            "Demo: 10 FullbodyUsingPicoG2~1":{
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

            //UpdateGroupPriceTitles(group, groupPrice, groupPriceTotal);

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

        var UpdateCheckoutPrices = function (total) {
            const discount = Object.entries(productsQuantity)
                                    .map(([k, v]) => Store.GetProductUnitPrice(k, 1).productPrice * v)
                                    .reduce((r, v) => r + v, 0) - total;

            document.querySelector("#totalDiscount").textContent = "$" + discount;
            document.querySelector("#totalPrice").textContent = "$" + total;
        }

        CountProducts(presetEditorRootGroup, 1);
        UpdateProductsViewPrices();
        UpdateCheckoutPrices(UpdateGroupPricesRecursively(presetEditorRootGroup));
    }

    function EnableDragAndDrop() {
        var pointedElement = null;
        var pointedGroup = null;
        var draggedItem = null;
        var draggedItemName = "";
        var draggedItemIsProduct = false;
        var draggedItemFromProductsView = false;
        var draggedItemPlaceholder = null;

        var IsDraggable = (element) => !IsEmptyObject(element) && element.classList.contains("DragArea");
        var IsDropArea = (element) => !IsEmptyObject(element) && element.classList.contains("DropArea");
        var IsDropAreaForRemoveItem = (element) => !IsEmptyObject(element) && element.classList.contains("DropAreaRemoveItem");

        var DragStart = function (event) {
            if (IsDraggable(event.target)) {
                draggedItem = GetClosestParent(event.target, "item");
                draggedItemName = draggedItem.getAttribute("name");
                draggedItemIsProduct = draggedItem.classList.contains("Product") && draggedItemName != "Group";
                draggedItemFromProductsView = GetClosestParent(draggedItem, ".ProductsView") != null;

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
            var x = 0, y = 0;
            var isTouchEvent = false;

            if (event.type === "touchmove") {
                x = event.touches[0].clientX || 0;
                y = event.touches[0].clientY || 0;

                isTouchEvent = true;
            } else {
                x = event.clientX || 0;
                y = event.clientY || 0;
            }


            pointedElement = document.elementFromPoint(x, y);

            var group = GetClosestParent(pointedElement, ".Group"); 

            if (pointedGroup != group) {
                pointedGroup && pointedGroup.classList.remove("PointedGroup");
                pointedGroup = group;
                pointedGroup && pointedGroup.classList.add("PointedGroup");

            }

            if (!IsEmptyObject(draggedItem)) {
                if (isTouchEvent) {
                    event.preventDefault();
                }

                draggedItem.style.left = x + 'px';
                draggedItem.style.top = y + 40 + 'px';
            }
        }

        var Drop = function (dropArea) {
            if (IsEmptyObject(draggedItem)) {
                return;
            }

            if (IsDropAreaForRemoveItem(dropArea)) {
                if (!draggedItemFromProductsView) {
                    draggedItem.parentNode.removeChild(draggedItem);
                    draggedItem = null;

                    UpdatePrices();
                }
            } else if (IsDropArea(dropArea)) {
                let target = GetClosestParent(dropArea, ".Group");
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

            Drop(event.type === "touchend" ? pointedElement : event.target);

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


        var supportsPassive = false;
        try {
            window.addEventListener("test", null, Object.defineProperty({}, 'passive', {
                get: () => supportsPassive = true
            }));
        } catch (e) { }

        var touchOpt = supportsPassive ? { passive: false } : false;

        document.addEventListener("touchstart", DragStart, touchOpt);
        document.addEventListener("touchmove", Drag, touchOpt);
        document.addEventListener("touchend", DragEnd, touchOpt);

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

    this.CreateItem = function (parent, name, quantity, className) {
        var item = parent.appendChild(document.createElement("item"));
        item.setAttribute("quantity", quantity);
        item.setAttribute("name", name);

        item.className = className;

        return item;
    }

    this.CreateProductItem = function (parent, name, quantity) {
        var item = this.CreateItem(parent, name, quantity, "Product");

        const defaultImage = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAIAAACQd1PeAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAAMSURBVBhXY2BgYAAAAAQAAVzN/2kAAAAASUVORK5CYII=";

        var productView = item.appendChild(CreateElement("div", "ProductViewContainer"));
        var badge = productView.appendChild(CreateElement("div", "ProductBadge DragArea DropArea"));
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
        var head = group.appendChild(CreateElement("div", "GroupHead DragArea DropArea"));

        var title = head.appendChild(CreateElement("div", "GroupTitle DropArea"));
        var titleEditor = head.appendChild(CreateElement("input", "GroupTitleEditor Hide"));
        title.textContent = name;
        titleEditor.value = name;

        var counter = head.appendChild(CreateElement("div", "GroupCounter DropArea"));
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


    this.CreateGroupItem = function (parent, rawName, isRoot) {
        var nameParsed = rawName.match(/^([^~]*)(~(\d+))?$/);
        if (nameParsed == null) throw new Error("Invalid group name:" + rawName);
        var name = nameParsed[1];

        if (!isRoot) {
            var quantity = (nameParsed[3] != undefined) ? parseInt(nameParsed[3], 10) : 1;

            var item = this.CreateItem(parent, name, quantity, "Group DragArea");

            item.appendChild(CreateElement("div", "GroupSpacer"));

            CreateGroupHead(item, name, quantity);
            item.appendChild(CreateElement("div", "GroupContainer DragArea DropArea"));

            return item;
        } else {
            var item = this.CreateItem(parent, name, 1, "Group RootGroup");
            var container = item.appendChild(CreateElement("div", "GroupContainer DropArea"));

            container.style.height = "100%";

            return item;
        }
    }

    this.ObjToDom = function (parent, obj, createRootGroup) {
        var keys = Object.keys(obj);
        for (let i = 0; i < keys.length; i++) {
            var value = obj[keys[i]];
            if (typeof (value) == "number") {
                this.CreateProductItem(parent.querySelector(".GroupContainer"), keys[i], value);
            } else {
                if (typeof (value) == "object") {
                    let group = this.CreateGroupItem(parent.querySelector(".GroupContainer") || parent, keys[i], createRootGroup);
                    this.ObjToDom(group, value, false);
                }
            }
        }
    }


    this.CreatePresetEditorTree = function (parent, presetJson) {
        var presetEditorTree = parent.appendChild(document.createElement("div"));
        presetEditorTree.className = "PresetEditorTree";
        presetEditorTree.style.overflow = "auto";

        this.ObjToDom(presetEditorTree, JSON.parse(presetJson), true);
    }

    this.CreateProductsList = function (parent) {
        var productsView = parent.appendChild(CreateElement("div", "ProductsView"));
        productsView.style.overflow = "auto";

        var container = productsView.appendChild(CreateElement("div", "ProductsContainer"));

        container.appendChild(CreateElement("div", "DropAreaRemoveItem"));

        var keys = Object.keys(Store.PRODUCTS);
        for (let i = 0; i < keys.length; i++) {
            this.CreateProductItem(container, keys[i], 1);
        }

        //this.CreateGroupItem(container, "Group");
        //this.CreateProductItem(container, "Group", 1);
    }

    function CreateCheckoutPanel(parent) {
        var panel = parent.appendChild(CreateElement("div", "CheckoutPanel"));

        var priceTitlesBlock = panel.appendChild(CreateElement("div", "PriceBlock"));
        var discountTitle = priceTitlesBlock.appendChild(CreateElement("div", "Title"));
        var totalTitle = priceTitlesBlock.appendChild(CreateElement("div", "Title"));

        var pricesBlock = panel.appendChild(CreateElement("div", "PriceBlock"));
        var discount= pricesBlock.appendChild(CreateElement("div", "Price"));
        var totalPrice = pricesBlock.appendChild(CreateElement("div", "Price"));


        var buy = panel.appendChild(CreateElement("div", "BuyButton"));

        discountTitle.textContent = "Discount:";
        totalTitle.textContent = "Total:";

        discount.textContent = "$000";
        totalPrice.textContent = "$000";

        discount.id = "totalDiscount";
        totalPrice.id = "totalPrice";

        buy.textContent = "Buy";
        buy.onclick = () => alert("No");
    }

    presetEditor.style.overflow = "auto";

    var workspace = presetEditor.appendChild(CreateElement("div", "EditorWorkspace"));

    this.CreateProductsList(workspace);
    this.CreatePresetEditorTree(workspace, sourceJson);
    CreateCheckoutPanel(presetEditor);

    UpdatePrices();
    EnableDragAndDrop();


    this.Head = new RegExp('((".+")|(\w+))\s*(\:\s*\d+)?\s*');


    this.OnWindowResize = function () {

    }

    this.OnDOMContentLoaded = function (event) {
        this.OnWindowResize();
    }

}