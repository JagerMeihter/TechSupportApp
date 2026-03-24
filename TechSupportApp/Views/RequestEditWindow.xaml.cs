using System.Windows;
using TechSupportApp.ViewModels;

namespace TechSupportApp.Views
{
    public partial class RequestEditWindow : Window
    {
        public RequestEditWindow(int? requestId = null)
        {
            InitializeComponent();
            var vm = new RequestEditViewModel(requestId);
            vm.CloseAction = () => DialogResult = true;
            DataContext = vm;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}