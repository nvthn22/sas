using SAS.Manage.Databases.Datatype;

namespace SAS.Manage.Databases.Entities
{
    public class Ordertype : IEntity
    {
        public Guid Id { get; set; }
        public string? Typename { get; set; }
        public int SampleTypecount { get; set; }
        public int SampleAvgTimeInMinisecond { get; set; }
        public bool IsDeleted { get; set; }
    }
}
