namespace SAS.Manage.Databases.Datatype
{
    public interface IEntity
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
