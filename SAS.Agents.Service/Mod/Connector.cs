using Microsoft.Extensions.DependencyInjection;
using SAS.Agents.Service.Mailboxs;
using SAS.Messages.Mod;
using SAS.Messages.RabbitMQ.Mod;

namespace SAS.Agents.Service.Mod
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
            var station = services.GetRequiredService<RabbitMQStation>();
            var service = services.GetRequiredService<MService>();

            await station.Registry(new Address()
            {
                Channel = "Agents",
                Exchange = "Agents_Exchange",
                ExchangeType = "topic",
                Queue = "Service_Queue",
                RoutingKey = "*.service",
            }, service);

        }
    }
}
