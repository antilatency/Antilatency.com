function PresetEditor(presetEditor) {
    var _this = this;

    //window.addEventListener("hashchange", funcRef, false);
    console.log(location.hash)

    const productsList = {
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
        }
    };

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

    function SetTextboxInputFilter(textbox, inputFilter) {
        ["input", "keydown", "keyup", "mousedown", "mouseup", "select", "contextmenu", "drop"].forEach(function (event) {
            textbox.addEventListener(event, function () {
                if (inputFilter(this.value)) {
                    this.oldValue = this.value;
                    this.oldSelectionStart = this.selectionStart;
                    this.oldSelectionEnd = this.selectionEnd;
                } else if (this.hasOwnProperty("oldValue")) {
                    this.value = this.oldValue;
                    this.setSelectionRange(this.oldSelectionStart, this.oldSelectionEnd);
                } else {
                    this.value = "";
                }
            });
        });
    }

    function GetProductUnitPrice(productName, productQuantityGlobal) {
        if (IsEmptyObject(productQuantityGlobal)) {
            productQuantityGlobal = 1;
        }

        var productInfo = productsList[productName];
        var productPrice = 0;
        var productPriceOld = 0;

        for (let i = 0; i < productInfo.Prices.length; i++) {
            let priceInfo = productInfo.Prices[i];

            if (priceInfo.From <= productQuantityGlobal) {
                productPrice = priceInfo.Price;
            } else if (priceInfo.Price > productPriceOld) {
                productPriceOld = priceInfo.Price;
            }
        }

        if (productPriceOld == 0) {
            productPriceOld = productPrice;
        }

        return { productPrice, productPriceOld };
    }

    function UpdatePrices() {
        var productsQuantity = {}
        var presetEditorRootGroup = document.querySelector(".PresetEditorTree > .Group");

        var UpdateGroupPriceTitles = function (item, price, priceTotal) {
            var priceTitle = item.querySelector("div#price");
            var priceTotalTitle = item.querySelector("div#priceTotal");

            priceTitle.textContent = "$" + price;
            priceTotalTitle.textContent = "$" + priceTotal;
        }

        var UpdateProductPriceTitles = function (item, price, priceTotal, priceOld, quantity) {
            var priceTitle = item.querySelector("div#price");
            var priceTotalTitle = item.querySelector("div#priceTotal");
            var priceBreakTitle = item.querySelector("div#priceBreak");

            priceTitle.textContent = "$" + price;
            priceTotalTitle.textContent = "$" + price + " x " + quantity + " = $" + priceTotal;

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
            var groups = group.querySelectorAll("item:scope > .Group");
            var products = group.querySelectorAll("item:scope > .Product");

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
            var groups = group.querySelectorAll("item:scope > .Group");
            var products = group.querySelectorAll("item:scope > .Product");

            var groupPrice = 0;

            for (let i = 0; i < groups.length; i++) {
                groupPrice += UpdateGroupPricesRecursively(groups[i]);
            }

            for (let i = 0; i < products.length; i++) {
                var product = products[i];
                var productName = product.getAttribute("name");
                var productQuantity = product.getAttribute("quantity");
                var productQuantityGlobal = productsQuantity[productName];
                const { productPrice, productPriceOld } = GetProductUnitPrice(productName, productQuantityGlobal);

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
                const { productPrice, productPriceOld } = GetProductUnitPrice(productName, productQuantityGlobal);

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
                draggedItemPlaceholder.className = draggedItemIsProduct ? "ProductCardPlaceholder" : "DragPlaceholder"
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
                let dropToTarget = true;

                if (draggedItemIsProduct) {
                    let sameItemInTargetGroup = target.querySelector("item:scope > [name=\"" + draggedItemName + "\"]");

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
                    let firstChildItem = target.children[1];

                    if (draggedItemFromProductsView) {
                        if (draggedItemIsProduct) {
                            target.insertBefore(_this.CreateProductItem(target, draggedItemName, 1), firstChildItem);
                        } else {
                            target.insertBefore(_this.CreateGroupItem(target, draggedItemName), firstChildItem);
                        }
                    } else {
                        target.insertBefore(draggedItem, firstChildItem);
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
        var body = CreateElement("div", "SpinboxBody");
        var dec = body.appendChild(CreateElement("div", "SpinboxButtonDec"));
        var input = body.appendChild(CreateElement("input", "SpinboxInput"));
        var inc = body.appendChild(CreateElement("div", "SpinboxButtonInc"));

        input.type = "text";
        input.id = "counter";
        input.value = quantity;

        SetTextboxInputFilter(input, (value) => /^\d+$/.test(value));

        var UpdateQuantity = function (quantity) {
            item.setAttribute("quantity", quantity);
            UpdatePrices();
        }

        input.onchange = function () {
            if (Number(input.value) == 0) {
                input.value = 1;
            }

            UpdateQuantity(input.value);
        }

        inc.onclick = function () {
            input.value = parseInt(input.value, 10) + 1;
            UpdateQuantity(input.value);
        }

        dec.onclick = function () {
            input.value = Math.max(parseInt(input.value, 10) - 1, 1);
            UpdateQuantity(input.value);
        }

        return body;
    }

    this.CreateUiRoot = function () {
        var ui = document.createElement("ui");

        var dragArea = ui.appendChild(document.createElement("span"));
        dragArea.className = "DragArea";

        return ui;
    }

    this.ValidateGroupName = function (name) {
        return name;
    }

    this.CreateCounterUi = function (parent, value, onChangeCallback) {
        var price = parent.appendChild(document.createElement("div"));
        price.textContent = "000$";
        price.className = "Price";
        price.id = "price";

        var counter = parent.appendChild(document.createElement("input"));
        counter.type = "number";
        counter.min = 1;
        counter.className = "ItemCounter";
        counter.id = "counter";
        counter.value = value;

        var priceTotal = parent.appendChild(document.createElement("div"));
        priceTotal.textContent = "000$";
        priceTotal.className = "PriceTotal";
        priceTotal.id = "priceTotal";

        counter.onchange = function () {
            var value = counter.value;

            if (!IsEmptyObject(onChangeCallback)) {
                onChangeCallback(value);
            }

            UpdatePrices();
        }

        return counter;
    }

    this.CreateGroupUi = function (item, name) {
        var ui = this.CreateUiRoot();

        var text = ui.appendChild(document.createElement("div"));
        text.textContent = name;
        text.className = "Title";

        var input = ui.appendChild(document.createElement("input"));
        input.value = name;
        input.style.display = "none";
        input.className = "Title";

        var dropArea = ui.appendChild(document.createElement("span"));
        dropArea.className = "DropArea";

        var quantity = this.CreateCounterUi(ui, item.getAttribute("quantity"), function (value) {
            item.setAttribute("quantity", value);
        });


        text.ondblclick = function (event) {
            input.style.display = "block";
            input.focus();
            text.style.display = "none";
        };



        input.oninput = function () {
            var name = _this.ValidateGroupName(input.value);
            input.value = name;
        }
        input.onchange = function () {
            item.setAttribute("name", input.value);
            text.textContent = input.value;
            input.blur();
        }
        input.onblur = function () {
            input.style.display = "none";
            text.style.display = "inline";
        }
        return ui;
    }

    this.CreateProductUi = function (item, name) {
        var ui = this.CreateUiRoot();
        var text = ui.appendChild(document.createElement("div"));
        text.textContent = name;
        text.className = "Title";

        var quantity = this.CreateCounterUi(ui, item.getAttribute("quantity"), function (value) {
            item.setAttribute("quantity", value);
        });

        return ui;
    }

    this.CreateItem = function (parent, name, quantity) {
        var item = document.createElement("item");
        item.setAttribute("quantity", quantity);
        item.setAttribute("name", name);
        parent.appendChild(item);
        return item;
    }

    this.CreateProductItem = function (parent, name, quantity) {
        var item = this.CreateItem(parent, name, quantity);
        item.className = "Product";
        //item.appendChild(this.CreateProductUi(item, productsList[name].Name));

        item.setAttribute("style", "padding: 0px!important; margin: 4px;");

        var view = item.appendChild(CreateElement("div", "ProductCard"));
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

        viewCardInfoTitle.textContent = productsList[name].Name;

        viewCardPriceTotal.textContent = "$000";
        viewCardPriceTotal.id = "priceTotal";

        return item;
    }


    this.CreateGroupItem = function (parent, rawName) {
        var nameParsed = rawName.match(/^([^~]*)(~(\d+))?$/);
        if (nameParsed == null) throw new Error("Invalid group name:" + rawName);
        var name = nameParsed[1];
        var quantity = (nameParsed[3] != undefined) ? parseInt(nameParsed[3], 10) : 1;

        var item = this.CreateItem(parent, name, quantity);
        item.className = "Group";
        item.appendChild(this.CreateGroupUi(item, name));

        return item;
    }

    this.ObjToDom = function (parent, obj) {
        var keys = Object.keys(obj);
        for (let i = 0; i < keys.length; i++) {
            var value = obj[keys[i]];
            if (typeof (value) == "number") {
                this.CreateProductItem(parent, keys[i], value);
            } else {
                if (typeof (value) == "object") {
                    let group = this.CreateGroupItem(parent, keys[i]);
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
        this.CreateTitle("Editor");

        var presetEditorTree = presetEditor.appendChild(document.createElement("div"));
        presetEditorTree.className = "PresetEditorTree";
        presetEditorTree.style.overflow = "auto";

        this.ObjToDom(presetEditorTree, JSON.parse(presetJson));

        UpdatePrices();
    }

    this.CreateProductsList = function () {
        this.CreateTitle("Products");

        var productsView = presetEditor.appendChild(document.createElement("div"));
        productsView.className = "ProductsView";
        productsView.style.overflow = "auto";

        var keys = Object.keys(productsList);
        for (let i = 0; i < keys.length; i++) {
            this.CreateProductItem(productsView, keys[i], 1);
        }

        this.CreateGroupItem(productsView, "New Group");
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