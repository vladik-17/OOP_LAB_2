using System.ComponentModel;
using System.Globalization;
using System.Resources;
using System.Windows.Data;

namespace BindingsAndTriggers.Localization
{
    // Синглтон-локализатор: читает строки из .resx через ResourceManager.
    // Использование в XAML: Text="{Binding [AppTitle], Source={x:Static loc:Localizer.Instance}}"
    public class Localizer : INotifyPropertyChanged
    {
        public static readonly Localizer Instance = new();

        // ResourceManager для каждого языка — оба embedded в основную сборку
        private readonly ResourceManager _ruRm = new(
            "BindingsAndTriggers.Resources.Strings", typeof(Localizer).Assembly);
        private readonly ResourceManager _enRm = new(
            "BindingsAndTriggers.Resources.Strings.en", typeof(Localizer).Assembly);

        // Индексатор — точка входа для всех XAML-привязок вида {Binding [Key]}
        public string this[string key]
        {
            get
            {
                var rm = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName == "en"
                    ? _enRm : _ruRm;
                return rm.GetString(key) ?? key;
            }
        }

        // Смена языка: обновляет культуру и уведомляет все {Binding [Key]}-привязки
        public void SetLanguage(string cultureCode)
        {
            CultureInfo.CurrentUICulture = new CultureInfo(cultureCode);
            // Binding.IndexerName = "Item[]" — стандартный способ сигнализировать
            // об обновлении всех привязок через индексатор
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(Binding.IndexerName));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
