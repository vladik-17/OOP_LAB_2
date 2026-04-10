using CommunityToolkit.Mvvm.ComponentModel;
using LocalizationLib;

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

        partial void OnIsCheckedChanged(bool value)
            => OnPropertyChanged(nameof(CheckStatus));

        // Переводимый статус через внешнюю библиотеку
        public string CheckStatus => IsChecked
            ? Translator.Instance["Status_Checked"]
            : Translator.Instance["Status_Unchecked"];

        // Вызывается из MainVM при смене языка
        public void NotifyLanguageChanged() => OnPropertyChanged(nameof(CheckStatus));
    }
}
