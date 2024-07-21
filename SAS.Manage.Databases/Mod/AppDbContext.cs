using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SAS.Manage.Databases.Entities;
using SAS.Manage.Databases.Entities.Views;

namespace SAS.Manage.Databases.Mod
{
    public abstract class AppDbContext : DbContext
    {
        protected IConfiguration configuration;
        public AppDbContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Ordertype> Ordertypes { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Text> Texts { get; set; }
        public DbSet<ViewTypeTimeAnalyst> ViewTypeTimeAnalysts { get; set; }
    }
}
