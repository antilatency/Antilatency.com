using Csml;
public partial class Software : Scope {
    public partial class AntilatencyService : Scope{
        public partial class Environments{

    public static Material Material_en => new Material("Environments",
    EnvironmentsTabScreenshot,
    $"Use this tab of the {AntilatencyService.Material} to manage the parameters of the {Terms.Environment}. You can create or load from link the tracking area, configure it, and check the density of the features, using the Environment's editor.")

     [new Info($"Please, read here how to set up the tracking area: \n{Tutorials.Devkit_Tracking_Area_Setup}")]

     
     [new Section("The Environment by default")

        [($"You can set the Environment by default in two ways. Use the \"*set as default*\" option ...")]
        [SetAsDefault1]
       
        [$"... or set it with *a long press*."]
        [SetAsDefault2]
         
     ]

     [new Section("The Environment's link","tracking_area_link")
        [$"You can share the {Terms.Environment} with other users using the link. It looks like this:"]
        
            [$"`http://www.antilatency.com/antilatencyservice/environment?`*data*`=AAVSaWdpZE8BBnllbGxvdwgIuFOJP9xGoD6vjmO9mpmZPgAAAAAAAAAAAJqZGT8NBQAEAwAGAwYCBAIDAAUHBgQDAwUAAAIHBgcGBwYHBwIHAgcGAgMDdzk&`*name*`=DevKitX&`*setAsDefault*`=true&`*silent*`=true`"]
            [$"\nThe link has some parameters (\"data\" and \"name\" are obligatory)."]
            [$"*data* - the encrypted data of the tracking area; \n*name* - you can edit it later; \n*setAsDefault* - automatically set this area by default right after adding; \n*silent* - use for Android; you can add the tracking area by clicking the link without opening the AntilatencyService."]

            [new Section("How to share the Environment","")]
        [$"Use the \"*share*\" option to copy the link of the tracking area. Then send this link to other users in a convenient way."]
        [Share]
            [new Section("How to add the Environment","")]
        [$"Use the \"*from link*\" option to add the new tracking area. Here you can edit the name of the Environment."]
            [new Note($"Copy the link beforehand to automatically fill in the add form with data from the clipboard.")]
        [FromLink]
        
        [$"\nTo add the Environment using the Android device, choose the \"*from link*\" option or click the link itself to open the AntilatencyService with the prefilled add form. If the link contains the \"*silent*\" parameter, you can add the Environment even without opening the utility's window."]

        [$"\nConversely, use the {new ExternalReference("https://developer.android.com/studio/command-line/adb", "adb")} to add the new Environment. Write `adb shell am start` and add the link. An example of the request:"]
        [$"\n`adb shell am start http://www.antilatency.com/antilatencyservice/environment?data=AAVSaWdpZE8BBnllbGxvdwgIuFOJP9xGoD6vjmO9mpmZPgAAAAAAAAAAAJqZGT8NBQAEAwAGAwYCBAIDAAUHBgQDAwUAAAIHBgcGBwYHBwIHAgcGAgMDdzk%name=DevKitX`"]
    
   //[new Info($"Подробнее о создании и редактировании зон трекинга читайте тут: \n{Tutorials.Environment_Editor}")]
     ]
       ;
        }
    }
}
