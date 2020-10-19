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
                ]
            ]

            [new Section("Board design")
                [$"You can take the {Terms.SocketReferenceDesign} as an example and use its modules for your project. The circuitry, a tracing example, a 3D model, a BOM, and Gerber are available to download."]
                [$"We recommend making the connection between an SPI and the {Hardware.Alt} as short as possible and to protect it from disturbance."]
                [$"The nRF module's position should correspond to its DataSheet requirements. Pay extra attention to the position of the antenna."]
               
                [new ToDo("Ссылка на даташит.")]
            ]

            [new Section("Prepare the mechanical components")
                [$"The {Hardware.Alt} mounting is the main thing you need to take into account. It requires the magnet and the frame to keep {Hardware.Alt} in the right position."]
                [$"We use magnets that have a diameter of 7mm, 2mm high, and of grade N52. They perfectly match the 6.9mm board hole."]
                
                [new ToDo("Alt frame 3D model")]
                [$"As a frame for {Hardware.Alt} we use an aluminum holder with 4 feet. After planishing these foot will fix the holder on the board. The holder model is available to download."]
                [new ToDo("Обновить фотки, когда будут платы.")]
                [$"Top view:"]
                [AltMount1]
                [$"Bottom view:"]
                [AltMount2]
            ]

            [new Section("Antilatency firmware")
                [$"Download the .bin file from the website, it's a bootloader. Install it on the board using the SWD pins and a programmer (for example, Jlink)."]
                [new Info($"Some manufacturers offer a preinstalled firmware/bootloader. You can even send them your firmware to be installed.")]
                [$"When the bootloader is installed, use the USB connector and update the firmware with {Terms.AntilatencyService}. The functionality is similar to  {Hardware.SocketUsbRadio}, including {Terms.Antilatency_Hardware_Extension_Interface} support, the {Terms.AntilatencyService} update system, and two modes for {Terms.Antilatency_Radio_Protocol}."]
            ]
            ;
}