using PartKraken.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartKraken.Interfaces
{
    internal interface INavigationService<TViewModel> where TViewModel : BaseViewModel
    {
        void Navigate();
    }
}
