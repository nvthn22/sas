using SAS.Messages.Mod;
using SAS.Public.Def.Convert;
using System.Diagnostics;
using ZTests.SAS.Public.Model_Value;

namespace ZTests.SAS.Mailboxs_Template
{
    public class MailboxRead : Mailbox
    {
        public override Task Receive(Message message)
        {
            var temp = DataConvert.Instance.ToClass<MembersValue>(message.Body);
            Console.WriteLine("Receive a messge type: " + message.Type);
            return Task.CompletedTask;
        }
    }
}
