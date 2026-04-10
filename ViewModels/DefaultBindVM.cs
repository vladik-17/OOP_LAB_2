using BindingsAndTriggers.Localization;
using CommunityToolkit.Mvvm.ComponentModel;

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

        // Читает строку из RESX — меняется при смене языка
        public string CheckStatus => IsChecked
            ? Localizer.Instance["Status_Checked"]
            : Localizer.Instance["Status_Unchecked"];

        // Вызывается из MainVM при смене языка для обновления CheckStatus в UI
        public void NotifyLanguageChanged()
            => OnPropertyChanged(nameof(CheckStatus));
    }
}
