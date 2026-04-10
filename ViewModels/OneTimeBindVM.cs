using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BindingsAndTriggers.ViewModels
{
    // ViewModel для вкладки "Одноразовая привязка" (OneTime)
    // [RelayCommand] автоматически генерирует команду ReloadCommand
    public partial class OneTimeBindVM : ObservableObject
    {
        // Генерирует свойство DynamicText
        [ObservableProperty]
        private string _dynamicText;

        public OneTimeBindVM()
        {
            _dynamicText = $"Загружено: {DateTime.Now:HH:mm:ss}";
        }

        // Генерирует команду ReloadCommand из метода Reload
        [RelayCommand]
        private void Reload()
            => DynamicText = $"Обновлено: {DateTime.Now:HH:mm:ss}";
    }
}
