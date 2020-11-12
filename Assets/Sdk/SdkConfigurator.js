var ConfiguratorInstance = {};

var Configurator = {
    Releases: {},
    State: {},
    CurrentObject: {},
    Context: {}, 
    Update: function () {
        this.Context.Update();
    }
}

function LocationHashToString() {
    return decodeURIComponent(location.hash.replace(/^[#]/, ""));
}

function SdkConfigurator(sdkConfigurator) {
    ConfiguratorInstance = Object.create(Configurator);
    ConfiguratorInstance.Releases = GetReleasesList();

    try {
        var rawState = LocationHashToString();
        ConfiguratorInstance.State = JSON.parse(rawState);
    } catch (e) {
        ConfiguratorInstance.State = {};
    }

    webContext = Object.create(ReleaseWebContext);
    webContext.WebObject = sdkConfigurator;
    ConfiguratorInstance.Context = webContext;

    ConfiguratorInstance.Update();
}

function GetReleasesList() {
    var result = {};
    releaseMethodPrefix = "Release_";
    releases = Object.getOwnPropertyNames(this).filter(item => typeof this[item] === 'function' && item.startsWith(releaseMethodPrefix));

    releases.forEach(r => {
        releaseName = r.substring(releaseMethodPrefix.length);
        result[releaseName] = this[r];
    });

    return result;
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
            if (parent === null || parent === "") {
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
            if (!element.hasOwnProperty(pathParts[i])) {
                return;
            }
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