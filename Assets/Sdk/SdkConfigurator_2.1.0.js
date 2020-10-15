var SdkConfigurator_2_1_0 = function (context) {
    var math = ["default"];

    var platform = context.Enum("Platform", "Native", "Unity", "Unreal Engine");

    var language = "";

    if (platform == "Native") {
        language = context.Enum("Language", "C++", "C#");
    } else if (platform == "Unity") {
        language = "C#";
    } else if (platform == "Unreal Engine") {
        language = "C++";
    }

    if (platform == "Unity") {
        var unityVersion = context.Enum("Unity Version", "2018.x", "2019.x");
    }
    if (platform == "Unreal Engine") {
        var ueVersion = context.Enum("Unreal Engine Version", "4.18", "4.19", "4.20", "4.21", "4.22", "4.23", "4.24", "4.25");
        var ueBlueprintWrappers = context.Bool("Include Unreal Engine Blueprint Wrappers");
    }

    context.Space();

    context.Label("Libraries")
    context.Tab();
    if (context.Bool("Device Network Library")) {
        context.Bool("Alt Tracking Library");
        context.Bool("Bracer Library");
        context.Bool("Hardware Extension Interface Library");
        context.Bool("Radio Metrics Library");
    }
    if (context.Bool("Alt Environment Selector Library")) {
        context.Bool("Alt Environment Horizontal Grid Library");
        context.Bool("Alt Environment Pillars Library");
    }
    context.Bool("Tracking Alignment Library");
    context.Bool("Storage Client Library");
    context.Untab();


    if (platform != "Native") {
        context.Space();
        context.Label("Samples")
        context.Tab();

        if (platform == "Unity") {
            context.Bool("Sample Unity Components");
        } else if (platform == "Unreal Engine") {
            if (ueBlueprintWrappers) {
                context.Bool("Unreal Engine Blueprints Samples");
            }
            context.Bool("Unreal Engine Code Samples");
        }
        context.Untab();
    }
    context.Space();

    context.Label("Math");
    context.Tab();
    if (language == "C#") {
        math.unshift("Accord.Net");
    } else if (language == "C++" && platform != "Unreal Engine") {
        math.unshift("Eigen");
    }
    if (platform == "Unity") {
        math.unshift("UnityEngine.Math");
    }
    context.Enum("Math Types", math);
    context.Untab();

    context.Space();

    context.Label("Operating Systems")
    context.Tab();
    var win32 = context.Bool(" Win32");
    var win64 = context.Bool(" Win64");
    if (platform != "Unreal Engine") {
        var uwpX86 = context.Bool(" UWP x86");
        var uwpX64 = context.Bool(" UWP x64");
        var uwpArmeabiV7a = context.Bool(" UWP armeabi-v7a");
        if (!(platform == "Unity" && unityVersion == "2018.x")) {
            var uwpArm64V8a = context.Bool(" UWP arm64-v8a");
        }
    }
    var android = context.Bool(" Android");
    if (!(win32 | win64 | uwpX86 | uwpX64 | uwpArmeabiV7a | uwpArm64V8a | android)) {
        context.Warning("No operation systems selected")
    }
    context.Untab();

    context.Space();
}

SdkVersions["2.1.0"] = SdkConfigurator_2_1_0;