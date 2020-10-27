using Csml;
using System.Net.Sockets;
using static Tutorials.SocketCustomizing_Assets;

partial class Tutorials : Scope {

    public static Material SocketCustomizing_en =>

        new Material(
            "Customize your Socket",
            null,
        $"Learn how to make your {Terms.Socket} using {Hardware.SocketReferenceDesign}. You can use the modules from the Antilatency development board or choose other components that correspond to the recommendations given below.")
            [new Section("To customize your Socket you need:")
                [new OrderedList()
                    [$"A PCB"]
                    [$"Ready-to-install mechanical components"]
                    [$"An up-to-date Antilatency firmware"]
                    [$"{Hardware.Alt} (to test your Socket)"]
                ]
            ]

            [new Section("Board design")
                [$"You can take the SocketReferenceDesign as an example and use its modules for your project."]
                [$"We recommend making the connection between an SPI and the Alt as short as possible and to protect it from electromagnetic interference."]
                [$"The nRF module's position should correspond to its dataSheet requirements. Pay extra attention to the position of the antenna."]
                [$"The circuitry, a 3D model, a BOM, Gerber and nRF52840 MS88SF3 V1.1 datasheet are *available to download*."]
               
                [CustomMaterials]
            ]

            [new Section("Prepare the mechanical components","mechanics")
                [$"The Alt mounting is the main thing you need to take into account. It requires the magnet and the frame to keep Alt in the right position."]
                [new Section("The magnet mounting","")
                    [$"We use magnets that have a diameter of 7mm, 2mm high, and of grade N52. They perfectly match the 6.9mm board hole."]
                    [new Note($"Keep in mind that after you finished with mounting you are no more allowed to solder the board. The overheated magnet looses its features.")]
                    [$"Before mounting, prepare the board, the magnet, and the Alt."]
                            [MagnetMount0]
                        [$"*Step 1.* To find out the magnet polarity, connect it to the Alt. Mark the side of the magnet you need to be on the reverse side of the board. We used a red marker."]
                        [new Warning($"If you confuse the side, the Alt will push away from the Socket.")]
                            [MagnetMount1]
                        [$"*Step 2.* Use a vise to gently fix the magnet in place with pressure."]
                            [MagnetMount2]
                            [MagnetMount3]
                        [$"*Step 3.* Check that the magnet's plane corresponds to the plane of the board."]
                        [new Warning($"If the magnet is mounted at an angle, the connectivity of the Alt's pins and the board will be unstable.")]
                            [MagnetMount4]
                            [MagnetMount5]
                        [$"*Step 4.* Connect the Alt and check if the magnet holds the tracker."]
                            [MagnetMount6]
                ]
                
                [new Section("The holder mounting","")
                    [$"As a frame for the Alt we use an aluminum holder with 4 feet. After planishing these foot will fix the holder on the board. The holder model is available to download."]
                    [Holder3D]
                        [$"Before mounting, prepare a board with a magnet, the Alt, a punch, and a hammer."]
                            [HolderMount1]
                        [$"*Step 1.* Set the holder on the board."]
                            [HolderMount2]
                        [$"*Step 2.* Turn the board over and put it on a rigid surface. For example, on a table."]
                        [new Warning($"We highly recommend putting something underneath it to prevent the holder from being damaged. For example, a piece of cardboard.")]
                            [HolderMount3]
                        [$"*Step 3.* Center the punch on the feet and gently strike it with a hammer several times. Repeat these actions for each foot."]
                            [HolderMount4]
                            [HolderMount5]
                        [$"*Step 4.* As a result the feet will fix the holder to the board."]
                            [HolderMount6]
                            [HolderMount7]
                        [$"*Step 5.* Connect the Alt and check if it fits the holder. Turn over the board, lift it up and down to ensure that the tracker stays safely in the right position."]
                            [HolderMount8]
                ]
            ]

            [new Section("Antilatency firmware")
                [$"Download the .bin file from the website, it's a bootloader. Load it on the board using the SWD pins and a programmer (for example, Jlink)."]
                [new Info($"Some manufacturers offer a pre-loaded firmware/bootloader. You can even send them your firmware to be installed.")]
                [$"After this, use the USB connector and update the firmware with {Software.AntilatencyService.Material}. The functionality is similar to {Hardware.SocketUsbRadio}, including {Terms.Antilatency_Hardware_Extension_Interface} support, the AntilatencyService update system, and two modes for {Terms.Antilatency_Radio_Protocol}."]
            ]
            ;
}
