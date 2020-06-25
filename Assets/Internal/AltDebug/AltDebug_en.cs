using Csml;
using static Internal.Alt_Debug_Assets;

partial class Internal : Scope {

    public static Material Alt_Debug_en =>

        new Material(
            "AltDebug",
            TitleImage,
        $"*AltDebug* is a debugging application that helps diagnose tracking problems. In this tutorial, we will look at an example of getting an image that trackers see. It can be used to diagnose incorrect positioning of bars or broken markers.")

        [new Downloadable("AltDebug", "AltDebug",
            Downloadable.PathFragment.Version, Downloadable.PathFragment.Directory, Downloadable.PathFragment.Directory)]

        [new Section("Device tree")
            [$"After opening *AltDebug*, you will see the initial application window."]
            [$"In the upper right corner you can see the device tree button:"]
            [$"You can use this button to access the device tree and select the appropriate tracker to work with."]
            [Startup]
            [new Note()[$"When there are no connected devices, the button will display as follows"]]
            [Icon_NoTrackers]
            [$"After clicking the device tree button, you will see a numbered tree of connected devices. The numbers represent the node ID. Trackers are marked with additional icons that represent operations that can be used with the tracker."]
            [DeviceTree]
            [$"There is a bunch of ways to debug with a tracker. You can see them after clicking on tracker node. For this tutorial, we will use the Image option."]
            [DeviceTree_SelectImage]
            ]

        [new Section("Image")
            [$"Select the **Image** option and you will see the image debug tab on the left side of the window."]
            [Image_DeviceTree]
            [$"You can click on the device tree button to collapse it."]
            [Image_Tab]
            [$"The image debug tab allows us to see the image that trackers see. This also allows us to see which points in the image are considered tracked."]
            [$"The initial tracker setting for exp(rows) is 10. So in this tutorial, we will also use this value."]
            [Image_Rows]
            [$"After setting the exp(rows) parameter) we can go to image capture and see markers visible to the tracker."]
            [Image_AutoImage]
            [$"At this stage, you can explore your tracking area and compare it with the layout to see if there are any errors in bar positioning or markers that don't work."]
            [$"The image debug tab also allows you to capture points that are considered tracked."]
            [Image_AutoPoints]
            [$"You can also use both options at the same time. However, due to the fact that the tracker can only perform one operation at once, the points and information about the image will be presented in queues."]
            [Image_AutoImagePoints]
            [$"With all this information, you can debug your tracking area and make sure that it is assembled correctly and does not affect the stability of tracking."]];
}