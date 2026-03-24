using System.Windows;
using TechSupportApp.ViewModels.Admin;

namespace TechSupportApp.Views.Admin
{
    public partial class PrioritiesWindow : Window
    {
        public PrioritiesWindow()
        {
            InitializeComponent();
            DataContext = new PrioritiesViewModel();
        }
    }
}