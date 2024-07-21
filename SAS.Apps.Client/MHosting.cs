using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SAS.Apps.Client.Mailboxs;
using SAS.Apps.Client.Mod;
using SAS.Messages.Mod;
using SAS.Messages.RabbitMQ.Mod;

namespace SAS.Apps.Client.Scheduler
{
    internal class MHosting
    {
        public static void Main(string[] args)
        {
            var builder = Host.CreateDefaultBuilder();

            builder.ConfigureServices((hostContext, services) =>
            {
                services.AddSingleton<Connector>();
                services.AddSingleton<MClient>();
                services.AddSingleton<Station, RabbitMQStation>();
                services.AddSingleton<ConsoleTest>();

            });

            var host = builder.Build();

            var connector = host.Services.GetRequiredService<Connector>();
            var taskConnect = connector.Connect();

            var consoleTest = host.Services.GetRequiredService<ConsoleTest>();
            var taskConsole = consoleTest.Run();

            var app = host.RunAsync();

            Task.WaitAll(taskConnect, taskConsole, app);
        }
    }
}
