using Microsoft.Extensions.DependencyInjection;
using SAS.Messages.Abs;
using SAS.Messages.Mod;

namespace SAS.Apps.Client.Mailboxs
{
    internal class MClient : Mailbox
    {
        private IServiceProvider services;

        public MClient(IServiceProvider services)
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
