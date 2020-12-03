using Csml;
using System;
using static Tutorials.Set_Device_Custom_Properties_Assets;

partial class Tutorials : Scope {

    public static Material Set_Device_Custom_Properties_en => new Material("How to configure device custom properties",
     TitleImage, 
     $"All of the Antilatency devices have their system and custom properties. Use custom properties to configure any device in order to your goals.")
     
    [$"To configure or add a device property, please, use the {Software.AntilatencyService.Device_Network.Material} tab of {Software.AntilatencyService.Material}. When you connect the device to the {Terms.Host}, it displays in the {Terms.Device_Tree}. Choose the name of the device to see its properties."] 
    [$"Here you can:"]
    [new UnorderedList()
    [$"{new ExternalReference("#edit","edit the custom property")}"]
    [$"{new ExternalReference("#addNew","add a new custom property")}"]
    [$"{new ExternalReference("#delete","delete the custom property")}"]
    ]
    
    [new Section("How to edit the custom property","edit")

    [$"Imagine that you have two Bracers: one for the left hand and another for the right hand. To set which device will be attached to which hand, write for the `Tag` property the corresponding value: LeftHand or RightHand."]

        [$"Choose the `Tag` property from the list on the right and set it the `LeftHand` value. Note, the icon of this property has changed."]
            [EditStep1]

        [$"To send settings to the device, click the icon in the lower right corner and choose the *Send settings to device* option. When done, the property’s icon will change back to the default one."]
            [EditStep2]
            [EditResult]
        [new Info($"If you need to reset changes, use the *Reload settings from the device* option.")]
    ]

    [new Section("How to create a new custom property","addNew")

        [$"To add a new custom property, click the *+* icon at the end of the list of the properties."]
            [addNewStep1]

        [$"Set its name and value."]
            [addNewStep2]

        [$"Then use the *Send settings to device* option to save the changes. Note, when done, the property’s icon will change to the default one."]
            [addNewStep3]
            [addNewResult]

        ]

    [new Section("How to delete the custom property","delete")

        [$"To delete any property added by the user, click the *x* icon. If you changed your mind, click on it again."]
            [DeleteStep1]
        
        [$"Use the *Send setting to device* option to save changes."]
            [DeleteStep2]
        ]

    ;
             
} 