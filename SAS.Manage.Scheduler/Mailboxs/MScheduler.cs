using Microsoft.Extensions.DependencyInjection;
using SAS.Messages.Abs;
using SAS.Messages.Mod;

namespace SAS.Manage.Scheduler.Mailboxs
{
    internal class MScheduler : Mailbox
    {
        private IServiceProvider services;

        public MScheduler(IServiceProvider services)
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
