using System.ComponentModel;
using System.Globalization;
using System.Resources;
using System.Windows.Data;

namespace LocalizationLib
{
    // Публичный API библиотеки локализации.
    // Использование в XAML основного проекта:
    //   xmlns:lib="clr-namespace:LocalizationLib;assembly=LocalizationLib"
    //   Text="{Binding [Key], Source={x:Static lib:Translator.Instance}}"
    public class Translator : INotifyPropertyChanged
    {
        public static readonly Translator Instance = new();

        // Два ResourceManager — по одному на каждый язык
        private readonly ResourceManager _ruRm = new(
            "LocalizationLib.Strings.ru", typeof(Translator).Assembly);
        private readonly ResourceManager _enRm = new(
            "LocalizationLib.Strings.en", typeof(Translator).Assembly);

        // Индексатор — возвращает строку для текущей культуры
        public string this[string key]
        {
            get
            {
                var rm = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName == "en"
                    ? _enRm : _ruRm;
                return rm.GetString(key) ?? key;
            }
        }

        // Смена языка и уведомление всех {Binding [Key]}-привязок в XAML
        public void SetLanguage(string cultureCode)
        {
            CultureInfo.CurrentUICulture = new CultureInfo(cultureCode);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(Binding.IndexerName));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
