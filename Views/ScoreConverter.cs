using System.Globalization;
using System.Windows.Data;

namespace BindingsAndTriggers.Views
{
    // Конвертер оценки в строку для DataTrigger
    // Slider передаёт double — делим на диапазоны: low / mid / high
    public class ScoreConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double d = value switch
            {
                double dv => dv,
                int iv    => (double)iv,
                _         => 100
            };
            if (d < 40) return "low";
            if (d < 70) return "mid";
            return "high";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => Binding.DoNothing;
    }
}
