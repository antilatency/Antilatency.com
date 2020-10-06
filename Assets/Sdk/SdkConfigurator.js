
function SdkConfigurator(sdkConfigurator) {

    //var previousState = {};
    var state = {};
    var elementsToDelete = [];
    var numTabs = 0;
    var KeepAlive = function (name) {

        elementsToDelete = elementsToDelete.filter(n => n !== name);
    }

    var NameToNameAndClasses = function (name) {        
        var nameNoSS = name.trimStart(name);
        var numSpaces = name.length - nameNoSS.length;
        var classes = [...name.matchAll(/`(\S+)/g)].map(x => x[1]);
        classes.unshift("Tab" + numSpaces);
        var displayName = nameNoSS.replace(/`/g, "");
        var variableName = displayName.replace(/ /g, "");
        return [displayName,variableName, classes];
    }

    var TabsToClass = function(){ 
        return "Tab" + numTabs;

    }

    var Tab = function () { 
        return numTabs++;
    }
    var Untab = function () {
        return numTabs--;
    }

    var DisplayNameToVariableName = function (displayName) {
        var words = displayName.split(" ").filter(function (x) { return x.length != 0 });
        words = words.map(function (x) {
            x[0] = "A"

            return x;
        })
        return words.join('');
    }


    var Enum = function (displayName, ...optionsRaw) {
        var options = optionsRaw.flat();
        var variableName = DisplayNameToVariableName(displayName)
        
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
        
        
        sdkConfigurator.appendChild(WrapToLabel(displayName, select)).classList = TabsToClass();
        select.onchange = function () {
            //console.log(this.options[this.selectedIndex].value);
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

    var Bool = function (displayName, defaultValue = true) {
        var variableName = DisplayNameToVariableName(displayName)
        KeepAlive(variableName)
        
        if (state[variableName] == undefined) {
            state[variableName] = defaultValue;
        }
        
        
        
        var input = document.createElement("input");

        sdkConfigurator.appendChild(WrapToLabel(displayName, input)).classList = TabsToClass();

        input.type = "checkbox";
        input.checked = state[variableName];
        
        input.onchange = function () {
            state[variableName] = input.checked;
            UpdateOuter();
        }

        return state[variableName];
    }

    var Label = function (displayName){
        sdkConfigurator.appendChild(WrapToLabel(displayName, null)).classList = TabsToClass();;
    }

    var Warning = function (message) {
        var panel = sdkConfigurator.appendChild(document.createElement("div"));
        panel.classList = "panel warning";
        panel.appendChild(document.createElement("div")).innerText = message;

    }

    var Space = function () {
        var space = sdkConfigurator.appendChild(document.createElement("div"));
        space.classList = "Space";

    }

    var UpdateOuter = function () {
        elementsToDelete = Object.keys(state);

        //previousState = state;
        //state = {};

        updateNeeded = true;
        //while (updateNeeded) {
         //   updateNeeded = false;
        sdkConfigurator.textContent = '';
        numTabs = 0;
            Update();
        //}
        for (let i = 0; i < elementsToDelete.length; i++) {
            delete state[elementsToDelete[i]]
        }

        //console.log(elementsToDelete);
        var json = JSON.stringify(state);
        location.hash = json;

        console.log(Sha1(json));

    }

    //library F0431
    //unity F06AF
    //unreal F09B1

    var Update = function () {
        var math = ["default"];
        
        var platform = Enum("Platform", "Native", "Unity", "Unreal Engine");
        
        var language = "";

        if (platform == "Native") {
            language = Enum("Language", "C++", "C#");
        } else if (platform == "Unity") {
            language = "C#";
        } else if (platform == "Unreal Engine") {
            language = "C++";
        }

        if (platform == "Unity") {
            var unityVersion = Enum("Unity Version", "2018.x", "2019.x");
        }
        if (platform == "Unreal Engine") {
            var ueVersion = Enum("Unreal Engine Version", "4.18", "4.19", "4.20", "4.21", "4.22", "4.23", "4.24", "4.25");
            var ueBlueprintWrappers = Bool("Include Unreal Engine Blueprint Wrappers");
        }

        Space();

        Label("Libraries")
        Tab();
        if (Bool("Device Network Library")) {
            Bool("Alt Tracking Library");
            Bool("Bracer Library");
            Bool("Hardware Extension Interface Library");
            Bool("Radio Metrics Library");
        }
        if (Bool("Alt Environment Selector Library")) {
            Bool("Alt Environment Horizontal Grid Library");
            Bool("Alt Environment Pillars Library");
        }
        Bool("Tracking Alignment Library");
        Bool("Storage Client Library");
        Untab();
        

        if (platform != "Native") {
            Space();
            Label("Samples")
            Tab();
        
            if (platform == "Unity") {
                Bool("Sample Unity Components");
            } else if (platform == "Unreal Engine") {
                if (ueBlueprintWrappers) {
                    Bool("Unreal Engine Blueprints Samples");
                }
                Bool("Unreal Engine Code Samples");
            }
            Untab();
        }
        Space();

        Label("Math");
        Tab();
        if (language == "C#") {
            math.unshift("Accord.Net");
        } else if (language == "C++" && platform != "Unreal Engine") {
            math.unshift("Eigen");
        }
        if (platform == "Unity") {
            math.unshift("UnityEngine.Math");
        }
        Enum("Math Types", math);
        Untab();

        Space();

        Label("Operating Systems")
        Tab();
        var win32 = Bool(" Win32");
        var win64 = Bool(" Win64");
        if (platform != "Unreal Engine") {
            var uwpX86 = Bool(" UWP x86");
            var uwpX64 = Bool(" UWP x64");
            var uwpArmeabiV7a = Bool(" UWP armeabi-v7a");
            if (!(platform == "Unity" && unityVersion == "2018.x")) {
                var uwpArm64V8a = Bool(" UWP arm64-v8a");
            }
        }
        var android = Bool(" Android");
        if (!(win32 | win64 | uwpX86 | uwpX64 | uwpArmeabiV7a | uwpArm64V8a | android)) {
            Warning("No operation systems selected")
        }
        Untab();

        Space();
    }

    try {
        var clearHash = decodeURIComponent(location.hash.replace(/^[#]/, ""));
        state = JSON.parse(clearHash);
    } catch(e){
        state = {}
    }
    

    UpdateOuter();
}