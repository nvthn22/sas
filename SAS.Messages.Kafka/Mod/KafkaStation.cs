using Confluent.Kafka;
using SAS.Messages.Mod;
using System.Collections.Concurrent;

namespace SAS.Messages.Kafka.Mod
{
    public class KafkaStation : Station, IDisposable
    {
        private ClientConfig config;
        private ConcurrentDictionary<string, IProducer<string, byte[]?>> producers;

        public KafkaStation()
        {
            producers = new ConcurrentDictionary<string, IProducer<string, byte[]?>>();

            config = new ClientConfig();
            config.BootstrapServers = "localhost:9092";
            //clientConfig.SecurityProtocol = Confluent.Kafka.SecurityProtocol.SaslSsl;
            //clientConfig.SaslMechanism = Confluent.Kafka.SaslMechanism.Plain;
            //clientConfig.SaslUsername = "<api-key>";
            //clientConfig.SaslPassword = "<api-secret>";
            //clientConfig.SslCaLocation = "probe"; // /etc/ssl/certs
        }

        public override Task Connect(string channel)
        {
            var producer = new ProducerBuilder<string, byte[]?>(config).Build();
            producers.TryAdd(channel, producer);
            return Task.CompletedTask;
        }

        public override Task Publish(Address address, Message message, CancellationToken ctok = default)
        {
            if (!producers.ContainsKey(address.Channel))
            {
                Connect(address.Channel);
            }

            var producer = producers[address.Channel];
            producer.Produce(address.Queue, new Message<string, byte[]?>()
            {
                Key = message.Type + message.Priority + message.Id,
                Value = message.Body,
            }, report =>
            {
                if (report.Error.Code != ErrorCode.NoError)
                {
                    Console.WriteLine("Error with reason: " + report.Error.Reason);
                }
            });

            return Task.CompletedTask;
        }

        public override Task Registry(Address address, Mailbox mailbox, CancellationToken ctok = default)
        {
            var consumerConfig = new ConsumerConfig(config);
            consumerConfig.GroupId = address.Channel;
            consumerConfig.AutoOffsetReset = AutoOffsetReset.Earliest;
            consumerConfig.EnableAutoCommit = true;

            var cts = new CancellationTokenSource();
            ctok.Register(cts.Cancel);

            using (var consumer = new ConsumerBuilder<string, byte[]?>(consumerConfig).Build())
            {
                consumer.Subscribe(address.Queue);
                try
                {
                    while (!ctok.IsCancellationRequested)
                    {
                        var result = consumer.Consume(cts.Token);
                        var message = new Message()
                        {
                            Type = result.Message.Key,
                            Body = result.Message.Value,
                        };

                        mailbox.Receive(message);
                    }
                }
                catch (Exception) { }
                finally
                {
                    consumer.Close();
                }
            }
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            Parallel.ForEach(producers, pair =>
            {
                var remaining = pair.Value.Flush(TimeSpan.FromSeconds(5));
                if (remaining > 0)
                {
                    Console.WriteLine($"Remaining {remaining} items in queue {pair.Key}");
                }
            });
        }

    }
}
