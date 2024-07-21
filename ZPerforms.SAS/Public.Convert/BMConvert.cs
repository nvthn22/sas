using BenchmarkDotNet.Attributes;
using SAS.Public.Def.Convert;
using ZTests.SAS.Public.Model_Template;
using ZTests.SAS.Public.Model_Value;

namespace ZPerforms.SAS.Public.Convert
{
    [MemoryDiagnoser]
    [KeepBenchmarkFiles]
    [MarkdownExporterAttribute.Default]
    public class BMConvert
    {
        TypesValue[] typesValue;
        ReferencesValue[] referencesValue;
        PropsValue[] propsValue;
        MembersValue[] membersValue;

        [Params(10, 1000, 1000000)]
        public int Length { get; set; }

        public BMConvert()
        {
            typesValue = new TypesValue[Length];
            referencesValue = new ReferencesValue[Length];
            propsValue = new PropsValue[Length];
            membersValue = new MembersValue[Length];

            for (var i = 0; i < Length; i++)
            {
                typesValue[i] = TypesTemplate.TypesValueRandom;
                referencesValue[i] = ReferencesTemplate.ReferencesValueRandom;
                propsValue[i] = PropsTemplate.PropsValueRandom;
                membersValue[i] = MembersTemplate.MembersValueRandom;
            }
        }

        [Benchmark]
        public TypesValue[] Convert_types()
        {
            var reverses = new TypesValue[Length];
            for (var i=0; i<typesValue.Length; i++)
            {
                var bytes = DataConvert.Instance.ToBytes(typesValue[i]);
                reverses[i] = DataConvert.Instance.ToClass<TypesValue>(bytes);
            }
            return reverses;
        }

        [Benchmark]
        public ReferencesValue[] Convert_references()
        {
            var reverses = new ReferencesValue[Length];
            for (var i = 0; i < referencesValue.Length; i++)
            {
                var bytes = DataConvert.Instance.ToBytes(referencesValue[i]);
                reverses[i] = DataConvert.Instance.ToClass<ReferencesValue>(bytes);
            }
            return reverses;
        }

        [Benchmark]
        public PropsValue[] Convert_props()
        {
            var reverses = new PropsValue[Length];
            for (var i = 0; i < propsValue.Length; i++)
            {
                var bytes = DataConvert.Instance.ToBytes(propsValue[i]);
                reverses[i] = DataConvert.Instance.ToClass<PropsValue>(bytes);
            }
            return reverses;
        }

        [Benchmark]
        public MembersValue[] Convert_members()
        {
            var reverses = new MembersValue[Length];
            for (var i = 0; i < membersValue.Length; i++)
            {
                var bytes = DataConvert.Instance.ToBytes(membersValue[i]);
                reverses[i] = DataConvert.Instance.ToClass<MembersValue>(bytes);
            }
            return reverses;
        }
    }
}
