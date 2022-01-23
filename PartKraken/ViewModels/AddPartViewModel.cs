using PartKraken.Data.Factories;
using PartKraken.Navigation;
using PartKraken.Navigation.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PartKraken.ViewModels
{
    internal class AddPartViewModel: BaseViewModel
    {
        private readonly AppDbContextFactory _dbFactory;
        private Navigator? _navigator;
        public ICommand CloseCommand { get; set; }

        private string _partName;
        public string Partname
        {
            get => _partName;
            set => OnPropertyChanged(ref _partName, value);
        }

        private string _partnumber;
        public string Partnumber
        {
            get => _partnumber;
            set => OnPropertyChanged(ref _partnumber, value);
        }

        private string _manufactorer;
        public string Manufacturer
        {
            get => _manufactorer;
            set => OnPropertyChanged(ref _manufactorer, value);
        }

        public AddPartViewModel(AppDbContextFactory dbFactory, Navigator navigator)
        {
            _dbFactory = dbFactory;
            _navigator = navigator;
            CloseCommand = new RelayCommand(Close);
        }

        private void Close()
        {
           
        }
    }
}
