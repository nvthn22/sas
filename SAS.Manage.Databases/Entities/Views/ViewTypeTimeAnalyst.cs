using SAS.Manage.Databases.Datatype;

namespace SAS.Manage.Databases.Entities.Views
{
    public class ViewTypeTimeAnalyst : IView
    {
        public Guid TypeId { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeUpdated { get; set; }
    }
}
