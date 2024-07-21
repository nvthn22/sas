using Microsoft.Extensions.DependencyInjection;
using SAS.Manage.Supervisor.Mailboxs;
using SAS.Messages.Mod;
using SAS.Messages.RabbitMQ.Mod;

namespace SAS.Manage.Supervisor.Mod
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

            await station.Registry(new Address()
            {
                Channel = "Manage",
                Exchange = "Manage_Exchange",
                ExchangeType = "topic",
                Queue = "Supervisor_Queue",
                RoutingKey = "*.supervisor",
            }, manage);

        }
    }
}
