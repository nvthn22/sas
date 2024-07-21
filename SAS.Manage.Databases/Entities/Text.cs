using SAS.Manage.Databases.Datatype;

namespace SAS.Manage.Databases.Entities
{
    public class Text : IEntity
    {
        public Guid Id { get; set; }
        public string? Message { get; set; }
        public bool IsDeleted { get; set; }
    }
}
