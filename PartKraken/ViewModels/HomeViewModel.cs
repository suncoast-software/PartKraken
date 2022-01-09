using PartKraken.Data.Factories;
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

        public HomeViewModel(AppDbContextFactory dbFactory, Navigator? navigator)
        {
            _navigator = navigator;
            _dbFactory = dbFactory;
        }
    }
}
