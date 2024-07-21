using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using SAS.Messages.Mod;
using System.Collections.Concurrent;

namespace SAS.Messages.RabbitMQ.Mod
{
    public class RabbitMQStation : Station
    {
        private IConnection connection { get; set; }
        private Map map { get; set; }
        private ConcurrentDictionary<Guid, string?> consumers { get; set; }

        public RabbitMQStation()
        {
            map = new Map(nameof(RabbitMQStation));
            consumers = new ConcurrentDictionary<Guid, string?>();

            ConnectionFactory factory = new ConnectionFactory();
            factory.UserName = "guest";
            factory.Password = "guest";
            factory.VirtualHost = "sas";
            factory.HostName = "localhost";

            factory.AutomaticRecoveryEnabled = true;
            factory.DispatchConsumersAsync = true;

            connection = factory.CreateConnection();
        }

        public override Task Connect(string channel)
        {
            if (!map.Has(channel))
            {
                IModel newChannel = connection.CreateModel();
                map.Add(channel, newChannel);
            }

            return Task.CompletedTask;
        }

        public override async Task<bool> Registry(Address address, Mailbox mailbox, CancellationToken ctok = default)
        {
            if (connection == null) return false;

            if (!map.Has(address.Channel))
            {
                await Connect(address.Channel);
            }

            var channel = map[address.Channel]!.Data as IModel;

            if (!string.IsNullOrEmpty(address.Exchange))
            {
                if (!map.Find(address.Channel, address.Exchange))
                {
                    channel.ExchangeDeclare(address.Exchange, address.ExchangeType, true, true);
                    map[address.Channel]!.Add(address.Exchange);
                }

                if (!string.IsNullOrEmpty(address.Queue))
                {
                    if (!map.Find(address.Channel, address.Exchange, address.Queue))
                    {
                        channel.QueueDeclare(address.Queue, true, true, true);
                        channel.QueueBind(address.Queue, address.Exchange, address.RoutingKey);

                        map[address.Channel]![address.Exchange]!.Add(address.Queue);
                    }

                    if (!consumers.ContainsKey(mailbox.Id))
                    {
                        var consumer = new AsyncEventingBasicConsumer(channel);
                        consumer.Received += (model, deliverMsg) =>
                        {
                            var message = new Message()
                            {
                                Id = deliverMsg.BasicProperties.MessageId,
                                CorrelationId = deliverMsg.BasicProperties.CorrelationId,
                                Priority = deliverMsg.BasicProperties.Priority,
                                UserId = deliverMsg.BasicProperties.UserId,
                                Type = deliverMsg.BasicProperties.Type,
                                Header = deliverMsg.BasicProperties.Headers,
                                Body = deliverMsg.Body.ToArray(),
                            };
                            return mailbox.Receive(message);
                        };
                        var consumerId = channel.BasicConsume(address.Queue, true, consumer);
                        consumers.TryAdd(mailbox.Id, consumerId);
                    }
                }
            }

            return true;
        }

        public override async Task<bool> Publish(Address address, Message message, CancellationToken ctok = default)
        {
            if (!address.ValidExchaneRouting)
            {
                return false;
            }

            if (!map.Has(address.Channel))
            {
                await Connect(address.Channel);
            }

            var channel = map[address.Channel]!.Data as IModel;
            var props = channel!.CreateBasicProperties();
            props.MessageId = message.Id;
            props.CorrelationId = message.CorrelationId;
            props.Priority = message.Priority;
            props.UserId = message.UserId;
            props.Type = message.Type;
            props.DeliveryMode = 2;
            props.Headers = message.Header;
            channel.BasicPublish(address.Exchange, address.RoutingKey, props, message.Body);

            return true;
        }
    }
}
