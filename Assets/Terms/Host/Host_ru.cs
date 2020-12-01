using Csml;

public partial class Terms {

public static Material Host_ru => new Material("Host", null, $"")
[$"{Terms.Host} - корневой узел {Terms.Antilatency_Device_Network}, объединяющий все устройства, подключённые к одному Host. Роль Host может выполнять, например, компьютер, шлем виртуальной реальности или VR станция. На Host-устройстве вы можете запускать приложения, задействующие устройства Antilatency."]
[$"Host обрабатывает данные, полученные через USB с точки доступа, которая в свою очередь собирает данные от подключённых к ней клиентов. Подробнее о взаимодействии точки доступа и клиента читайте тут: {Terms.Antilatency_Radio_Protocol}"]

;

}
