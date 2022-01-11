using PartKraken.Data.Factories;
using PartKraken.Models;
using PartKraken.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartKraken.ViewModels
{
    internal class HomeViewModel: BaseViewModel
    {
        private readonly Navigator? _navigator;
        private readonly AppDbContextFactory _dbFactory;

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

        public HomeViewModel(AppDbContextFactory dbFactory, Navigator? navigator)
        {
            _navigator = navigator;
            _dbFactory = dbFactory;
            LoadParts();
        }

        private void LoadParts()
        {
            var db = _dbFactory.CreateDbContext();
            CubList = db.Parts.Where(x => x.MFG == "CUB").ToList();
            SteList = db.Parts.Where(x => x.MFG == "STE").ToList();
            OreList = db.Parts.Where(x => x.MFG == "ORE").ToList();
        }
    }
}
