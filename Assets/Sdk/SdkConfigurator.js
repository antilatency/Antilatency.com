
function SdkConfigurator(sdkConfigurator) {

    //var previousState = {};
    var state = {};
    var elementsToDelete = [];
    var KeepAlive = function (name) {

        elementsToDelete = elementsToDelete.filter(n => n !== name);
    }

    var NameToNameAndClasses = function (name) {        
        var nameNoSS = name.trimStart(name);
        var numSpaces = name.length - nameNoSS.length;
        var classes = [...name.matchAll(/`(\S+)/g)].map(x => x[1]);
        classes.unshift("Space" + numSpaces);
        var displayName = nameNoSS.replace(/`/g, "");
        var variableName = displayName.replace(/ /g, "");
        return [displayName,variableName, classes];
    }

    var Enum = function (nameRaw, ...optionsRaw) {
        var options = optionsRaw.flat();
        var [displayName, variableName, classes] = NameToNameAndClasses(nameRaw);

        KeepAlive(variableName);
        var selectedIndex = -1;
        for (var i = 0; i < options.length; i++) {
            if (state[variableName] == options[i]) {
                selectedIndex = i;
                break;
            }
        }
        if (selectedIndex == -1) {
            selectedIndex = 0;
            state[variableName] = options[selectedIndex];
        }
        



        /*var legend = sdkConfigurator.appendChild(document.createElement("legend"));
        legend.innerText = name;*/
        var select = sdkConfigurator.appendChild(document.createElement("select"));
        

        sdkConfigurator.appendChild(WrapToLabel(displayName, select)).classList = classes.join(" ");
        select.onchange = function () {
            console.log(this.options[this.selectedIndex].value);
            state[variableName] = options[this.selectedIndex];
            UpdateOuter();
        }

        for (let i = 0; i < options.length; i++) {
            select.appendChild(new Option(options[i], i, false, selectedIndex==i));            
        }

        return state[variableName];
    }

    var WrapToLabel = function (name, element){
        var label = document.createElement("label");        
        label.innerText = name;
        element && label.appendChild(element);
        return label;
    }

    var Bool = function (nameRaw, defaultValue = true) {
        var [displayName, variableName, classes] = NameToNameAndClasses(nameRaw);
        KeepAlive(variableName)
        
        if (state[variableName] == undefined) {
            state[variableName] = defaultValue;
        }
        
        
        
        var input = document.createElement("input");

        sdkConfigurator.appendChild(WrapToLabel(displayName, input)).classList = classes.join(" ");

        input.type = "checkbox";
        input.checked = state[variableName];
        
        input.onchange = function () {
            state[variableName] = input.checked;
            UpdateOuter();
        }

        return state[variableName];
    }

    var Label = function (nameRaw){
        var [displayName, variableName, classes] = NameToNameAndClasses(nameRaw);
        sdkConfigurator.appendChild(WrapToLabel(displayName, null)).classList = classes.join(" ");
    }

    var Warning = function (message) {
        var panel = sdkConfigurator.appendChild(document.createElement("div"));
        panel.classList = "panel warning";
        panel.appendChild(document.createElement("div")).innerText = message;

    }

    var UpdateOuter = function () {
        

        elementsToDelete = Object.keys(state);

        //previousState = state;
        //state = {};

        updateNeeded = true;
        //while (updateNeeded) {
         //   updateNeeded = false;
            sdkConfigurator.textContent = '';
            Update();
        //}
        for (let i = 0; i < elementsToDelete.length; i++) {
            delete state[elementsToDelete[i]]
        }

        console.log(elementsToDelete);
        location.hash = JSON.stringify(state);
    }

    //library F0431
    //unity F06AF
    //unreal F09B1

    var Update = function () {
        var math = ["default"];

        var platform = Enum("Platform", "Native", "Unity3D", "Unreal Engine 4");

        if (platform == "Native") {
            var language = Enum("Language", "C++", "C#");

            if (language == "C#") {
                math.unshift("Accord.Net");
            }
            if (language == "C++") {
                math.unshift("Eigen");
            }
        }

        if (Bool("Device Network `Library")) {
            if (platform == "Unity3D") Bool(" Device Network `Unity Component");
            Bool("Tracking `Library");
        }

        Bool("Offline Tracking `Library");

        if (platform == "Unity3D") {
            math.unshift("Accord.Net");
            math.unshift("UnityEngine.Math");
        }
        Enum("Math Types", math);

        Label("Operating Systems")
        if (!(Bool(" Win32") | Bool(" Win64") | Bool(" Android"))) {
            Warning("No operation systems selected")
        }

    

    }

    

    try {
        var clearHash = decodeURIComponent(location.hash.replace(/^[#]/, ""));
        state = JSON.parse(clearHash);
    } catch(e){
        state = {}
    }
    

    UpdateOuter();
}