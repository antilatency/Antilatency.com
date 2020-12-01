using Csml;

public partial class Terms{

public static Material Cotask_ru => new Material("Cotask", null, $"Элемент библиотеки {Terms.Antilatency_Device_Network}, который предоставляет пользователю интерфейс для работы с {Terms.Task}, запущенном на {Terms.Node}.")

[$"Если Task может быть запущен на любом узле {Terms.Device_Tree}, то Cotask запускается на {Host}-устройстве. "]
;

}