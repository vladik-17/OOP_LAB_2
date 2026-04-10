using System.Windows;
using BindingsAndTriggers.ViewModels;

namespace BindingsAndTriggers
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainVM();
        }
    }
}
