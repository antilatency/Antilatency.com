using Csml;
using static Terms.Environment_Assets;

public partial class Terms{

public static Material Environment_ru => new Material("Environment", null, $"Разметка зоны трекинга, состоящая из инфракрасных маркеров. Во вкладке {Software.AntilatencyService.Environments.Material} приложения AntilatencyService вы можете создать или отредактировать Environment, а также выбрать конфигурацию по умолчанию.")

[$"Environment - это способ разметки зоны трекинга, то есть реального пространства, в котором пользователь будет взаимодействовать с VR устройствами Antilatency."]

[$"Зона трекинга состоит из баров с инфракрасными маркерами. Бары образуют уникальные комбинации - `фичи (иначе, feature)`. Анализируя расположение таких комбинаций, модуль {Hardware.Alt} определяет своё положение в пространстве. Качество трекинга напрямую зависит от того, насколько плотно и равномерно расположены фичи."]

[$"{Tutorials.Environment_Editor} поддерживает режим отображения фич."]

[DisplayFeatures]

[new Info($"Подробнее о том, как создавать и редактировать Environment в приложении {Software.AntilatencyService.Material}, читайте тут: {Tutorials.Environment_Editor}")]

;

}