namespace SAS.Public.Msg.Scheduler
{
    public class EventNewOrder
    {
        public Guid RelationId { get; set; }
        public int Priority { get; set; }
        public string? Typename { get; set; }
        public int ResultCount { get; set; }
        public string? State { get; set; }
        public DateTime? Date { get; set; }
    }
}
