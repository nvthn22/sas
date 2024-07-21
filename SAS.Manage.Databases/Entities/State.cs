using SAS.Manage.Databases.Datatype;

namespace SAS.Manage.Databases.Entities
{
    public class State : IEntity
    {
        public Guid Id { get; set; }
        public int ResultCount { get; set; }
        public string? Result1 { get; set; }
        public string? Result2 { get; set; }
        public string? Result3 { get; set; }
        public string? Result4 { get; set; }
        public string? Result5 { get; set; }
        public bool IsDeleted { get; set; }
    }
}
