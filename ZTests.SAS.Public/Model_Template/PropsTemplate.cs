using SAS.Public.Def.Data;
using ZTests.SAS.Public.Model_Value;

namespace ZTests.SAS.Public.Model_Template
{
    public class PropsTemplate
    {
        public static PropsValue PropsValueRandom => new PropsValue()
        {
            mbool = DataRandom.Instance.RandomBoolean(),
            mbyte = DataRandom.Instance.RandomByte(),
            msbyte = DataRandom.Instance.RandomSByte(),
            mchar = DataRandom.Instance.RandomChar(),
            mdecimal = DataRandom.Instance.RandomDecimal(),
            mdouble = DataRandom.Instance.RandomDouble(),
            mfloat = DataRandom.Instance.RandomSingle(),
            mint = DataRandom.Instance.RandomInt32(),
            mlong = DataRandom.Instance.RandomInt64(),
            mshort = DataRandom.Instance.RandomInt16(),
            mushort = DataRandom.Instance.RandomUInt16(),

            mstring = DataRandom.Instance.RandomString(),
            mguid = DataRandom.Instance.RandomGuid(),
            mdatetime = DataRandom.Instance.RandomDateTime(),
        };
    }
}
