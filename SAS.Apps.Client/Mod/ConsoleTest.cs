using Microsoft.Extensions.DependencyInjection;
using SAS.Messages.Mod;
using SAS.Public.Def.Convert.v2;
using SAS.Public.Msg.Common;

namespace SAS.Apps.Client.Mod
{
    internal class ConsoleTest
    {
        private IServiceProvider services;
        public ConsoleTest(IServiceProvider services)
        {
            this.services = services;
        }

        public Task Run()
        {
            var station = services.GetRequiredService<Station>();
            var address = new Address()
            {
                Channel = "Scheduler",
                Exchange = "Scheduler_Exchange",
                ExchangeType = "topic",
                Queue = "Scheduler_Queue",
                RoutingKey = "*.scheduler",
            };

            string? text;
            while (true)
            {
                Console.Write("Client message: ");
                text = Console.ReadLine();
                var data = new EventText() { Message = text };
                var message = new Message()
                {
                    Type = "text",
                    Body = DataNullableConvert.Instance.ToBytes(data),
                };
                station.Publish(address, message);
            }
        }
    }
}
