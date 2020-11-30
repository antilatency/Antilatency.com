using Csml;
using static Api.Antilatency.DeviceNetwork;

public partial class Terms {

public static Material Node_ru => new Material("Node", null, $"Узел в {Terms.Device_Tree}, которым может выступать любое из устройств Antilatency, подключённых к одному {Terms.Host}.")

[$"Все устройства Antilatency, подключённые к одному Host, образуют сеть. При подключении к этой сети, каждое устройство получает идентификатор {NodeHandle.NameRefCode}. Идентификаторы не повторяются в процессе работы одного экземпляра сети."]
[$"Любой узел дерева устройств может содержать {Terms.Task}."]
; 

}
