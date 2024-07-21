namespace SAS.Messages.Mod
{
    public class Message
    {
        public string? Id { get; set; }
        public string? CorrelationId { get; set; }
        public byte Priority { get; set; }
        public IDictionary<string, object>? Header { get; set; }
        public string? UserId { get; set; }
        public required string Type { get; set; }
        public byte[]? Body { get; set; }
    }
}
