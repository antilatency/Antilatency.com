var ReleaseWebContext = {
    elementsToDelete: [],
    numTabs: 0,
    stateElementPath: "",
    WebObject: {},

    KeepAlive: function (name) {
        elementPath = "";

        if (this.stateElementPath == "") {
            elementPath = name;
        } else {
            elementPath = this.stateElementPath + "." + name;
        }

        this.elementsToDelete = this.elementsToDelete.filter(function (n) {
            return n !== elementPath;
        });
    },

    SetContext: function (name) {
        if (name == null || name == "") {
            ConfiguratorInstance.CurrentObject = ConfiguratorInstance.State;
            this.stateElementPath = "";
        } else {
            if (this.stateElementPath === "") {
                this.stateElementPath = name;
            } else {
                this.stateElementPath = this.stateElementPath + "." + name;
            }

            splitted = name.split('.');
            for (i = 0; i < splitted.length; i++) {
                if (!(ConfiguratorInstance.CurrentObject.hasOwnProperty(splitted[i]))) {
                    ConfiguratorInstance.CurrentObject[splitted[i]] = {};
                }

                ConfiguratorInstance.CurrentObject = ConfiguratorInstance.CurrentObject[splitted[i]];
            }
        }
    },

    TabsToClass: function () {
        return "Tab" + numTabs;
    },

    Tab: function () {
        return numTabs++;
    },

    Untab: function () {
        return numTabs--;
    },

    DisplayNameToVariableName: function (displayName) {
        var words = displayName.split(" ").filter(function (x) { return x.length != 0 });
        words = words.map(function (x) {
            x[0] = "A"

            return x;
        });
        return words.join('');
    },

    Enum: function (displayName) {
        var options = [];
        if (arguments.length > 2) {
            for (var i = 1; i < arguments.length; i++){
                options.push(arguments[i]);
            }
        } else if (arguments.length === 2){
            if (Array.isArray(arguments[1])) {
                options = arguments[1];
            } else if (typeof arguments[1] === 'string') {
                options.push(arguments[1]);
            } else {
                return;
            }
        } else {
            return;
        }

        var variableName = this.DisplayNameToVariableName(displayName)
        var propPath = this.stateElementPath;

        this.KeepAlive(variableName);
        var selectedIndex = -1;


        for (var i = 0; i < options.length; i++) {
            if (ConfiguratorInstance.CurrentObject[variableName] == options[i]) {
                selectedIndex = i;
                break;
            }
        }

        if (selectedIndex == -1) {
            selectedIndex = 0;
            ConfiguratorInstance.CurrentObject[variableName] = options[selectedIndex];
        }

        var select = ConfiguratorInstance.Context.WebObject.appendChild(document.createElement("select"));

        ConfiguratorInstance.Context.WebObject.appendChild(this.WrapToLabel(displayName, select)).classList = this.TabsToClass();
        select.onchange = function () {
            prop = GetObjectProperty(ConfiguratorInstance.State, propPath);
            prop[variableName] = options[this.selectedIndex]

            //CurrentObject[variableName] = options[this.selectedIndex];
            ConfiguratorInstance.Update();
        }

        for (let i = 0; i < options.length; i++) {
            select.appendChild(new Option(options[i], i, false, selectedIndex == i));
        }

        return ConfiguratorInstance.CurrentObject[variableName];
    },

    WrapToLabel: function (name, element) {
        var label = document.createElement("label");
        label.innerText = name;
        element && label.appendChild(element);
        return label;
    },

    Bool: function (displayName, defaultValue = true) {
        var variableName = this.DisplayNameToVariableName(displayName);
        var propPath = this.stateElementPath;
        this.KeepAlive(variableName)

        if (ConfiguratorInstance.CurrentObject[variableName] == undefined) {
            ConfiguratorInstance.CurrentObject[variableName] = defaultValue;
        }

        var input = document.createElement("input");

        ConfiguratorInstance.Context.WebObject.appendChild(this.WrapToLabel(displayName, input)).classList = this.TabsToClass();

        input.type = "checkbox";
        input.checked = ConfiguratorInstance.CurrentObject[variableName];

        input.onchange = function () {
            prop = GetObjectProperty(ConfiguratorInstance.State, propPath);
            prop[variableName] = input.checked;
            //CurrentObject[variableName] = input.checked;
            ConfiguratorInstance.Update();
        }

        return ConfiguratorInstance.CurrentObject[variableName];
    },

    Label: function (displayName) {
        ConfiguratorInstance.Context.WebObject.appendChild(this.WrapToLabel(displayName, null)).classList = this.TabsToClass();;
    },

    Warning: function (message) {
        var panel = ConfiguratorInstance.Context.WebObject.appendChild(document.createElement("div"));
        panel.classList = "panel warning";
        panel.appendChild(document.createElement("div")).innerText = message;
    },

    Space: function () {
        var space = ConfiguratorInstance.Context.WebObject.appendChild(document.createElement("div"));
        space.classList = "Space";
    },

    Button: function (displayName, onclick) {
        var button = ConfiguratorInstance.Context.WebObject.appendChild(document.createElement("button"));
        button.innerText = displayName;
        button.classList = ".Button";

        if (onclick != null && typeof onclick == "function") {
            button.onclick = onclick;
        }
    },

    WebServer_GetSdk: function () {
        let xhr = new XMLHttpRequest();
        xhr.open("POST", "http://sdkbuild.tunnel.antilatency.com/api/v1/sdk");

        xhr.onload = function () {
            if (xhr.status != 200) {
                //FAIL
                console.log("WTF!");
            } else {
                console.log(xhr.response);
            }
        };

        xhr.onerror = function () {
            console.log("WTF!!!");
        };

        xhr.setRequestHeader('Content-Type', 'application/json');
        xhr.send(JSON.stringify(ConfiguratorInstance.State));
    },

    GenerateButton: function () {
        this.Space();
        this.Button("Generate", this.WebServer_GetSdk);
    },

    ReleaseSelector: function (versions) {
        this.Enum("Release", versions);
        this.Space();
    },

    Update: function () {
        this.WebObject.textContent = '';

        ConfiguratorInstance.CurrentObject = ConfiguratorInstance.State;

        numTabs = 0;
        stateElementPath = "";
        this.elementsToDelete = [];

        CollectObjectsKeys(ConfiguratorInstance.CurrentObject, this.elementsToDelete, null);

        var versions = Object.keys(ConfiguratorInstance.Releases);
        this.ReleaseSelector(versions);

        var selectedVersion = ConfiguratorInstance.State["Release"];

        if (selectedVersion in ConfiguratorInstance.Releases) {
            ConfiguratorInstance.Releases[selectedVersion](this);
        }

        this.GenerateButton();

        // console.log(this.elementsToDelete);

        for (let i = 0; i < this.elementsToDelete.length; i++) {
            DeleteObjectProperty(ConfiguratorInstance.State, this.elementsToDelete[i]);
        }

        DeleteEmptyObjects(ConfiguratorInstance.State);

        var json = JSON.stringify(ConfiguratorInstance.State);
        location.hash = json;

        // console.log(ConfiguratorInstance.State);

        console.log(json.replace(/"/gi, "\\\""));

        //console.log(Sha1(json));
    }
};