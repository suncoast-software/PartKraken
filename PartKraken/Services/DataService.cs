using Newtonsoft.Json;
using PartKraken.Data.Configuration;
using PartKraken.Interfaces;
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
            var configFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Configuration", "config.json");
            using var fs = File.OpenRead(configFile);
            using var sr = new StreamReader(fs, new UTF8Encoding(false));
            var json = sr.ReadToEnd();

            var configJson = JsonConvert.DeserializeObject<ConfigJson>(json);

            return configJson;
        }
    }
}
