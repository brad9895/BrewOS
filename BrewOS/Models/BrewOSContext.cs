using BrewOS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrewOS.Models
{
    public class BrewOSContext : DbContext
    {
        public DbSet<Beer> Brews { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=BrewOS.db");
            //optionsBuilder.UseSqlite("FileName=./BrewOS.db");
        }
    }
}
