using PartKraken.Interfaces;
using PartKraken.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartKraken.Navigation
{
    internal class Navigator
    {
        public event Action? CurrentViewModelChanged;

        private BaseViewModel? _currentViewModel;
        public BaseViewModel? CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }

        public void Navigate()
        {
            throw new NotImplementedException();
        }
    }
}
