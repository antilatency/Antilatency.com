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
                    "HeadPicoG2":{
                        "ACHA0Alt__A":1
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


    this.HashToObj = function (hash) {
        return JSON.parse(hash);
    }

    this.IsEmptyObject = function (obj) {
        if (obj && obj !== 'null' && obj !== 'undefined') {
            return false;
        }

        return true;
    }

    this.UpdatePrices = function () {
        var productsQuantity = {}
        var rootGroup = document.querySelector(".PresetEditorTree > .Group");

        var UpdatePriceTitles = function (item, price, priceTotal) {
            var priceTitle = item.querySelector("div#price");
            var priceTotalTitle = item.querySelector("div#priceTotal");

            priceTitle.textContent = price + "$ x";
            priceTotalTitle.textContent = "= " + priceTotal + "$";
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

        var SetPrices = function (group) {
            var groups = group.querySelectorAll("item:scope > .Group");
            var products = group.querySelectorAll("item:scope > .Product");

            var groupPrice = 0;

            for (let i = 0; i < groups.length; i++) {
                groupPrice += SetPrices(groups[i]);
            }

            for (let i = 0; i < products.length; i++) {
                var product = products[i];
                var productName = product.getAttribute("name");
                var productQuantity = product.getAttribute("quantity");
                var productQuantityGlobal = productsQuantity[productName];
                var productInfo = productsList[productName];
                var productPrice = 0;

                for (let j = 0; j < productInfo.Prices.length; j++) {
                    if (productInfo.Prices[j].From <= productQuantityGlobal) {
                        productPrice = productInfo.Prices[j].Price;
                    }
                }

                product.setAttribute("price", productPrice);

                var producPriceTotal = productPrice * productQuantity;

                groupPrice += producPriceTotal;

                UpdatePriceTitles(product, productPrice, producPriceTotal);
            }

            group.setAttribute("price", groupPrice);

            var groupPriceTotal = groupPrice * group.getAttribute("quantity");

            UpdatePriceTitles(group, groupPrice, groupPriceTotal);

            return groupPriceTotal;
        }

        CountProducts(rootGroup, 1);
        SetPrices(rootGroup);
    }

    /*var ToggleSelected = function (ui,event) {

        //console.log(event.target)
        ui.classList.toggle("Selected");
    }*/

    var Drag = function (item, event) {
        presetEditor.classList.add("ItemInTheAir");

        dragPlaceholder = document.createElement("div");
        dragPlaceholder.className = "DragPlaceholder"
        dragPlaceholder.style.width = item.offsetWidth + "px";
        dragPlaceholder.style.height = item.offsetHeight + "px";

        item.parentElement.insertBefore(dragPlaceholder, item);


        draggedItem = item;
        item.classList.add("Dragged");

        Move(draggedItem, event)
    }
    var Delete = function (element) {
        element.parentNode.removeChild(element);
    }

    var DropOn = function (target) {
        presetEditor.classList.remove("ItemInTheAir");
        dragPlaceholder && Delete(dragPlaceholder);
        dragPlaceholder = null;

        if (target != null) {
            console.log(draggedItem)
            console.log("DropOn")
            console.log(target)
            Delete(draggedItem)
            let firstItem = target.children[1];
            if (firstItem == undefined) {
                console.log("appendChild")
                target.appendChild(draggedItem)
            } else {
                console.log("insertBefore")
                target.insertBefore(draggedItem, firstItem)
            }


        }

        if (draggedItem) {

            draggedItem.classList.remove("Dragged");
            draggedItem.style.left = 0;
            draggedItem.style.top = 0;
            draggedItem = null;
        }




    }

    var Move = function (item, event) {
        draggedItem.style.left = event.pageX + 'px';
        draggedItem.style.top = event.pageY + 50 + 'px';
    }

    var PointedItem = null;
    document.addEventListener("mousemove", function (event) {

        if (!draggedItem) {
            var x = event.clientX;
            var y = event.clientY;
            var element = document.elementFromPoint(x, y);
            while ((element != null) && (element.tagName.toLowerCase() != "item")) {
                element = element.parentElement;
            }
            if (PointedItem != element) {
                PointedItem && PointedItem.classList.remove("PointedItem");
                PointedItem = element;
                PointedItem && PointedItem.classList.add("PointedItem");

            }
        }



        if (draggedItem) {
            Move(draggedItem, event);

        }
    });

    document.addEventListener("mouseup", function () {
        DropOn(null);
    });
    var dragPlaceholder = null;
    var draggedItem = null;


    this.CreateUi = function (item) {
        var ui = document.createElement("ui");


        var dragArea = ui.appendChild(document.createElement("span"));
        dragArea.className = "DragArea";
        dragArea.onmousedown = function (event) { Drag(item, event) }


        //ui.onclick = function (event) { if (event.target == ui) ToggleSelected(ui, event) };
        return ui;
    }

    this.ValidateGroupName = function (name) {
        return name;
    }

    this.CreateCounterUi = function (parent, value, onChangeCallback) {
        var price = parent.appendChild(document.createElement("div"));
        price.textContent = "000$ x";
        price.style.position = "relative";
        price.style.marginLeft = "25px";
        price.style.display = "inline";
        price.style.fontStyle = "normal";
        price.style.fontSize = "small";
        price.id = "price";

        var counter = parent.appendChild(document.createElement("input"));
        counter.type = "number";
        counter.min = 1;
        counter.style.position = "relative";
        counter.style.marginLeft = "10px";
        counter.style.width = "40px";
        counter.style.display = "inline";
        counter.value = value;

        var priceTotal = parent.appendChild(document.createElement("div"));
        priceTotal.textContent = "= 000$";
        priceTotal.style.position = "relative";
        priceTotal.style.marginLeft = "10px";
        priceTotal.style.display = "inline";
        priceTotal.style.fontStyle = "normal";
        priceTotal.style.fontSize = "small";
        priceTotal.id = "priceTotal";

        counter.onchange = function () {
            var value = counter.value;

            if (!_this.IsEmptyObject(onChangeCallback)) {
                onChangeCallback(value);
            }

            _this.UpdatePrices();
        }

        return counter;
    }

    this.CreateGroupUi = function (item, name) {
        var ui = this.CreateUi(item);

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


        dropArea.onmouseup = function () { DropOn(item) }

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
        var ui = this.CreateUi(item);
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

        //item.onmousemove = function (e) { console.log("onmousemove" + e.target); return false;};
        //item.onmouseout  = function (e) { console.log("Leave"); return false; };
        parent.appendChild(item);
        return item;
    }

    this.CreateProductItem = function (parent, name, quantity) {
        var item = this.CreateItem(parent, name, quantity);
        item.className = "Product";
        item.appendChild(this.CreateProductUi(item, productsList[name].Name));
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

    var presetEditorTree = document.createElement("div");
    presetEditorTree.className = "PresetEditorTree";
    presetEditorTree.ondragstart = function () { return false; }
    presetEditorTree.ondrop = function () { return false; }

    presetEditor.appendChild(presetEditorTree);

    this.obj = this.HashToObj(sourceJson);

    this.ObjToDom(presetEditorTree, this.obj, productsList);

    this.UpdatePrices();


    this.Head = new RegExp('((".+")|(\w+))\s*(\:\s*\d+)?\s*');


    this.OnWindowResize = function () {

    }

    this.OnDOMContentLoaded = function (event) {
        this.OnWindowResize();
    }

}