using PartKraken.Data.Factories;
using PartKraken.Interfaces;
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
        public AppViewModel(AppDbContextFactory dbFactory, Navigator? navigator, IDataService dataService)
        {
            _dbFactory = dbFactory;
            _navigator = navigator;
            _dataService = dataService;
            _navigator.CurrentViewModelChanged += OnCurrentViewModelChanged;
            ExitAppCommand = new RelayCommand(ExitApp);
           // NavigateHomeCommand = new NavigateCommand<HomeViewModel>(_navigator, () => new HomeViewModel(_dbFactory, _navigator));
            NavigateDashboardCommand = new NavigateCommand<DashboardViewModel>(_navigator, () => new DashboardViewModel(_dbFactory, _navigator, _dataService));
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
