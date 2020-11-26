using Csml;
using static Api.Antilatency.DeviceNetwork;

public partial class Terms {

public static Material Node_ru => new Material("Node", null, $"Узел в {Terms.Device_Tree}, которым может выступать любое из устройств Antilatency, подключённых к одному {Terms.Host}.")

[$"Все устройства Antilatency, подключённые к одному Host, образуют сеть. При подключении к этой сети, каждое устройство получает идентификатор {NodeHandle.NameRefCode}. Идентификаторы не повторяются в процессе работы одного экземпляра сети."]
[$"В частных случаях некоторые устройства могут отображаться в дереве устройств как два отдельных узла. Например, {Hardware.HMD_Radio_Socket} в режиме клиента, подключённый к Host одновременно через точку доступа и по USB, отобразится дважды под разными именами."]
[new Info($"Подробнее читайте тут: {Tutorials.HMDSocketMode}")]
[$"Любой из узлов дерева устройств может содержать {Terms.Task}."]
; 

}
