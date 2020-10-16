var ConfiguratorInstance = {};
var WebGuiDrawer = {};
var State = {};
var SdkVersions = {};

var Configurator = {
    WebObject: {},
    Update: function () {
        this.WebObject.textContent = '';
        WebGuiDrawer.Update();

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