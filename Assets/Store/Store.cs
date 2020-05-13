using Csml;
using System.Collections.Generic;

partial class Store : Scope {

    public static LanguageSelector<IMaterial> PresetEditor => new LanguageSelector<IMaterial>();


    public static Product ACHA0Alt__A => new Product(Hardware.Alt, 500)
        .AddPriceBreak(10, 450)
        .AddPriceBreak(50, 350);

    public static Product ACHA0Bracer__RA => new Product(Hardware.Alt, 100)
        .AddPriceBreak(10, 95)
        .AddPriceBreak(50, 90);


    public static IEnumerable<Product> ActiveProducts => new Product[] {
        ACHA0Alt__A,
        ACHA0Bracer__RA,
    };


    public static Material PresetEditor_en => new Material("Store", null, $"Welcome to Antilatency store!")
        [new PresetEditor()
        ];



}