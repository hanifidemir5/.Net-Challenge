using KargoApp.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace KargoApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Carriers> Carriers { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<CarrierConfigurations> CarrierConfigurations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Orders>(p =>
            {
                p.HasKey("OrderId");
            }); 
            modelBuilder.Entity<Carriers>(p =>
            {
                p.HasKey("CarrierId");
            });
            modelBuilder.Entity<CarrierConfigurations>(p =>
            {
                p.HasKey("CarrierConfigurationId");
            });
        }
    }
}
