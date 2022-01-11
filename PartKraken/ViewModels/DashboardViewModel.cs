using PartKraken.Data.Factories;
using PartKraken.Interfaces;
using PartKraken.Models;
using PartKraken.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartKraken.ViewModels
{
    internal class DashboardViewModel: BaseViewModel
    {
        private readonly Navigator? _navigator;
        private readonly AppDbContextFactory _dbFactory;
        private readonly IDataService _dataService;

        private List<Part> _steList;
        public List<Part> SteList
        {
            get => _steList;
            set => OnPropertyChanged(ref _steList, value);
        }

        private List<Part> _oreList;
        public List<Part> OreList
        {
            get => _oreList;
            set => OnPropertyChanged(ref _oreList, value);
        }

        private List<Part> _cubList;
        public List<Part> CubList
        {
            get => _cubList;
            set => OnPropertyChanged(ref _cubList, value);
        }

        private List<List<Part>> _parts;
        public List<List<Part>> Parts
        {
            get => _parts;
            set => OnPropertyChanged(ref _parts, value);
        }

        public DashboardViewModel(AppDbContextFactory dbFactory, Navigator? navigator, IDataService dataService)
        {
            _navigator = navigator;
            _dbFactory = dbFactory;
            _dataService = dataService;
            Parts = _dataService.LoadPartList(dbFactory);
        }

    }
}
