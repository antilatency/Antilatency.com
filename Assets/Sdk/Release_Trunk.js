var Release_Trunk = function (context) {
    var math = ["default"];

    var target = context.Enum("Target", "Native", "Unity", "Unreal Engine");

    var language = "";

    if (target == "Native") {
        language = context.Enum("Language", "C++", "C#");
    } else if (target == "Unity") {
        language = "C#";
    } else if (target == "Unreal Engine") {
        language = "C++";
    }

    context.SetContext("TargetSettings");

    if (target == "Unity") {
        var unityVersion = context.Enum("Unity Version", "2018.x", "2019.x");
    }
    if (target == "Unreal Engine") {
        var ueVersion = context.Enum("Unreal Engine Version", "4.18", "4.19", "4.20", "4.21", "4.22", "4.23", "4.24", "4.25");
        var ueBlueprintWrappers = context.Bool("Include Unreal Engine Blueprint Wrappers");
    }

    //context.Space();

    if (target != "Native") {
        context.Space();
        context.Label("Samples")
        context.Tab();

        if (target == "Unity") {
            context.Bool("Sample Unity Components");
        } else if (target == "Unreal Engine") {
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
    } else if (language == "C++" && target != "Unreal Engine") {
        math.unshift("Eigen");
    }
    if (target == "Unity") {
        math.unshift("UnityEngine.Math");
    }
    context.Enum("Math Types", math);
    context.Untab();

    context.SetContext("");

    context.Space();



    context.Label("Libraries");
    context.SetContext("Libraries");
    context.Tab();

    if (context.Bool("Device Network")) {
        context.Bool("Alt Tracking");
        context.Bool("Bracer");
        context.Bool("Hardware Extension Interface");
        context.Bool("Radio Metrics");
    }
    if (context.Bool("Alt Environment Selector")) {
        context.Bool("Alt Environment Horizontal Grid");
        context.Bool("Alt Environment Pillars");
    }
    context.Bool("Tracking Alignment");
    context.Bool("Storage Client");
    context.Untab();
    context.SetContext("");


    context.Label("Platforms")
    context.Tab();
    context.Label("Windows")
    context.Tab();
    context.SetContext("Platforms.Windows");
    var win32 = context.Bool("x32");
    var win64 = context.Bool("x64");
    context.Untab();
    
    context.Label("UWP")
    context.Tab();
    if (target != "Unreal Engine") {
        context.SetContext("");
        context.SetContext("Platforms.WinRT");
        var uwpX86 = context.Bool("x86");
        var uwpX64 = context.Bool("x64");
        var uwpArmeabiV7a = context.Bool("armeabi-v7a");
        if (!(target == "Unity" && unityVersion == "2018.x")) {
            var uwpArm64V8a = context.Bool("arm64-v8a");
        }
        
    }
    context.Untab();

    context.SetContext("");
    
    context.Label("Android");
    context.Tab();
    context.SetContext("Platforms.Android");
    var android = context.Bool("AAR");
    context.SetContext("");
    context.Untab();
    context.Untab();

    if (!(win32 | win64 | uwpX86 | uwpX64 | uwpArmeabiV7a | uwpArm64V8a | android)) {
        context.Warning("No operation systems selected")
    }

    context.Space();
}