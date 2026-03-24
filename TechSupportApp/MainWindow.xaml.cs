using System.Windows;
using TechSupportApp.ViewModels;

namespace TechSupportApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
}