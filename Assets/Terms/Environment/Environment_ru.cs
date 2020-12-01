using Csml;

public partial class Terms{

public static Material Environment_ru => new Material("Environment", null, $"Разметка зоны трекинга, состоящая из инфракрасных маркеров. Во вкладке {Software.AntilatencyService.Environments.Material} приложения AntilatencyService вы можете создать или отредактировать Environment, а также выбрать конфигурацию по умолчанию.")

[$"Environment - это способ разметки зоны трекинга, то есть реального пространства, в котором пользователь будет взаимодействовать с устройствами Antilatency. Зона трекинга состоит из инфракрасных маркеров. Анализируя их расположение, модуль {Hardware.Alt} определяет своё положение в пространстве."]

[$"{Hardware.TrackingAreaFloor} - один из видов Environment, разработанных командой Antilatency."]

[$"Подробнее о том, как создавать и редактировать Environment в приложении {Software.AntilatencyService.Material}, читайте тут: {Tutorials.Environment_Editor}"]

;

}