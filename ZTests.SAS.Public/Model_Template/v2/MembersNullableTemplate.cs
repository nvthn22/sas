using SAS.Public.Def.Data;
using ZTests.SAS.Public.Model_Value.v2;

namespace ZTests.SAS.Public.Model_Template.v2
{
    public class MembersNullableTemplate
    {
        public static MembersNullableValue MembersNullableValueNull = new MembersNullableValue()
        {
            mbool = null,
            mbyte = null,
            msbyte = null,
            mchar = null,
            mdecimal = null,
            mdouble = null,
            mfloat = null,
            mint = null,
            mlong = null,
            mshort = null,
            mushort = null,

            mstring = null,
            mguid = null,
            mdatetime = null,
        };

        public static MembersNullableValue MembersNullableValueRandom => new MembersNullableValue()
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
