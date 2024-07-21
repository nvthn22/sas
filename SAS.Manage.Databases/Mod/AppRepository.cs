using Microsoft.EntityFrameworkCore;
using SAS.Manage.Databases.Datatype;
using StackExchange.Redis;

namespace SAS.Manage.Databases.Mod
{
    public class AppRepository<T> : Repository<T> where T : class, IEntity, new()
    {
        public AppRepository(IConnectionMultiplexer cache, DbContext dbContext) : base(cache, dbContext)
        {
        }
    }
}
