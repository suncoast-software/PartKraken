using Microsoft.EntityFrameworkCore;
using PartKraken.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartKraken.Data
{
    internal class AppDbContext: DbContext
    {
        public DbSet<Part> Parts { get; set; }
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
