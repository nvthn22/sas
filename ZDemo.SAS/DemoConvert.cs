using Newtonsoft.Json;
using SAS.Public.Def.Convert;
using SAS.Public.Def.Data;
using System.Text.Json;

namespace ZDemo.SAS
{
    public class DemoConvert
    {
        public static void Run()
        {
            var data = new Data();
            
            var bytesFromEmptyData = DataConvert.Instance.ToBytes(data);
            var dataEmptyReverse = DataConvert.Instance.ToClass<Data>(bytesFromEmptyData);

            var dataJson = JsonConvert.SerializeObject(data);
            var dataReverseJson = JsonConvert.SerializeObject(dataEmptyReverse);

            Console.WriteLine($"Length of {nameof(bytesFromEmptyData)}: {bytesFromEmptyData.Length}");
            Console.WriteLine($"Same data: {string.Equals(dataJson, dataReverseJson)}");

            Console.WriteLine("==============");

            var dataRandom = new Data();
            DataRandom.Instance.FillMembersRandom(dataRandom);

            var bytesFromRandomData = DataConvert.Instance.ToBytes(dataRandom);
            var dataRandomReverse = DataConvert.Instance.ToClass<Data>(bytesFromRandomData);

            var dataRandomJson = JsonConvert.SerializeObject(dataRandom);
            var dataRandomRevertJson = JsonConvert.SerializeObject(dataRandomReverse);

            Console.WriteLine($"Length of {nameof(bytesFromRandomData)}: {bytesFromRandomData.Length}");
            Console.WriteLine($"Same data random: {string.Equals(dataRandomJson, dataRandomRevertJson)}");

            Console.WriteLine();
        }

        private class Data
        {
            public Guid? Id;
            public string? Name;
            public string? Type;
            public string? Description;
        }
    }
}
