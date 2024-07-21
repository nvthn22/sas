using Microsoft.Extensions.DependencyInjection;
using SAS.Messages.Abs;
using SAS.Messages.Mod;

namespace SAS.Agents.Service.Mailboxs
{
    internal class MService : Mailbox
    {
        private IServiceProvider services;

        public MService(IServiceProvider services)
        {
            this.services = services;
        }

        public override Task Receive(Message message)
        {
            var handler = services.GetKeyedService<IMessageHandler>(message.Type);
            if (handler != null)
            {
                return handler.Handle(message);
            }
            else
            {
                return Task.CompletedTask;
            }
        }
    }
}
