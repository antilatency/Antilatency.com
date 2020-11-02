var SdkConfiguratorWebGui = {
    UpdateConfig: {},
    elementsToDelete: [],
    numTabs: 0,
    stateElementPath: "",

    KeepAlive: function (name) {
        elementPath = "";

        if (this.stateElementPath == "") {
            elementPath = name;
        } else {
            elementPath = this.stateElementPath + "." + name;
        }

        this.elementsToDelete = this.elementsToDelete.filter(n => n !== elementPath);
    },

    SetContext: function (name) {
        //console.log("Context:" + name);
        if (name == null || name == "") {
            CurrentObject = State;
            this.stateElementPath = "";
        } else {
            if (this.stateElementPath === "") {
                this.stateElementPath = name;
            } else {
                this.stateElementPath = this.stateElementPath + "." + name;
            }
            //console.log(Object.keys(CurrentObject));
            if (!(CurrentObject.hasOwnProperty(name))) {
                // console.log("add");
                CurrentObject[name] = {};
            }
            CurrentObject = CurrentObject[name];
        }
        // console.log("State");
        // console.log(State);
        // console.log("CurrentObject");
        // console.log(CurrentObject);
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
        })
        return words.join('');
    },

    Enum: function (displayName, ...optionsRaw) {
        var options = optionsRaw.flat();
        var variableName = this.DisplayNameToVariableName(displayName)
        var propPath = this.stateElementPath;

        this.KeepAlive(variableName);
        var selectedIndex = -1;

        // console.log(CurrentObject);
        // console.log(State);

        for (var i = 0; i < options.length; i++) {
            if (CurrentObject[variableName] == options[i]) {
                selectedIndex = i;
                break;
            }
        }

        if (selectedIndex == -1) {
            selectedIndex = 0;
            CurrentObject[variableName] = options[selectedIndex];
        }

        var select = ConfiguratorInstance.WebObject.appendChild(document.createElement("select"));

        ConfiguratorInstance.WebObject.appendChild(this.WrapToLabel(displayName, select)).classList = this.TabsToClass();
        select.onchange = function () {
            prop = GetObjectProperty(State, propPath);
            prop[variableName] = options[this.selectedIndex]

            //CurrentObject[variableName] = options[this.selectedIndex];
            ConfiguratorInstance.Update();
        }

        for (let i = 0; i < options.length; i++) {
            select.appendChild(new Option(options[i], i, false, selectedIndex == i));
        }

        return CurrentObject[variableName];
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

        if (CurrentObject[variableName] == undefined) {
            CurrentObject[variableName] = defaultValue;
        }

        var input = document.createElement("input");

        ConfiguratorInstance.WebObject.appendChild(this.WrapToLabel(displayName, input)).classList = this.TabsToClass();

        input.type = "checkbox";
        input.checked = CurrentObject[variableName];

        input.onchange = function () {
            prop = GetObjectProperty(State, propPath);
            prop[variableName] = input.checked;
            //CurrentObject[variableName] = input.checked;
            ConfiguratorInstance.Update();
        }

        return CurrentObject[variableName];
    },

    Label: function (displayName) {
        ConfiguratorInstance.WebObject.appendChild(this.WrapToLabel(displayName, null)).classList = this.TabsToClass();;
    },

    Warning: function (message) {
        var panel = ConfiguratorInstance.WebObject.appendChild(document.createElement("div"));
        panel.classList = "panel warning";
        panel.appendChild(document.createElement("div")).innerText = message;
    },

    Space: function () {
        var space = ConfiguratorInstance.WebObject.appendChild(document.createElement("div"));
        space.classList = "Space";
    },

    Button: function (displayName, onclick) {
        var button = ConfiguratorInstance.WebObject.appendChild(document.createElement("button"));
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
        xhr.send(JSON.stringify(State));
    },

    GenerateButton: function () {
        this.Space();
        this.Button("Generate", this.WebServer_GetSdk);
    },

    Update: function () {
        CurrentObject = State;

        CollectObjectsKeys(CurrentObject, this.elementsToDelete, null);

        numTabs = 0;

        var versions = Object.keys(SdkVersions);
        SdkVersionSelector(this, versions);

        var selectedVersion = State["SDK"];

        if (selectedVersion in SdkVersions) {
            SdkVersions[selectedVersion](this);
        }

        this.GenerateButton();

        for (let i = 0; i < this.elementsToDelete.length; i++) {
            DeleteObjectProperty(State, this.elementsToDelete[i]);
            //delete State[elementsToDelete[i]];
        }

        DeleteEmptyObjects(State);
    }
};