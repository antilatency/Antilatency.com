var Release_2_1_1 = function (context) {
    var math = ["Default"];

    context.Label("General");
    context.Tab();
    var target = context.Enum("Target", "Native", "Unity", "Unreal Engine");

    var language = "";

    if (target === "Native") {
        language = context.Enum("Language", "CPlusPlus", "CSharp");
    } else if (target === "Unity") {
        language = "CSharp";
    } else if (target === "Unreal Engine") {
        language = "CPlusPlus";
    }

    context.SetScope("TargetSettings");

    if (target === "Unity") {
        var unityVersion = context.Enum("Unity Version", "2018.x", "2019.x");
        var unityComponents = context.Bool("Unity Components");
    }

    if (target === "Unreal Engine") {
        var ueVersion = context.Enum("Unreal Engine Version", "4.18", "4.19", "4.20", "4.21", "4.22", "4.23", "4.24", "4.25", "4.26");

        // var ueBlueprintWrappers = context.Bool("Include Unreal Engine Blueprint Wrappers");
        // if (ueBlueprintWrappers) {
        //     var ueComponents = context.Bool("Unreal Engine Blueprints Components");
        // }
        // context.Bool("Unreal Engine Code Samples");
    }

    if (target === "Native"){
        if (language === "CPlusPlus"){
            context.Bool("Exceptions");
        }
    }
    context.Untab();
    
    context.Space();
    context.Label("Math");
    context.Tab();
    if (target === "Unity") {
        if (unityComponents){
            math = ["UnityEngine.Math"];
        }else{
            math.unshift("UnityEngine.Math");
        }
    }
    context.Enum("Math Types", math);
    context.Untab();

    if (unityComponents){
        context.Space();
        context.Label("Components")
        context.Tab();
        context.SetScope("Components");

        if (unityComponents){
            var unityAltTracking = context.Bool("Alt Tracking Components");
            var unityBracer = context.Bool("Bracer Components");
            var unityDeviceNetwork = context.Bool("Device Network Components", true, unityAltTracking || unityBracer, true);
            var unityAltEnvironment = context.Bool("Alt Environment Components", true, unityAltTracking, true);
            var unityStorageClient = context.Bool("Storage Client Components", true, unityAltEnvironment, true);
        }

        context.SetScope("");
        context.SetScope("TargetSettings");
        context.Untab();
    }

    context.SetScope("");

    context.Space();

    context.Label("Libraries");
    context.SetScope("Libraries");
    context.Tab();

    if (context.Bool("Device Network", true, unityDeviceNetwork, true)) {
        context.Bool("Alt Tracking", true, unityAltTracking, true);
        context.Bool("Bracer", true, unityBracer, true);
        context.Bool("Hardware Extension Interface");
        context.Bool("Radio Metrics");
    }
    context.Bool("Tracking Alignment");
    context.Bool("Storage Client", true, unityStorageClient, true);
    context.Untab();
    context.SetScope("");

    context.Space();

    context.Label("Platforms")
    context.Tab();
    context.Label("Windows")
    context.Tab();
    context.SetScope("Platforms.Windows");
    var win32 = context.Bool("x86");
    var win64 = context.Bool("x64");
    context.Untab();

    if (target !== "Unreal Engine") {
        context.Label("UWP")
        context.Tab();

        context.SetScope("");
        context.SetScope("Platforms.WinRT");
        var uwpX86 = context.Bool("x86");
        var uwpX64 = context.Bool("x64");
        var uwpArmeabiV7a = context.Bool("armeabi-v7a");
        if (!(target === "Unity" && unityVersion === "2018.x")) {
            var uwpArm64V8a = context.Bool("arm64-v8a");
        }

        context.Untab();
    }


    context.SetScope("");

    context.Label("Android");
    context.Tab();
    context.SetScope("Platforms.Android");
    var android = context.Bool("aar");
    context.SetScope("");
    context.Untab();
    context.Untab();

    if (!(win32 || win64 || uwpX86 || uwpX64 || uwpArmeabiV7a || uwpArm64V8a || android)) {
        context.Warning("Warning: No operation systems selected")
    }
}

// Releases["2.1.1"] = Release_2_1_1;