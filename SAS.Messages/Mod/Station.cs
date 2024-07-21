namespace SAS.Messages.Mod
{
    public abstract class Station
    {
        public abstract Task Connect(string channel);
        public abstract Task Registry(Address address, Mailbox mailbox, CancellationToken ctok = default);
        public abstract Task Publish(Address address, Message message, CancellationToken ctok = default);
    }
}
