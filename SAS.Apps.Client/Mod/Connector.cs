using Microsoft.Extensions.DependencyInjection;
using SAS.Apps.Client.Mailboxs;
using SAS.Messages.Mod;

namespace SAS.Apps.Client.Mod
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
            var client = services.GetRequiredService<MClient>();

            await station.Registry(new Address()
            {
                Channel = "Apps",
                Exchange = "Apps_Exchange",
                ExchangeType = "topic",
                Queue = "Client_Queue",
                RoutingKey = "*.client",
            }, client);

        }
    }
}
