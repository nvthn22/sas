using Microsoft.EntityFrameworkCore.Internal;
using SAS.Manage.Databases.Datatype;
using SAS.Manage.Databases.Entities.Views;
using SAS.Manage.Databases.Mod;

namespace SAS.Manage.Databases.Postgresql
{
    public class PostgreDatabase : AppDatabase
    {
        protected AppDbContext AppDbContext;
        public PostgreDatabase()
        {
            AppDbContext = new PostgreDbContext(configuration);

            Orders = new AppRepository<Entities.Order>(cacheConnect, AppDbContext);
            States = new AppRepository<Entities.State>(cacheConnect, AppDbContext);
            Status = new AppRepository<Entities.Status>(cacheConnect, AppDbContext);
            Ordertypes = new AppRepository<Entities.Ordertype>(cacheConnect, AppDbContext);
            Texts = new AppRepository<Entities.Text>(cacheConnect, AppDbContext);
        }

        public override void SaveChanged()
        {
            AppDbContext.SaveChanges();
        }

        public override Repository<Entities.Order> Orders { get; set; }
        public override Repository<Entities.State> States { get; set; }
        public override Repository<Entities.Status> Status { get; set; }
        public override Repository<Entities.Ordertype> Ordertypes { get; set; }
        public override Repository<Entities.Text> Texts { get; set; }

        // Views
        public override IEnumerable<ViewTypeTimeAnalyst> ViewTypesTimeAnalysts
        {
            get
            {
                var oders = AppDbContext.Orders;
                var status = AppDbContext.Status.Where(record => record.Completed);

                return status.LeftJoin(oders,
                    status => status.Id, order => order.Id,
                    (statusRecord, orderRecord) => new ViewTypeTimeAnalyst()
                    {
                        TypeId = orderRecord.TypeId,
                        TimeCreated = statusRecord.TimeCreated,
                        TimeUpdated = statusRecord.TimeUpdated,
                    }).AsEnumerable();
            }
        }
        // End Views
    }
}
