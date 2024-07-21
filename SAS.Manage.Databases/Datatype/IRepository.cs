namespace SAS.Manage.Databases.Datatype
{
    public interface IRepository<T> where T : class, IEntity
    {
        public Task<IEnumerable<T>> Get(int skip, int take);
        public Task<T?> Find(Guid id);
        public Task<T?> Find(Predicate<T> predicate);
        public Task<IEnumerable<T>> FindAll(Predicate<T> predicate);
        public Task<T> Update(Guid id, T entity);
        public Task<T> Create(T entity);
        public Task<bool> Delete(Guid id);

        public Task<T?> this[Guid id] { get; }
    }
}
