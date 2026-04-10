using BindingsAndTriggers.Localization;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows;

namespace BindingsAndTriggers.ViewModels
{
    // ViewModel для вкладки "Привязка по умолчанию"
    public partial class DefaultBindVM : ObservableObject
    {
        [ObservableProperty]
        private string _inputText = "Введите текст";

        [ObservableProperty]
        private int _sliderValue = 50;

        [ObservableProperty]
        private bool _isChecked;

        public DefaultBindVM()
        {
            // Подписываемся на смену языка — обновляем CheckStatus в UI
            DictionaryLocalizer.LanguageChanged += () => OnPropertyChanged(nameof(CheckStatus));
        }

        partial void OnIsCheckedChanged(bool value)
            => OnPropertyChanged(nameof(CheckStatus));

        // Читает строку из текущего ResourceDictionary приложения
        public string CheckStatus => IsChecked
            ? Application.Current.Resources["Status_Checked"]?.ToString() ?? "Отмечено"
            : Application.Current.Resources["Status_Unchecked"]?.ToString() ?? "Не отмечено";
    }
}
