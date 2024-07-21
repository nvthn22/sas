namespace SAS.Messages.Mod
{
    public class Address
    {
        public required string Channel { get; set; }
        public string? Exchange { get; set; }
        public string? ExchangeType { get; set; }
        public string? Queue { get; set; }
        public string RoutingKey { get; set; } = string.Empty;

        public virtual bool ValidExchaneRouting => Exchange != null && RoutingKey != null;
    }
}
