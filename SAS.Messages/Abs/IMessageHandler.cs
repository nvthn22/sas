using SAS.Messages.Mod;

namespace SAS.Messages.Abs
{
    public interface IMessageHandler
    {
        public Task Handle(Message message);
    }
}
