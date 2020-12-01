using Csml;

public partial class Terms{

public static Material Task_ru => new Material("Task", null, $"Подпрограмма, которая может быть запущена на Node любого устройства {Terms.Antilatency_Device_Network}. Task определяет, какие задачи будет выполнять устройство.")

[$"Для каждого устройства Antilatency есть ряд доступных задач. Например, на трекере {Hardware.Alt} можно запустить Task работы со свойствами и Task трекинга."]
[$"Когда запущен Task работы со свойствами, пользователь может читать и писать свойства для устройства."]
[$"Если запущен Task трекинга, то модуль Alt собирает и отправляет данные датчиков о положении объекта в пространстве. "]

[$"Во время запуска задачи между {Terms.Host} и узлом устанавливается двунаправленный канал связи. Каждый Task работает в паре с соответствующим ему {Terms.Cotask}."]

[$"На одном узле нельзя запустить две и более задач. К примеру, если Task трекинга уже запущен, то вы не можете получить доступ к свойствам узла. Прежде чем запустить новую задачу, необходимо завершить предыдущую."]
;

}