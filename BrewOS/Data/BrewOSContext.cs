using BrewOS.Models.Beers;
using BrewOS.Models.UserAccounts;
using BrewOS.Models.Vessels;
using Microsoft.EntityFrameworkCore;

namespace BrewOS.Data
{
    public class BrewOSContext : DbContext
    {
        public DbSet<Beer>              Brews           { get; set; }
        public DbSet<BeerStyle>         Styles          { get; set; }
        public DbSet<User>              Accounts        { get; set; }
        public DbSet<UserPermissions>   PermissionSets  { get; set; }

        public DbSet<Fermenter>         Fermenters      { get; set; }
        public DbSet<Dispenser>         Dispensers      { get; set; }

        public BrewOSContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder//.UseLazyLoadingProxies()
                .UseSqlite("Data Source=BrewOS.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PhoneNumber>()
                .HasKey(c => new { c.AreaCode, c.Prefix, c.Extension });
        }

        private static BrewOSContext _Instance = null;

        public static BrewOSContext Instance
        {
            get { return _Instance != null ? _Instance : createInstance(); }
        }

        private static BrewOSContext createInstance()
        {
            return new BrewOSContext();
        }
    }
}
