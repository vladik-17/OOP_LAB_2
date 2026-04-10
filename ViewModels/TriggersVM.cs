using CommunityToolkit.Mvvm.ComponentModel;

namespace BindingsAndTriggers.ViewModels
{
    // ViewModel для вкладки "Триггеры"
    // Все свойства генерируются через [ObservableProperty]
    public partial class TriggersVM : ObservableObject
    {
        // Текст для DataTrigger — меняет оформление при вводе "ошибка"
        [ObservableProperty]
        private string _inputText = "";

        // Флаг для Trigger на CheckBox
        [ObservableProperty]
        private bool _isActive;

        // Оценка для DataTrigger + конвертер (цвет бейджа)
        [ObservableProperty]
        private double _score = 75;

        // Флаги для MultiDataTrigger
        [ObservableProperty]
        private bool _isBold;

        [ObservableProperty]
        private bool _isItalic;
    }
}
