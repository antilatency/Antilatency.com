var SdkConfiguratorWebGui = {
    UpdateConfig: {},
    elementsToDelete: [],
    numTabs: 0,

    KeepAlive: function (name) {
        elementsToDelete = elementsToDelete.filter(n => n !== name);
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

        this.KeepAlive(variableName);
        var selectedIndex = -1;

        for (var i = 0; i < options.length; i++) {
            if (State[variableName] == options[i]) {
                selectedIndex = i;
                break;
            }
        }

        if (selectedIndex == -1) {
            selectedIndex = 0;
            State[variableName] = options[selectedIndex];
        }

        var select = ConfiguratorInstance.WebObject.appendChild(document.createElement("select"));

        ConfiguratorInstance.WebObject.appendChild(this.WrapToLabel(displayName, select)).classList = this.TabsToClass();
        select.onchange = function () {
            State[variableName] = options[this.selectedIndex];
            ConfiguratorInstance.Update();
        }

        for (let i = 0; i < options.length; i++) {
            select.appendChild(new Option(options[i], i, false, selectedIndex == i));
        }

        return State[variableName];
    },

    WrapToLabel: function (name, element) {
        var label = document.createElement("label");
        label.innerText = name;
        element && label.appendChild(element);
        return label;
    },

    Bool: function (displayName, defaultValue = true) {
        var variableName = this.DisplayNameToVariableName(displayName)
        this.KeepAlive(variableName)

        if (State[variableName] == undefined) {
            State[variableName] = defaultValue;
        }

        var input = document.createElement("input");

        ConfiguratorInstance.WebObject.appendChild(this.WrapToLabel(displayName, input)).classList = this.TabsToClass();

        input.type = "checkbox";
        input.checked = State[variableName];

        input.onchange = function () {
            State[variableName] = input.checked;
            ConfiguratorInstance.Update();
        }

        return State[variableName];
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

    Button: function (displayName) {
        var button = ConfiguratorInstance.WebObject.appendChild(document.createElement("button"));
        button.innerText = displayName;
        button.classList = ".Button";

        button.onclick = function () {
            console.log(LocationHashToString());
        }
    },

    UpdateVersion: function () {
        var versions = Object.keys(SdkVersions);
        this.Enum("SDK", versions);
        this.Space();
    },

    UpdateButton: function () {
        this.Space();
        this.Button("Generate");
    },

    Update: function () {
        elementsToDelete = Object.keys(State);

        numTabs = 0;

        this.UpdateVersion();

        var selectedVersion = State["SDK"];

        if (selectedVersion in SdkVersions) {
            SdkVersions[selectedVersion](this);
        }

        this.UpdateButton();

        for (let i = 0; i < elementsToDelete.length; i++) {
            delete State[elementsToDelete[i]];
        }
    }
};