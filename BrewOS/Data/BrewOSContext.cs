using BrewOS.Models.Beers;
using BrewOS.Models.Sensors.TemperatureSensors;
using BrewOS.Models.UserAccounts;
using BrewOS.Models.Vessels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrewOS.Data
{
    public class BrewOSContext : DbContext
    {
        //public DbSet<Beer>              Brews           { get; set; }
        //public DbSet<BeerStyle>         Styles          { get; set; }
        //public DbSet<User>              Accounts        { get; set; }
        //public DbSet<UserPermissions>   PermissionSets  { get; set; }
        public DbSet<TemperatureSensor> Sensors         { get; set; }

        //public DbSet<Fermenter>         Fermenters      { get; set; }
        //public DbSet<Dispenser>         Dispensers      { get; set; }

        public BrewOSContext(DbContextOptions<BrewOSContext> options) : base(options)
        {
            this.Database.EnsureCreated();

            

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder//.UseLazyLoadingProxies()
        //        .UseSqlite("Data Source=BrewOS.db");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            


            //modelBuilder.Entity<TemperatureSensor>()
            //    .HasOne(a => a.Sensor);//.WithOne>.WithOne(x => x.Address);
                
            //this.EnsureCreated();
            //modelBuilder.Entity<TemperatureSensor>().ToTable("TemperatureSensor");
            //modelBuilder.Entity<PhoneNumber>()
            //    .HasKey(c => new { c.AreaCode, c.Prefix, c.Extension });
        }

        //private static BrewOSContext _Instance = null;

        //public static BrewOSContext Instance
        //{
        //    get { return _Instance != null ? _Instance : CreateInstance(); }
        //}

        //private static BrewOSContext CreateInstance()
        //{
        //    return new BrewOSContext();
        //}

        public async Task<List<TemperatureSensor>> GetKnownSensors()
        {
            var sensors = await this.Sensors
                .ToListAsync();

            return sensors;
        }


    }
}
