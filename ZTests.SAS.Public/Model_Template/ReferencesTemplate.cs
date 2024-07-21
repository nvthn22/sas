using SAS.Public.Def.Data;
using ZTests.SAS.Public.Model_Value;

namespace ZTests.SAS.Public.Model_Template
{
    public class ReferencesTemplate
    {
        public static ReferencesValue ReferencesValueRandom => new ReferencesValue()
        {
            mstring = DataRandom.Instance.RandomString(),
            mguid = DataRandom.Instance.RandomGuid(),
            mdatetime = DataRandom.Instance.RandomDateTime(),
        };

        public static ReferencesValue ReferencesValue = new ReferencesValue()
        {
            mstring = "abc",
            mguid = Guid.NewGuid(),
            mdatetime = DateTime.Now,
        };

        public static ReferencesValue ReferencesValueNull = new ReferencesValue()
        {
            mstring = null,
            mguid = null,
            mdatetime = null,
        };

        public static string?[] StringSamples = [
            null,
            "",
            "abcdef54sadf66as5d4f5asdf465654asd5f654",
        ];

        public static string?[] StringUnicodeSamples = [
            null,
            "",
            "😀😁😂🤣😃😄😅😆😉😊😋😎",
            "¢£¤¥§©ª«®µ¶ұҴҷۿݒ₯₳₶ꟁꟄꟇﯡﯦﻜﻟ",
            "ɦɩɭʢʤʨϫϭϱԾՃՆݣݦݩ◊●ꙭ꙰꙲ﬔיִﬡﷺ﷽ﺹﺾ",
        ];

        public static DateTime?[] DateTimeSamples = [
            null,
            DateTime.Now,
            DateTime.MinValue,
            DateTime.MaxValue,
            DateTime.Now.AddDays(100),
            DateTime.Now.AddYears(100),
        ];

        public static Guid?[] GuidSamples = [
            null,
            Guid.Empty,
            Guid.NewGuid(),
        ];
    }
}
