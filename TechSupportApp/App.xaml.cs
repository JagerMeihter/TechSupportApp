using System.Windows;
using TechSupportApp.Models;

namespace TechSupportApp
{
    public partial class App : Application
    {
        public static User CurrentUser { get; set; }
    }
}