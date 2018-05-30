using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BrewOS.Models.Vessels;

namespace BrewOS.Models
{
    public class FermenterContext : DbContext
    {
        public FermenterContext (DbContextOptions<FermenterContext> options)
            : base(options)
        {
        }

        public DbSet<BrewOS.Models.Vessels.Fermenter> Fermenter { get; set; }
    }
}
