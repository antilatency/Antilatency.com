var ConfiguratorInstance = {};
var WebGuiDrawer = {};
var State = {};
var CurrentObject = State;
var SdkVersions = {};



var Configurator = {
    WebObject: {},
    Update: function () {
        this.WebObject.textContent = '';
        WebGuiDrawer.Update();

        console.log(State);

        var json = JSON.stringify(State);
        location.hash = json;

        //console.log(Sha1(json));
    }
}

function LocationHashToString() {
    return decodeURIComponent(location.hash.replace(/^[#]/, ""));
}

function SdkConfigurator(sdkConfigurator) {
    try {
        var rawState = LocationHashToString();
        State = JSON.parse(rawState);
    } catch (e) {
        State = {};
    }

    ConfiguratorInstance = Object.create(Configurator);
    ConfiguratorInstance.WebObject = sdkConfigurator;

    WebGuiDrawer = Object.create(SdkConfiguratorWebGui);

    ConfiguratorInstance.Update();
}

function CollectObjectsKeys(obj, result, parent) {
    Object.keys(obj).forEach(v => {
        if (typeof obj[v] === 'object' && obj[v] !== null) {
            var parentPath = v;
            if (parent !== null) {
                parentPath = parent + "." + parentPath;
            }
            CollectObjectsKeys(obj[v], result, parentPath);
        } else {
            if (parent === null) {
                result.push(v);
            } else {
                result.push(parent + "." + v);
            }
        }
    });
}

function GetObjectProperty(obj, propertyPath) {
    if (propertyPath === "") {
        return obj;
    }

    pathParts = propertyPath.split(".");

    element = obj;

    for (var i = 0; i < pathParts.length; i++) {
        if (i == (pathParts.length - 1)) {
            return element[pathParts[i]];
        } else {
            element = element[pathParts[i]];
        }
    }

    return element;
}

function DeleteObjectProperty(obj, elementPath) {
    element = obj;

    pathParts = elementPath.split(".");

    for (var i = 0; i < pathParts.length; i++) {
        if (i == (pathParts.length - 1)) {
            delete element[pathParts[i]];
        } else {
            element = element[pathParts[i]];
        }
    }
}

function DeleteEmptyObjects(obj) {
    Object.keys(obj).forEach(v => {
        if (typeof obj[v] === 'object') {
            if (Object.keys(obj[v]).length != 0) {
                DeleteEmptyObjects(obj[v]);
            }

            if (Object.keys(obj[v]).length == 0) {
                delete obj[v];
            }
        }
    });

    if (Object.keys(obj).length == 0) {
        delete obj;
    }
}