using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SAS.Manage.Databases.Entities;
using SAS.Manage.Databases.Entities.Views;
using SAS.Manage.Databases.Mod;

namespace SAS.Manage.Databases.Postgresql
{
    public class PostgreDbContext : AppDbContext
    {
        public PostgreDbContext(IConfiguration configuration) : base(configuration)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("AppMessage");
            modelBuilder.Entity<Order>().ToTable("Orders").HasKey("Id");
            modelBuilder.Entity<Ordertype>().ToTable("Ordertypes").HasKey("Id");
            modelBuilder.Entity<State>().ToTable("States").HasKey("Id");
            modelBuilder.Entity<Status>().ToTable("Status").HasKey("Id");
            modelBuilder.Entity<Text>().ToTable("Texts").HasKey("Id");

            modelBuilder.Entity<ViewTypeTimeAnalyst>().ToView("ViewTypeTimeAnalysts").HasNoKey();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(configuration.GetConnectionString("PostgreDatabase"));
        }
    }
}
