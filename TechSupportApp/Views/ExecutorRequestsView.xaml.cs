using System.Windows.Controls;
using TechSupportApp.ViewModels;

namespace TechSupportApp.Views
{
    public partial class ExecutorRequestsView : UserControl
    {
        public ExecutorRequestsView()
        {
            InitializeComponent();
            DataContext = new ExecutorRequestsViewModel();
        }
    }
}