using SAS.Manage.Databases.Entities;
using SAS.Manage.Databases.Mod;
using SAS.Messages.Abs;
using SAS.Messages.Mod;
using SAS.Public.Def.Convert.v2;
using SAS.Public.Msg.Common;

namespace SAS.Manage.Scheduler.Handler
{
    internal class TextHandler : IMessageHandler
    {
        private AppDatabase MDatabase;
        public TextHandler(AppDatabase appDatabase)
        {
            MDatabase = appDatabase;
        }

        public async Task Handle(Message message)
        {
            if (message.Body == null)
            {
                return;
            }

            var text = DataNullableConvert.Instance.ToClass<EventText>(message.Body);
            var textEntity = new Text()
            {
                Id = Guid.NewGuid(),
                Message = text?.Message,
                IsDeleted = false,
            };
            await MDatabase.Texts.Create(textEntity);
            MDatabase.SaveChanged();

            Console.WriteLine("Scheduler receive message: " + text?.Message);
            var histories = await MDatabase.Texts.Get(0, 5);
            foreach (var item in histories)
            {
                Console.WriteLine($"- {item.Id} {item.Message}");
            }
        }
    }
}
