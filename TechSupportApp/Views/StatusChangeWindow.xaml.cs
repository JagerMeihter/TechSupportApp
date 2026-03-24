using System.Collections.Generic;
using System.Linq;
using System.Windows;
using TechSupportApp.Services;
using TechSupportApp.Models;

namespace TechSupportApp.Views
{
    public partial class StatusChangeWindow : Window
    {
        private int _requestId;
        private RequestService _requestService;
        private List<RequestStatus> _statuses;

        public StatusChangeWindow(int requestId)
        {
            InitializeComponent();
            _requestId = requestId;
            _requestService = new RequestService();
            _statuses = _requestService.GetRequestStatuses();
            StatusCombo.ItemsSource = _statuses;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (StatusCombo.SelectedItem is RequestStatus selectedStatus)
            {
                var request = _requestService.GetRequestById(_requestId);
                if (request != null)
                {
                    request.StatusId = selectedStatus.Id;
                    _requestService.UpdateRequest(request);
                }
                DialogResult = true;
            }
        }
    }
}