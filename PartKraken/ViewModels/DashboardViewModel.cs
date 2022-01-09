using PartKraken.Data.Factories;
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

        public DashboardViewModel(Navigator? navigator, AppDbContextFactory dbFactory)
        {
            _navigator = navigator;
            _dbFactory = dbFactory;
        }
    }
}
