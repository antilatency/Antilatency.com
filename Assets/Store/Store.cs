using Csml;
using System.Collections.Generic;

partial class Store : Scope {

    public static LanguageSelector<IMaterial> PresetEditor => new LanguageSelector<IMaterial>();


    public static Product ACHA0Alt__A => new Product(Hardware.Alt, "ACHA0Alt__A", 650)
        .AddPriceBreak(4, 598)
        .AddPriceBreak(16, 550)
        .AddPriceBreak(64, 506)
        .AddPriceBreak(256, 466)
        .AddPriceBreak(1024, 428);

    public static Product ACHA0Socket__A => new Product(Hardware.SocketUsb, "ACHA0Socket__A", 50)
        .AddPriceBreak(4, 46)
        .AddPriceBreak(16, 42)
        .AddPriceBreak(64, 39)
        .AddPriceBreak(256, 36)
        .AddPriceBreak(1024, 33);

    public static Product ACHA0RadioSocket__A => new Product(Hardware.HMD_Radio_Socket, "ACHA0RadioSocket__A", 75)
        .AddPriceBreak(4, 69)
        .AddPriceBreak(16, 63)
        .AddPriceBreak(64, 58)
        .AddPriceBreak(256, 54)
        .AddPriceBreak(1024, 49);

    public static Product ACHA0Socket__RA => new Product(Hardware.Tag, "ACHA0Socket__RA", 75)
        .AddPriceBreak(4, 69)
        .AddPriceBreak(16, 63)
        .AddPriceBreak(64, 58)
        .AddPriceBreak(256, 54)
        .AddPriceBreak(1024, 49);

    public static Product ACHA0Bracer__RA => new Product(Hardware.Bracer, "ACHA0Bracer__RA", 90)
        .AddPriceBreak(4, 83)
        .AddPriceBreak(16, 76)
        .AddPriceBreak(64, 70)
        .AddPriceBreak(256, 64)
        .AddPriceBreak(1024, 59);

    public static Product ACHA0PicoG2Socket__A => new Product(Hardware.PicoG2Socket, "ACHA0PicoG2Socket__A", 75)
        .AddPriceBreak(4, 69)
        .AddPriceBreak(16, 63)
        .AddPriceBreak(64, 58)
        .AddPriceBreak(256, 54)
        .AddPriceBreak(1024, 49);

    public static Product TrackingArea10m2 => new Product(Hardware.TrackingAreaFloor, "TrackingArea10m2", 250);


    public static IEnumerable<Product> ActiveProducts => new Product[] {
        ACHA0Alt__A,
        ACHA0Socket__A,
        ACHA0RadioSocket__A,
        ACHA0Socket__RA,
        ACHA0Bracer__RA,
        ACHA0PicoG2Socket__A,
        TrackingArea10m2
    };


    public static Material PresetEditor_en => new Material("Store", null, $"Welcome to Antilatency store!")
        [ActiveProducts]
        [new PresetEditor()
        ];



}