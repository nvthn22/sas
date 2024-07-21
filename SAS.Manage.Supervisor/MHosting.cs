using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SAS.Manage.Databases.Mod;
using SAS.Manage.Databases.Postgresql;
using SAS.Manage.Scheduler.Handler;
using SAS.Manage.Supervisor.Mailboxs;
using SAS.Manage.Supervisor.Mod;
using SAS.Messages.Abs;
using SAS.Messages.Mod;
using SAS.Messages.RabbitMQ.Mod;

namespace SAS.Manage.Scheduler
{
    internal class MHosting
    {
        public static void Main(string[] args)
        {
            var builder = Host.CreateDefaultBuilder();

            builder.ConfigureServices((hostContext, services) =>
            {
                services.AddSingleton<Connector>();
                services.AddSingleton<MManage>();
                services.AddSingleton<Station, RabbitMQStation>();
                services.AddSingleton<AppDatabase, PostgreDatabase>();

                services.AddKeyedScoped<IMessageHandler, FinishOrderHandler>("finish.order");
            });

            var host = builder.Build();

            var connector = host.Services.GetRequiredService<Connector>();
            var connectTask = connector.Connect();

            var app = host.RunAsync();

            Task.WaitAll(connectTask, app);
        }
    }
}
