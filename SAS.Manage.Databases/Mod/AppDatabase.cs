using Microsoft.Extensions.Configuration;
using SAS.Manage.Databases.Datatype;
using SAS.Manage.Databases.Entities.Views;
using StackExchange.Redis;

namespace SAS.Manage.Databases.Mod
{
    public abstract class AppDatabase
    {
        protected IConfiguration configuration;
        protected IConnectionMultiplexer cacheConnect;

        public AppDatabase()
        {
            configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("database.json")
                .Build();

            try
            {
                var endpoint = configuration.GetSection("Redis").GetValue<string>("ConnectionString")!;
                ConfigurationOptions cacheOptions = new ConfigurationOptions()
                {
                    EndPoints =
                    {
                        { endpoint }
                    },
                    AbortOnConnectFail = false,
                };

                cacheConnect = ConnectionMultiplexer.Connect(cacheOptions);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Redis exception" + ex.Message);
            }
        }

        public abstract Repository<Entities.Order> Orders { get; set; }
        public abstract Repository<Entities.State> States { get; set; }
        public abstract Repository<Entities.Status> Status { get; set; }
        public abstract Repository<Entities.Ordertype> Ordertypes { get; set; }
        public abstract Repository<Entities.Text> Texts { get; set; }

        public abstract IEnumerable<ViewTypeTimeAnalyst> ViewTypesTimeAnalysts { get; }

        public abstract void SaveChanged();
    }
}
