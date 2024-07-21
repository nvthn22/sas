using Microsoft.EntityFrameworkCore;
using SAS.Public.Def.Convert.v2;
using StackExchange.Redis;

namespace SAS.Manage.Databases.Datatype
{
    public abstract class Repository<T> : IRepository<T> where T : class, IEntity, new()
    {
        protected IConnectionMultiplexer cacheConnection;
        protected IDatabase cache;
        protected DbContext dbContext;

        public Repository(IConnectionMultiplexer cacheConnection, DbContext dbContext)
        {
            this.dbContext = dbContext;
            this.cacheConnection = cacheConnection;

            cache = this.cacheConnection.GetDatabase();
        }

        public Task<T?> this[Guid id] => Find(id);

        public async Task<T> Create(T entity)
        {
            await cache.StringSetAsync(entity.Id.ToByteArray(), DataNullableConvert.Instance.ToBytes(entity), TimeSpan.FromMinutes(1)).ConfigureAwait(false);

            await dbContext.Set<T>().AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Delete(Guid id)
        {
            if (cache.KeyExists(id.ToByteArray()))
            {
                await cache.KeyDeleteAsync(id.ToByteArray()).ConfigureAwait(false);
            }

            var item = await dbContext.Set<T>().FindAsync(id);
            if (item != null)
            {
                item.IsDeleted = true;
                await dbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<T?> Find(Guid id)
        {
            if (cache.KeyExists(id.ToByteArray()))
            {
                var cachedString = await cache.StringGetAsync(id.ToByteArray());
                var cachedItem = DataNullableConvert.Instance.ToClass<T>(cachedString!);
                return cachedItem;
            }
            else
            {
                var item = await dbContext.Set<T>().FindAsync(id);
                if (item != null)
                {
                    await cache.StringSetAsync(item.Id.ToByteArray(), DataNullableConvert.Instance.ToBytes(item)).ConfigureAwait(false);
                }
                return item;
            }
        }

        public async Task<T?> Find(Predicate<T> predicate)
        {
            var cachedKey = "find_predicate_" + predicate.GetHashCode();
            if (cache.KeyExists(cachedKey))
            {
                var cachedId = await cache.StringGetAsync(cachedKey);
                if (cache.KeyExists((byte[]?)cachedId))
                {
                    var cachedString = await cache.StringGetAsync((byte[]?)cachedId);
                    var cachedItem = DataNullableConvert.Instance.ToClass<T>(cachedString!);
                    return cachedItem;
                }
                else
                {
                    await cache.KeyDeleteAsync(cachedKey).ConfigureAwait(false);
                }
            }

            var item = await dbContext.Set<T>().FirstOrDefaultAsync(record => predicate(record));
            if (item != null)
            {
                await cache.StringSetAsync(cachedKey, item.Id.ToByteArray()).ConfigureAwait(false);
                await cache.StringSetAsync(item.Id.ToByteArray(), DataNullableConvert.Instance.ToBytes(item)).ConfigureAwait(false);
            }
            return item;
        }

        public Task<IEnumerable<T>> FindAll(Predicate<T> predicate)
        {
            var items = dbContext.Set<T>().Where(record => predicate(record)).AsNoTracking().AsEnumerable();
            return Task.FromResult(items);
        }

        public Task<IEnumerable<T>> Get(int skip, int take)
        {
            var items = dbContext.Set<T>().Skip(skip).Take(take).AsNoTracking().AsEnumerable();
            return Task.FromResult(items);
        }

        public async Task<T> Update(Guid id, T entity)
        {
            await cache.StringSetAsync(entity.Id.ToByteArray(), DataNullableConvert.Instance.ToBytes(entity), TimeSpan.FromMinutes(1)).ConfigureAwait(false);

            dbContext.Set<T>().Update(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
