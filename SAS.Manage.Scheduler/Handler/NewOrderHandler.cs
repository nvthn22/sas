using SAS.Manage.Databases.Entities;
using SAS.Manage.Databases.Mod;
using SAS.Manage.Databases.Postgresql;
using SAS.Messages.Abs;
using SAS.Messages.Mod;
using SAS.Public.Def.Convert;
using SAS.Public.Msg.Scheduler;

namespace SAS.Manage.Scheduler.Handler
{
    internal class NewOrderHandler : IMessageHandler
    {
        private AppDatabase MDatabase { get; set; }
        public NewOrderHandler(AppDatabase MDatabase)
        {
            this.MDatabase = MDatabase;
        }

        public async Task Handle(Message message)
        {
            if (message.Body == null)
            {
                return;
            }

            var eventNewOrder = DataConvert.Instance.ToClass<EventNewOrder>(message.Body);

            var type = await MDatabase.Ordertypes.Find(record => record.Typename == eventNewOrder.Typename);
            if (type == null)
            {
                var newOrdertype = new Ordertype()
                {
                    Id = Guid.NewGuid(),
                    Typename = eventNewOrder.Typename,
                };
                await MDatabase.Ordertypes.Create(newOrdertype);
                type = newOrdertype;
            }

            var newOrder = new Order()
            {
                Id = eventNewOrder.RelationId,
                TypeId = type.Id,
                Priority = eventNewOrder.Priority,
            };
            await MDatabase.Orders.Create(newOrder);

            var newState = new State()
            {
                Id = eventNewOrder.RelationId,
                ResultCount = eventNewOrder.ResultCount,
            };
            await MDatabase.States.Create(newState);

            var newStatus = new Status()
            {
                Id = eventNewOrder.RelationId,
                TimeCreated = DateTime.Now,
                TimeUpdated = DateTime.Now,
            };
            await MDatabase.Status.Create(newStatus);

            MDatabase.SaveChanged();
        }
    }
}
