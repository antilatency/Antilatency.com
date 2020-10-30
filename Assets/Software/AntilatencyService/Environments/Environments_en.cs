using Csml;
public partial class Software : Scope {
    public partial class AntilatencyService : Scope{
        public partial class Environments{

    public static Material Material_en => new Material("Environments",
    EnvironmentsTabScreenshot,
    $"Use this {AntilatencyService.Material} tab to manage the parameters of the {Terms.Environment}. You can create a new environment or load one from a link, configure it, and check the density of the features, using the Environment's editor.")

     [new Info($"Please, read here how to set up the tracking area: \n{Tutorials.Devkit_Tracking_Area_Setup}")]

     
     [new Section("Environment by default")

        [($"You can set the Environment to the default configuration in two ways. Use the \"*set as default*\" option ...")]
        [SetAsDefault1]
       
        [$"... or set it with *a long click*."]
        [SetAsDefault2]
         
     ]

     [new Section("Environment's link","tracking_area_link")
        [$"You can share the {Terms.Environment} with other users by using the link. It looks like this:"]
        
            [$"`http://www.antilatency.com/antilatencyservice/environment?`*data*`=AAVSaWdpZE8BBnllbGxvdwgIuFOJP9xGoD6vjmO9mpmZPgAAAAAAAAAAAJqZGT8NBQAEAwAGAwYCBAIDAAUHBgQDAwUAAAIHBgcGBwYHBwIHAgcGAgMDdzk&`*name*`=DevKitX&`*setAsDefault*`=true&`*silent*`=true`"]
            [$"\nThe link has several parameters (\"data\" and \"name\" are obligatory)."]
            [$"*data* - the encrypted data for the tracking area; \n*name* - you can edit this later; \n*setAsDefault* - automatically set this area to default right after adding; \n*silent* - used for Android; you can add the tracking area by clicking the link without opening the AntilatencyService."]

            [new Section("How to share the Environment","")]
        [$"Use the \"*share*\" option to copy the link of the tracking area. Then send this link to other users in a convenient way."]
        [Share]
            [new Section("How to add the Environment","")]
        [$"Use the \"*from link*\" option to add a new tracking area. Here you can edit the name of the Environment."]
            [new Note($"Copy the link in advance to automatically fill in the form with data from the clipboard.")]
        [FromLink]
        
        [$"\nTo add a new Environment using an Android device, choose the \"*from link*\" option or click the link itself to open the AntilatencyService with a prefilled form. If the link contains the \"*silent*\" parameter, you can add a new Environment even without opening the utility's window."]

        [$"\nConversely, use {new ExternalReference("https://developer.android.com/studio/command-line/adb", "adb")} to add a new Environment. Write `adb shell am start` and add the link after it. Here is an example request:"]
        [$"\n`adb shell am start http://www.antilatency.com/antilatencyservice/environment?data=AAVSaWdpZE8BBnllbGxvdwgIuFOJP9xGoD6vjmO9mpmZPgAAAAAAAAAAAJqZGT8NBQAEAwAGAwYCBAIDAAUHBgQDAwUAAAIHBgcGBwYHBwIHAgcGAgMDdzk%name=DevKitX`"]
    
   //[new Info($"Подробнее о создании и редактировании зон трекинга читайте тут: \n{Tutorials.Environment_Editor}")]
     ]
       ;
        }
    }
}
