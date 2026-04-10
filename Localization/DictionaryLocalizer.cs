using System.Windows;

namespace BindingsAndTriggers.Localization
{
    // Статический локализатор для подхода ResourceDictionary.
    // Смена языка: заменяет языковой словарь в MergedDictionaries приложения,
    // после чего все {DynamicResource} в XAML обновляются автоматически.
    public static class DictionaryLocalizer
    {
        private static readonly Uri RuUri = new("Localization/Strings.ru.xaml", UriKind.Relative);
        private static readonly Uri EnUri = new("Localization/Strings.en.xaml", UriKind.Relative);

        // Событие для уведомления VM-классов о смене языка
        public static event Action? LanguageChanged;

        public static void SetLanguage(string cultureCode)
        {
            var uri = cultureCode == "en" ? EnUri : RuUri;
            var newDict = new ResourceDictionary { Source = uri };

            var merged = Application.Current.Resources.MergedDictionaries;

            // Находим и удаляем текущий языковой словарь
            var current = merged.FirstOrDefault(d =>
                d.Source?.OriginalString.Contains("Strings.") == true);
            if (current != null)
                merged.Remove(current);

            // Добавляем новый — все {DynamicResource} обновятся автоматически
            merged.Add(newDict);

            LanguageChanged?.Invoke();
        }
    }
}
