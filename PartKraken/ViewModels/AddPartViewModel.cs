using PartKraken.Data.Factories;
using PartKraken.Navigation.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PartKraken.ViewModels
{
    internal class AddPartViewModel: BaseViewModel, IDisposable
    {
        private readonly AppDbContextFactory _dbFactory;
        public ICommand CloseCommand { get; set; }

        public AddPartViewModel(AppDbContextFactory dbFactory)
        {
            _dbFactory = dbFactory;
            CloseCommand = new RelayCommand(Dispose);
        }

        public void Dispose()
        {
            this.Dispose();
        }
    }
}
