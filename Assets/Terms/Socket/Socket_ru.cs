using Csml;
partial class Terms {
    public static Material Socket_ru => new Material("Socket",  SocketImage,
    @$"Socket - это устройство с разъёмом для подключения модуля {Hardware.Alt}, которое через {Terms.Antilatency_Radio_Protocol} или по USB может передавать данные с трекера.")

    [$"Сам по себе Alt не может передавать данные о положении объекта в пространстве. Для этого его нужно подключить к Socket с радиомодулем. Например, к {Hardware.Tag} или к {Hardware.HMD_Radio_Socket}."]

    [$"Кроме того, некоторые модели обладают дополнительным функционалом. К примеру, {Hardware.Bracer} имеет сенсорную панель и модуль виброотклика, управляемый из приложения пользователя."]

    [$"Socket может работать в одном из двух режимов: radio master или radio slave. Подробнее о режимах работы читайте тут: {Tutorials.HMDSocketMode}"]

    [$"Мы разработали отладочную плату для Socket, на основе которой вы можете создать своё устройство для работы с Alt.Подробнее об этом продукте читайте тут: {Hardware.SocketReferenceDesign}"]
    ;
}
