using PartKraken.Data.Factories;
using PartKraken.Interfaces;
using PartKraken.Models;
using PartKraken.Navigation;
using PartKraken.Navigation.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PartKraken.ViewModels
{
    internal class AppViewModel: BaseViewModel
    {
        private readonly Navigator? _navigator;
        private readonly AppDbContextFactory _dbFactory;
        private readonly IDataService _dataService;
        public BaseViewModel? CurrentViewModel => _navigator.CurrentViewModel;
        public ICommand ExitAppCommand { get; }
        public ICommand NavigateHomeCommand { get; }
        public ICommand NavigateDashboardCommand { get; }
        public ICommand NavigateAddPartCommand { get; }
        public ICommand SearchCommand { get; }
        public AppViewModel(AppDbContextFactory dbFactory, Navigator? navigator, IDataService dataService)
        {
            _dbFactory = dbFactory;
            _navigator = navigator;
            _dataService = dataService;

            _navigator.CurrentViewModelChanged += OnCurrentViewModelChanged;

            ExitAppCommand = new RelayCommand(ExitApp);
            SearchCommand = new RelayCommand(Search);
            List<List<Part>> parts = _dataService.LoadPartList(_dbFactory);
         
            NavigateDashboardCommand = new NavigateCommand<DashboardViewModel>(_navigator, () => new DashboardViewModel(_dbFactory, _navigator, parts));
            NavigateAddPartCommand = new NavigateCommand<AddPartViewModel>(_navigator, () => new AddPartViewModel(_dbFactory, navigator));
        }

        private void Search()
        {
            
        }

        private void ExitApp()
        {
            Application.Current.Shutdown();
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
