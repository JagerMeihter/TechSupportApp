using System.Collections.ObjectModel;
using System.Windows;
using TechSupportApp.Models;
using TechSupportApp.Services;
using TechSupportApp.Helpers;

namespace TechSupportApp.ViewModels.Admin
{
    public class PrioritiesViewModel : ObservableObject
    {
        private PriorityService _service;
        private ObservableCollection<Priority> _priorities;
        private Priority _selectedPriority;
        private string _newName;

        public ObservableCollection<Priority> Priorities
        {
            get => _priorities;
            set { _priorities = value; OnPropertyChanged(); }
        }

        public Priority SelectedPriority
        {
            get => _selectedPriority;
            set { _selectedPriority = value; OnPropertyChanged(); }
        }

        public string NewName
        {
            get => _newName;
            set { _newName = value; OnPropertyChanged(); }
        }

        public RelayCommand AddCommand { get; }
        public RelayCommand EditCommand { get; }
        public RelayCommand DeleteCommand { get; }

        public PrioritiesViewModel()
        {
            _service = new PriorityService();
            LoadData();

            AddCommand = new RelayCommand(_ => Add());
            EditCommand = new RelayCommand(_ => Edit(), _ => SelectedPriority != null);
            DeleteCommand = new RelayCommand(_ => Delete(), _ => SelectedPriority != null);
        }

        private void LoadData()
        {
            Priorities = new ObservableCollection<Priority>(_service.GetAll());
        }

        private void Add()
        {
            if (!string.IsNullOrWhiteSpace(NewName))
            {
                _service.Add(new Priority { Name = NewName });
                LoadData();
                NewName = "";
            }
        }

        private void Edit()
        {
            var result = Microsoft.VisualBasic.Interaction.InputBox("Введите новое название:", "Редактирование", SelectedPriority.Name);
            if (!string.IsNullOrEmpty(result))
            {
                SelectedPriority.Name = result;
                _service.Update(SelectedPriority);
                LoadData();
            }
        }

        private void Delete()
        {
            if (MessageBox.Show("Удалить запись?", "Подтверждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                _service.Delete(SelectedPriority.Id);
                LoadData();
            }
        }
    }
}