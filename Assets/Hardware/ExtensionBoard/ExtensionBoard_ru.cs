using Csml;


partial class Hardware : Scope {

    public static Material ExtensionBoard_ru =>

        new Material(
            "Antilatency Extension Board",
            ExtensionBoard_Assets.TitleImage,
        $"Плата для подключения к {Hardware.HMD_Radio_Socket} внешних компонентов, например, кнопок или LED. С её помощью можно как считывать внешние триггеры, так и управлять внешними устройствами, например, настроить виброотклик.")

        [$"Используя Extension Board, вы можете создавать сложные по структуре устройства на основе HMD Radio Socket."] 
        [$"Мы в Antilatency разработали демонстрационную модель огнетушителя. Её корпус в точности повторяет размеры настоящего огнетушителя. Нажмите на рычаг устройства в реальном мире - оно заработает в виртуальном. Потрясающее сочетание тактильного и визуального восприятия."]
        [$"Практически любой предмет, существующий в реальности, можно таким образом перенести в мир VR."]

        [ExtensionBoard_Assets.Video.GetPlayer()]

        [new Info($"Плата расширения работает через {Terms.Antilatency_Hardware_Extension_Interface} с помощью {Software.Antilatency_Hardware_Extension_Interface_Library}.")]
        
            ;
}