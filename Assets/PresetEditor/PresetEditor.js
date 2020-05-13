function PresetEditor(presetEditor) {
    var _this = this;

    //window.addEventListener("hashchange", funcRef, false);
    console.log(location.hash)

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
    var Delete = function(element){
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
        dragArea.onmousedown = function (event) { Drag(item, event)}


        //ui.onclick = function (event) { if (event.target == ui) ToggleSelected(ui, event) };
        return ui;
    }

    this.ValidateGroupName = function (name) {
        return name;
    }

    this.CreateGroupUi = function (item,name) {
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

    this.CreateProductUi = function (item,name) {
        var ui = this.CreateUi(item);
        var text = ui.appendChild(document.createElement("div"));
        text.textContent = name;
        text.className = "Title";
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

    this.CreateProductItem = function (parent,name,quantity) {
        var item = this.CreateItem(parent, name, quantity);
        item.className = "Product";
        item.appendChild(this.CreateProductUi(item,name));
        return item;
    }
    

    this.CreateGroupItem = function (parent, rawName) {

        var nameParsed = rawName.match(/^([^~]*)(~(\d+))?$/);
        if (nameParsed == null) throw new Error("Invalid group name:" + rawName);
        var name = nameParsed[1];
        var quantity = (nameParsed[3]!=undefined)?parseInt(nameParsed[3],10):1;

        var item = this.CreateItem(parent, name, quantity);
        item.className = "Group";
        item.appendChild(this.CreateGroupUi(item,name));

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
    presetEditorTree.ondragstart = function () { return false;}
    presetEditorTree.ondrop = function() { return false; }

    presetEditor.appendChild(presetEditorTree);
    
    this.obj = this.HashToObj(sourceJson);
    
    this.ObjToDom(presetEditorTree,this.obj);

    this.Head = new RegExp('((".+")|(\w+))\s*(\:\s*\d+)?\s*');




    this.OnWindowResize = function () {
        
    }

    this.OnDOMContentLoaded = function (event) {
        this.OnWindowResize();
    }

}