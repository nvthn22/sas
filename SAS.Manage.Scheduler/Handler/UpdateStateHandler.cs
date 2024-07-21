using Microsoft.Extensions.DependencyInjection;
using SAS.Manage.Databases.Mod;
using SAS.Messages.Abs;
using SAS.Messages.Mod;
using SAS.Public.Def.Convert;
using SAS.Public.Def.Convert.v2;
using SAS.Public.Msg.Scheduler;
using SAS.Public.Msg.Supervisor;

namespace SAS.Manage.Scheduler.Handler
{
    internal class UpdateStateHandler : IMessageHandler
    {
        private IServiceProvider services;
        private AppDatabase MDatabase;
        public UpdateStateHandler(IServiceProvider services, AppDatabase MDatabase)
        {
            this.services = services;
            this.MDatabase = MDatabase;
        }

        public async Task Handle(Message message)
        {
            if (message.Body == null)
            {
                return;
            }

            var updateState = DataConvert.Instance.ToClass<EventUpdateState>(message.Body);

            var stateEntity = await MDatabase.States[updateState.RelationId];
            if (stateEntity != null)
            {
                switch (updateState.Index)
                {
                    case 1: stateEntity.Result1 = updateState.State; break;
                    case 2: stateEntity.Result2 = updateState.State; break;
                    case 3: stateEntity.Result3 = updateState.State; break;
                    case 4: stateEntity.Result4 = updateState.State; break;
                    case 5: stateEntity.Result5 = updateState.State; break;
                }

                if (updateState.Index is >= 1 and <= 5)
                {
                    var status = await MDatabase.Status[stateEntity.Id];
                    status.TimeUpdated = DateTime.Now;

                    var filled = false;
                    switch (stateEntity.ResultCount)
                    {
                        case 1:
                            filled = !string.IsNullOrEmpty(stateEntity.Result1);
                            break;

                        case 2:
                            filled = !string.IsNullOrEmpty(stateEntity.Result1) &&
                                !string.IsNullOrEmpty(stateEntity.Result2);
                            break;

                        case 3:
                            filled = !string.IsNullOrEmpty(stateEntity.Result1) &&
                                !string.IsNullOrEmpty(stateEntity.Result2) &&
                                !string.IsNullOrEmpty(stateEntity.Result3);
                            break;

                        case 4:
                            filled = !string.IsNullOrEmpty(stateEntity.Result1) &&
                                !string.IsNullOrEmpty(stateEntity.Result2) &&
                                !string.IsNullOrEmpty(stateEntity.Result3) &&
                                !string.IsNullOrEmpty(stateEntity.Result4);
                            break;

                        case 5:
                            filled = !string.IsNullOrEmpty(stateEntity.Result1) &&
                                !string.IsNullOrEmpty(stateEntity.Result2) &&
                                !string.IsNullOrEmpty(stateEntity.Result3) &&
                                !string.IsNullOrEmpty(stateEntity.Result4) &&
                                !string.IsNullOrEmpty(stateEntity.Result5);
                            break;
                    }

                    if (filled)
                    {
                        status.Filled = true;
                        var station = services.GetRequiredService<Station>();
                        var address = new Address()
                        {
                            Channel = "Manage",
                            Exchange = "Manage_Exchange",
                            ExchangeType = "topic",
                            Queue = "Scheduler_Queue",
                            RoutingKey = "*.supervisor",
                        };
                        var finishOrderEvent = new EventFinishOrder() { RelationId = stateEntity.Id };
                        var body = DataNullableConvert.Instance.ToBytes(finishOrderEvent);
                        await station.Publish(address, new Message()
                        {
                            Type = "finish.order",
                            Body = body,
                        }).ConfigureAwait(false);
                    }

                    await MDatabase.Status.Update(status.Id, status);
                }

                MDatabase.SaveChanged();
            }
        }
    }
}
