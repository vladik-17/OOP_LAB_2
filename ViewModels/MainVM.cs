using CommunityToolkit.Mvvm.ComponentModel;

namespace BindingsAndTriggers.ViewModels
{
    // Корневой ViewModel — агрегирует VM всех вкладок
    public partial class MainVM : ObservableObject
    {
        public DefaultBindVM DefaultBind { get; } = new();
        public TwoWayBindVM TwoWayBind { get; } = new();
        public OneTimeBindVM OneTimeBind { get; } = new();
        public OneWayBindVM OneWayBind { get; } = new();
        public TriggersVM Triggers { get; } = new();
    }
}
