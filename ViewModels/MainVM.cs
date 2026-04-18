using CommunityToolkit.Mvvm.ComponentModel;
using LocalizationLib;

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

        public List<string> Languages { get; } = ["Русский", "English"];

        [ObservableProperty]
        private string _selectedLanguage = "Русский";

        // Переключает язык через Translator и уведомляет зависимые VM
        partial void OnSelectedLanguageChanged(string value)
        {
            Translator.Instance.SetLanguage(value == "Русский" ? "ru" : "en");
            DefaultBind.NotifyLanguageChanged();
        }
    }
}
