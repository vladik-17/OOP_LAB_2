using BindingsAndTriggers.Localization;
using CommunityToolkit.Mvvm.ComponentModel;

namespace BindingsAndTriggers.ViewModels
{
    // Корневой ViewModel — агрегирует VM всех вкладок и управляет языком
    public partial class MainVM : ObservableObject
    {
        public DefaultBindVM DefaultBind { get; } = new();
        public TwoWayBindVM TwoWayBind { get; } = new();
        public OneTimeBindVM OneTimeBind { get; } = new();
        public OneWayBindVM OneWayBind { get; } = new();
        public TriggersVM Triggers { get; } = new();

        // Список языков для ComboBox в заголовке
        public List<string> Languages { get; } = ["Русский", "English"];

        [ObservableProperty]
        private string _selectedLanguage = "Русский";

        // Хук — вызывается при выборе другого языка в ComboBox
        partial void OnSelectedLanguageChanged(string value)
            => DictionaryLocalizer.SetLanguage(value == "Русский" ? "ru" : "en");
    }
}
