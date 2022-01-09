using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using PartKraken.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartKraken.Data.Factories
{
    internal class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var dataService = new DataService();
            var conString = dataService.GetConnectionString();
            var connStr = conString.ConnectionString;
            var options = new DbContextOptionsBuilder<AppDbContext>();

            options.UseNpgsql(connStr);

            return new AppDbContext(options.Options);
        }
    }
}
