using SAS.Manage.Databases.Datatype;

namespace SAS.Manage.Databases.Entities
{
    public class Status : IEntity
    {
        public Guid Id { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeUpdated { get; set; }
        public DateTime TimeFinished { get; set; }
        public bool Filled { get; set; }
        public bool Completed { get; set; }
        public bool Canceled { get; set; }
        public int ScanCount { get; set; }
        public bool IsDeleted { get; set; }
    }
}
