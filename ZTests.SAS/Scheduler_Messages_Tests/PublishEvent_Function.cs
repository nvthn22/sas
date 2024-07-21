using SAS.Messages.Mod;
using SAS.Messages.RabbitMQ.Mod;
using SAS.Public.Def.Convert;
using SAS.Public.Def.Data;
using SAS.Public.Msg.Scheduler;

namespace ZTests.SAS.Scheduler_Messages_Tests
{
    [TestClass]
    public class PublishEvent_Function
    {
        //[TestMethod]
        public async Task Publish_eventAsync()
        {
            Assert.Fail();

            var station = new RabbitMQStation();

            var newOrder = new EventNewOrder();
            DataRandom.Instance.FillMembersRandom(newOrder);
            var newOrderBytes = DataConvert.Instance.ToBytes(newOrder);

            await station.Connect("Scheduler_App");

            await station.Publish(new Address()
            {
                Channel = "Scheduler_App",
                Exchange = "Scheduler_App_Exchange",
                RoutingKey = "app.scheduler",
            }, new Message()
            {
                Type = "new.order",
                Body = newOrderBytes,
            });
        }
    }
}
