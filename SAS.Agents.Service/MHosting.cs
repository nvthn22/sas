using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SAS.Agents.Service.Mailboxs;
using SAS.Agents.Service.Mod;
using SAS.Messages.RabbitMQ.Mod;

namespace SAS.Agents.Service
{
    internal class MHosting
    {
        public static async Task Main(string[] args)
        {
            var builder = Host.CreateDefaultBuilder();

            builder.ConfigureServices((hostContext, services) =>
            {
                services.AddSingleton<Connector>();
                services.AddSingleton<MService>();
                services.AddSingleton<RabbitMQStation>();

            });

            var host = builder.Build();

            var connector = host.Services.GetRequiredService<Connector>();
            await connector.Connect();

            await host.RunAsync();
        }
    }
}
