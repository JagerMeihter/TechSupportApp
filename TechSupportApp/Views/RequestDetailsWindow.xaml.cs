using System.Windows;
using TechSupportApp.ViewModels;

namespace TechSupportApp.Views
{
    public partial class RequestDetailsWindow : Window
    {
        public RequestDetailsWindow(int requestId)
        {
            InitializeComponent();
            DataContext = new RequestDetailsViewModel(requestId);
        }
    }
}