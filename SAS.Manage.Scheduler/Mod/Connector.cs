using Microsoft.Extensions.DependencyInjection;
using SAS.Manage.Scheduler.Mailboxs;
using SAS.Messages.Mod;
using SAS.Messages.RabbitMQ.Mod;

namespace SAS.Manage.Scheduler.Mod
{
    internal class Connector
    {
        private IServiceProvider services { get; set; }

        public Connector(IServiceProvider services)
        {
            this.services = services;
        }

        public async Task Connect()
        {
            var station = services.GetRequiredService<Station>();
            var manage = services.GetRequiredService<MManage>();
            var scheduler = services.GetRequiredService<MScheduler>();

            await station.Registry(new Address()
            {
                Channel = "Manage",
                Exchange = "Manage_Exchange",
                ExchangeType = "topic",
                Queue = "Scheduler_Queue",
                RoutingKey = "*.scheduler",
            }, manage);

            await station.Registry(new Address()
            {
                Channel = "Scheduler",
                Exchange = "Scheduler_Exchange",
                ExchangeType = "topic",
                Queue = "Scheduler_Queue",
                RoutingKey = "*.scheduler",
            }, scheduler);

        }
    }
}
