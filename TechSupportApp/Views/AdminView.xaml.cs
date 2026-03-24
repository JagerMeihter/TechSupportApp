using System.Windows;
using System.Windows.Controls;
using TechSupportApp.Views.Admin;
using TechSupportApp.Views;

namespace TechSupportApp.Views
{
    public partial class AdminView : UserControl
    {
        public AdminView()
        {
            InitializeComponent();
        }

        private void OpenUsersWindow(object sender, RoutedEventArgs e)
        {
            new UsersWindow().ShowDialog();
        }

        private void OpenEquipmentTypesWindow(object sender, RoutedEventArgs e)
        {
            new EquipmentTypesWindow().ShowDialog();
        }

        private void OpenStatusesWindow(object sender, RoutedEventArgs e)
        {
            new RequestStatusesWindow().ShowDialog();
        }

        private void OpenPrioritiesWindow(object sender, RoutedEventArgs e)
        {
            new PrioritiesWindow().ShowDialog();
        }

        private void OpenRequestsView(object sender, RoutedEventArgs e)
        {
            var requestsWindow = new Window { Title = "Все заявки", Content = new ManagerRequestsView(), Width = 800, Height = 600 };
            requestsWindow.ShowDialog();
        }
    }
}