using SAS.Manage.Databases.Datatype;

namespace SAS.Manage.Databases.Entities
{
    public class Order : IEntity
    {
        public Guid Id { get; set; }
        public Guid TypeId { get; set; }
        public int Priority { get; set; }
        public bool IsDeleted { get; set; }
    }
}
