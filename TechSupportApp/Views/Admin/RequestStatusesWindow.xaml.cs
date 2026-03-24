using System.Windows;
using TechSupportApp.ViewModels.Admin;

namespace TechSupportApp.Views.Admin
{
    public partial class RequestStatusesWindow : Window
    {
        public RequestStatusesWindow()
        {
            InitializeComponent();
            DataContext = new RequestStatusesViewModel();
        }
    }
}