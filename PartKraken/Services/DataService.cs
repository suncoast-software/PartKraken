using Newtonsoft.Json;
using PartKraken.Data.Configuration;
using PartKraken.Data.Factories;
using PartKraken.Interfaces;
using PartKraken.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartKraken.Services
{
    internal class DataService : IDataService
    {
        public ConfigJson GetConnectionString()
        {
            var configFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "Configuration", "config.json");
            using var fs = File.OpenRead(configFile);
            using var sr = new StreamReader(fs, new UTF8Encoding(false));
            var json = sr.ReadToEnd();

            var configJson = JsonConvert.DeserializeObject<ConfigJson>(json);

            return configJson;
        }

        public List<List<Part>>LoadPartList(AppDbContextFactory dbFactory)
        {
            List<Part> CubList = new List<Part>();
            List<Part> SteList = new List<Part>();
            List<Part> OreList = new List<Part>();
            List<List<Part>> Parts = new List<List<Part>>();
            var db= dbFactory.CreateDbContext();
            CubList = db.Parts.Where(x => x.MFG == "CUB").ToList();
            OreList = db.Parts.Where(x => x.MFG == "ORE").ToList();
            SteList = db.Parts.Where(x => x.MFG == "STE").ToList();
            Parts.Add(CubList);
            Parts.Add(OreList);
            Parts.Add(SteList);
            return Parts;
        }
    }
}
