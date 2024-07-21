namespace SAS.Messages.Mod
{
    public abstract class Mailbox
    {
        public Guid Id { get; set; }
        public abstract Task Receive(Message message);
    }
}
