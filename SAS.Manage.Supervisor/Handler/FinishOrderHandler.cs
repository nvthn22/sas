using SAS.Manage.Databases.Mod;
using SAS.Messages.Abs;
using SAS.Messages.Mod;
using SAS.Public.Def.Convert.v2;
using SAS.Public.Msg.Supervisor;

namespace SAS.Manage.Scheduler.Handler
{
    internal class FinishOrderHandler : IMessageHandler
    {
        private IServiceProvider services;
        private AppDatabase MDatabases;
        public FinishOrderHandler(IServiceProvider services, AppDatabase MDatabase)
        {
            this.services = services;
            this.MDatabases = MDatabase;
        }

        public async Task Handle(Message message)
        {
            if (message.Body == null)
            {
                return;
            }

            var finishOrderEvent = DataNullableConvert.Instance.ToClass<EventFinishOrder>(message.Body);
            var status = await MDatabases.Status[finishOrderEvent!.RelationId];
            if (status != null)
            {
                status.Completed = true;
            }
            MDatabases.SaveChanged();
        }
    }
}
