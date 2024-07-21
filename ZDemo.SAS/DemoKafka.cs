using SAS.Messages.Kafka.Mod;
using SAS.Messages.Mod;
using SAS.Public.Def.Convert;
using ZTests.SAS.Mailboxs_Template;
using ZTests.SAS.Public.Model_Template;

namespace ZDemo.SAS
{
    public class DemoKafka
    {
        public static async Task Run()
        {
            var data = MembersTemplate.MembersValueRandom;
            var bytes = DataConvert.Instance.ToBytes(data);

            var station = new KafkaStation();

            var cts = new CancellationTokenSource();
            var address = new Address() { Channel = "app-1", Queue = "topic-1" };
            var registTask = Task.Factory.StartNew(() => station.Registry(address, new MailboxRead(), cts.Token));

            Console.Write("Press a key, esc to quit");
            while (true)
            {
                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.Escape) break;

                await station.Publish(address, new Message()
                {
                    Id = Guid.NewGuid().ToString(),
                    Type = "type-1",
                    Body = bytes,
                }).ConfigureAwait(false);
            }

            cts.Cancel();
            Task.WaitAll(registTask);
        }
    }
}