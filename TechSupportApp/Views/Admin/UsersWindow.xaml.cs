using System.Windows;
using TechSupportApp.ViewModels.Admin;

namespace TechSupportApp.Views.Admin
{
    public partial class UsersWindow : Window
    {
        public UsersWindow()
        {
            InitializeComponent();
            DataContext = new UsersViewModel();
        }
    }
}