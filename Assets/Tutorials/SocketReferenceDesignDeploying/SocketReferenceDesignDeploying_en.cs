using Csml;
using System.Net.Sockets;
using static Tutorials.SocketReferenceDesignDeploying_Assets;

partial class Tutorials : Scope {

    public static Material SocketReferenceDesignDeploying_en =>

        new Material(
            "SocketReferenceDesignDeploying",
            null,
        $"Learn how to make your {Terms.Socket} using {Terms.SocketReferenceDesign}")
            [new Section("To custom your Socket you need:")
                [new OrderedList()
                    [$"Designed board"]
                    [$"Ready-to-install mechanical components"]
                    [$"Antilatency firmware"]
                ]
            ]

            [new Section("Board design")
                [$"You can take {Terms.SocketReferenceDesign} as an example and use its modules for your project. The circuit technique, a tracing example, a 3D model, a BOM, and Gerber are available to download."]
                [$"We recommend to make the connection between an SPI and {Hardware.Alt} as short as possible and protect it from disturbance."]
                [$"The nRF module position should correspond to its DataSheet requirements. Pay extra attention to the antenna."]
               
                [new ToDo("Ссылка на даташит.")]
            ]

            [new Section("Preparing the mechanical components")
                [$"The {Hardware.Alt} mounting is the main thing you need to take into account. It requires the magnet and the frame to keep {Hardware.Alt} in a right and stable position."]
                [$"We use the magnets that has a diameter of 7mm, 2mm high, and N52 grade. It perfectly matches to the 6.9mm board hole."]
                
                [new ToDo("Alt frame 3D model")]
                [$"As a frame for {Hardware.Alt} we use an aluminum cup with 4 foots. After planishing these foot will fix the cup on the board. The cup model is available to download."]
                [new ToDo("Обновить фотки, когда будут платы.")]
                [$"Top view:"]
                [AltMount1]
                [$"Bottom view:"]
                [AltMount2]
            ]

            [new Section("Antilatency firmware")
                [$"Download *.bin file from the website, it's a bootloader. Install it on the board using SWD pins and a programmer(for example, Jlink)."]
                [new Info($"Some manufacturers offer preinstalled firmware/bootloader. You can even send them your firmware to be installed.")]
                [$"When bootloader is installed, use the USB connector and update the firmware with{Terms.AntilatencyService}. The functinality is similar to  {Hardware.SocketUsbRadio}, including {Terms.Antilatency_Hardware_Extension_Interface} support, {Terms.AntilatencyService} updating system and two modes for {Terms.Antilatency_Radio_Protocol}."]
            ]
            ;
}