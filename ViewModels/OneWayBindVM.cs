using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BindingsAndTriggers.ViewModels
{
    // ViewModel для вкладки "Односторонние привязки"
    // OneWay: VM → UI,  OneWayToSource: UI → VM
    public partial class OneWayBindVM : ObservableObject
    {
        // Генерирует свойство VmText
        [ObservableProperty]
        private string _vmText = "Текст из ViewModel";

        // Генерирует свойство UiInput
        [ObservableProperty]
        private string _uiInput = "";

        // Генерирует свойство Progress
        [ObservableProperty]
        private int _progress = 0;

        public OneWayBindVM()
        {
            // Таймер обновляет прогресс каждую секунду
            var timer = new System.Timers.Timer(1000);
            timer.Elapsed += (_, _) => Progress = (Progress + 1) % 101;
            timer.Start();
        }

        // Генерирует команду UpdateVmTextCommand из метода UpdateVmText
        [RelayCommand]
        private void UpdateVmText()
            => VmText = $"Обновлено из VM: {DateTime.Now:HH:mm:ss}";
    }
}
