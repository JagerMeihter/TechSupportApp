using System.Collections.ObjectModel;
using System.Windows;
using TechSupportApp.Models;
using TechSupportApp.Services;
using TechSupportApp.Helpers;

namespace TechSupportApp.ViewModels.Admin
{
    public class RequestStatusesViewModel : ObservableObject
    {
        private RequestStatusService _service;
        private ObservableCollection<RequestStatus> _statuses;
        private RequestStatus _selectedStatus;
        private string _newName;

        public ObservableCollection<RequestStatus> Statuses
        {
            get => _statuses;
            set { _statuses = value; OnPropertyChanged(); }
        }

        public RequestStatus SelectedStatus
        {
            get => _selectedStatus;
            set { _selectedStatus = value; OnPropertyChanged(); }
        }

        public string NewName
        {
            get => _newName;
            set { _newName = value; OnPropertyChanged(); }
        }

        public RelayCommand AddCommand { get; }
        public RelayCommand EditCommand { get; }
        public RelayCommand DeleteCommand { get; }

        public RequestStatusesViewModel()
        {
            _service = new RequestStatusService();
            LoadData();

            AddCommand = new RelayCommand(_ => Add());
            EditCommand = new RelayCommand(_ => Edit(), _ => SelectedStatus != null);
            DeleteCommand = new RelayCommand(_ => Delete(), _ => SelectedStatus != null);
        }

        private void LoadData()
        {
            Statuses = new ObservableCollection<RequestStatus>(_service.GetAll());
        }

        private void Add()
        {
            if (!string.IsNullOrWhiteSpace(NewName))
            {
                _service.Add(new RequestStatus { Name = NewName });
                LoadData();
                NewName = "";
            }
        }

        private void Edit()
        {
            var result = Microsoft.VisualBasic.Interaction.InputBox("Введите новое название:", "Редактирование", SelectedStatus.Name);
            if (!string.IsNullOrEmpty(result))
            {
                SelectedStatus.Name = result;
                _service.Update(SelectedStatus);
                LoadData();
            }
        }

        private void Delete()
        {
            if (MessageBox.Show("Удалить запись?", "Подтверждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                _service.Delete(SelectedStatus.Id);
                LoadData();
            }
        }
    }
}