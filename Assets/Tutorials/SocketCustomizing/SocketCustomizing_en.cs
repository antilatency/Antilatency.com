using Csml;
using System.Net.Sockets;
using static Tutorials.SocketCustomizing_Assets;

partial class Tutorials : Scope {

    public static Material SocketCustomizing_en =>

        new Material(
            "Customize your Socket",
            null,
        $"Learn how to make your {Terms.Socket} using {Terms.SocketReferenceDesign}")
            [new Section("To customize your Socket you need:")
                [new OrderedList()
                    [$"The board"]
                    [$"Ready-to-install mechanical components"]
                    [$"An up-to-date Antilatency firmware"]
                    [$"{Hardware.Alt}"]
                ]
            ]

            [new Section("Board design")
                [$"You can take the {Terms.SocketReferenceDesign} as an example and use its modules for your project."]
                [$"We recommend making the connection between an SPI and the {Hardware.Alt} as short as possible and to protect it from disturbance."]
                [$"The nRF module's position should correspond to its DataSheet requirements. Pay extra attention to the position of the antenna."]
                [$"The circuitry, a tracing example, a 3D model, a BOM, and Gerber are *available to download*."]
               
                [CustomMaterials]
            ]

            [new Section("Prepare the mechanical components")
                [$"The {Hardware.Alt} mounting is the main thing you need to take into account. It requires the magnet and the frame to keep {Hardware.Alt} in the right position."]
                [new Section("The magnet mounting","")
                    [$"We use magnets that have a diameter of 7mm, 2mm high, and of grade N52. They perfectly match the 6.9mm board hole."]
                    [$"Before mounting prepare a board, a magnet, and the {Hardware.Alt}."]
                            [MagnetMount0]
                        [$"*Step 1.* To find out the magnet polarity, connect it to the {Hardware.Alt}. Mark the side of the magnet you need to be on the reverse side of the board. We used a red marker."]
                        [new Warning($"If you confuse the side, the {Hardware.Alt} will push off from {Terms.Socket}.")]
                            [MagnetMount1]
                        [$"*Step 2.* Use the vise to gently install the magnet under pressure."]
                            [MagnetMount2]
                            [MagnetMount3]
                        [$"*Step 3.* Check out if the magnet's plane corresponds to the plane of the board."]
                        [new Warning($"If the magnet is mounted at an angle, the connectivity of the {Hardware.Alt}'s pins and the board will be unstable.")]
                            [MagnetMount4]
                            [MagnetMount5]
                        [$"*Step 4.* Connect the {Hardware.Alt} and check if the magnet holds the tracker."]
                            [MagnetMount6]
                ]
                
                [new Section("The holder mounting","")
                    [$"As a frame for {Hardware.Alt} we use an aluminum holder with 4 feet. After planishing these foot will fix the holder on the board. The holder model is available to download."]
                    [Holder3D]
                        [$"Before mounting, prepare a board with a magnet, the {Hardware.Alt}, a punch, and a hammer."]
                            [HolderMount1]
                        [$"*Step 1.* Set the holder on the board."]
                            [HolderMount2]
                        [$"*Step 2.* Turn over the board and put it on a rigid surface. For example, on the table."]
                        [new Warning($"We highly recommend putting something underneath it to prevent the holder from damage. For example, a piece of cardboard.")]
                            [HolderMount3]
                        [$"*Step 3.* Center the punch on the feet and gently struck it with a hammer several times. Repeat these actions for each foot."]
                            [HolderMount4]
                            [HolderMount5]
                        [$"*Step 4.* As the result the feet will fix the holder on the board."]
                            [HolderMount6]
                            [HolderMount7]
                        [$"*Step 5.* Connect the {Hardware.Alt} and check if it fits the holder. Turn over the board, put it up and down to be sure that the tracker stays safely in the right position."]
                            [HolderMount8]
                ]
            ]

            [new Section("Antilatency firmware")
                [$"Download the .bin file from the website, it's a bootloader. Install it on the board using the SWD pins and a programmer (for example, Jlink)."]
                [new Info($"Some manufacturers offer a preinstalled firmware/bootloader. You can even send them your firmware to be installed.")]
                [$"When the bootloader is installed, use the USB connector and update the firmware with {Terms.AntilatencyService}. The functionality is similar to  {Hardware.SocketUsbRadio}, including {Terms.Antilatency_Hardware_Extension_Interface} support, the {Terms.AntilatencyService} update system, and two modes for {Terms.Antilatency_Radio_Protocol}."]
            ]
            ;
}
