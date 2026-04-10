using CommunityToolkit.Mvvm.ComponentModel;

namespace BindingsAndTriggers.ViewModels
{
    // ViewModel для вкладки "Двухсторонняя привязка"
    // Все свойства генерируются через [ObservableProperty]
    public partial class TwoWayBindVM : ObservableObject
    {
        // Генерирует свойство SharedText
        [ObservableProperty]
        private string _sharedText = "Синхронный текст";

        // Генерирует свойство Temperature
        [ObservableProperty]
        private double _temperature = 22.0;

        // Генерирует свойство SelectedColor
        [ObservableProperty]
        private string _selectedColor = "Красный";

        // Список цветов для ComboBox — статичный, не требует уведомлений
        public List<string> Colors { get; } = new()
        {
            "Красный", "Зелёный", "Синий", "Жёлтый", "Фиолетовый"
        };
    }
}
