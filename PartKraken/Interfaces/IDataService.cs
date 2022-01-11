using PartKraken.Data.Configuration;
using PartKraken.Data.Factories;
using PartKraken.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartKraken.Interfaces
{
    internal interface IDataService
    {
        public ConfigJson GetConnectionString();
        List<List<Part>> LoadPartList(AppDbContextFactory dbFactory);
    }
}
