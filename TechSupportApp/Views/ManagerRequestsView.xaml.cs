using System.Windows.Controls;
using TechSupportApp.ViewModels;

namespace TechSupportApp.Views
{
    public partial class ManagerRequestsView : UserControl
    {
        public ManagerRequestsView()
        {
            InitializeComponent();
            DataContext = new ManagerRequestsViewModel();
        }
    }
}