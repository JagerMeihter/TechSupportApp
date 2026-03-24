using System.Windows;
using TechSupportApp.ViewModels.Admin;

namespace TechSupportApp.Views.Admin
{
    public partial class EquipmentTypesWindow : Window
    {
        public EquipmentTypesWindow()
        {
            InitializeComponent();
            DataContext = new EquipmentTypesViewModel();
        }
    }
}