using CommunityToolkit.Mvvm.ComponentModel;

namespace BindingsAndTriggers.ViewModels
{
    // ViewModel для вкладки "Привязка по умолчанию"
    // [ObservableProperty] автоматически генерирует свойство + уведомления
    public partial class DefaultBindVM : ObservableObject
    {
        // Генерирует свойство InputText с OnPropertyChanged
        [ObservableProperty]
        private string _inputText = "Введите текст";

        // Генерирует свойство SliderValue с OnPropertyChanged
        [ObservableProperty]
        private int _sliderValue = 50;

        // Генерирует свойство IsChecked с OnPropertyChanged
        [ObservableProperty]
        private bool _isChecked;

        // Хук — вызывается автоматически при изменении IsChecked
        // Уведомляем зависимое вычисляемое свойство
        partial void OnIsCheckedChanged(bool value)
            => OnPropertyChanged(nameof(CheckStatus));

        // Вычисляемое свойство — зависит от IsChecked
        public string CheckStatus => IsChecked ? "Отмечено" : "Не отмечено";
    }
}
