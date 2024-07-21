using BenchmarkDotNet.Attributes;
using SAS.Public.Def.Data;

namespace ZPerforms.SAS.Public.Data
{
    [MemoryDiagnoser]
    [KeepBenchmarkFiles]
    [MarkdownExporterAttribute.Default]
    public class BMRandom
    {
        [Params(10, 1_000, 1_000_000)]
        public int Length { get; set; }

        public bool[] bools { get; set; }
        public byte[] bytes { get; set; }
        public sbyte[] sbytes { get; set; }
        public char[] chars { get; set; }
        public short[] shorts { get; set; }
        public ushort[] ushorts { get; set; }
        public int[] ints { get; set; }
        public uint[] uints { get; set; }
        public float[] floats { get; set; }
        public double[] doubles { get; set; }
        public long[] longs { get; set; }
        public decimal[] decimals { get; set; }

        public BMRandom()
        {
            bools = new bool[Length];
            bytes = new byte[Length];
            sbytes = new sbyte[Length];
            chars = new char[Length];
            shorts = new short[Length];
            ushorts = new ushort[Length];
            ints = new int[Length];
            uints = new uint[Length];
            floats = new float[Length];
            doubles = new double[Length];
            longs = new long[Length];
            decimals = new decimal[Length];
        }

        [Benchmark]
        public bool[] Random_bools()
        {
            for (var i=0; i < Length; i++)
            {
                bools[i] = DataRandom.Instance.RandomBoolean(); 
            }
            return bools;
        }

        [Benchmark]
        public byte[] Random_bytes()
        {
            for (var i = 0; i < Length; i++)
            {
                bytes[i] = DataRandom.Instance.RandomByte();
            }
            return bytes;
        }

        [Benchmark]
        public sbyte[] Random_sbytes()
        {
            for (var i = 0; i < Length; i++)
            {
                sbytes[i] = DataRandom.Instance.RandomSByte();
            }
            return sbytes;
        }

        [Benchmark]
        public char[] Random_chars()
        {
            for (var i = 0; i < Length; i++)
            {
                chars[i] = DataRandom.Instance.RandomChar();
            }
            return chars;
        }

        [Benchmark]
        public short[] Random_shorts()
        {
            for (var i = 0; i < Length; i++)
            {
                shorts[i] = DataRandom.Instance.RandomInt16();
            }
            return shorts;
        }

        [Benchmark]
        public ushort[] Random_ushorts()
        {
            for (var i = 0; i < Length; i++)
            {
                ushorts[i] = DataRandom.Instance.RandomUInt16();
            }
            return ushorts;
        }

        [Benchmark]
        public int[] Random_ints()
        {
            for (var i = 0; i < Length; i++)
            {
                ints[i] = DataRandom.Instance.RandomInt32();
            }
            return ints;
        }

        [Benchmark]
        public uint[] Random_uints()
        {
            for (var i = 0; i < Length; i++)
            {
                uints[i] = DataRandom.Instance.RandomUInt32();
            }
            return uints;
        }

        [Benchmark]
        public float[] Random_floats()
        {
            for (var i = 0; i < Length; i++)
            {
                floats[i] = DataRandom.Instance.RandomSingle();
            }
            return floats;
        }

        [Benchmark]
        public double[] Random_doubles()
        {
            for (var i = 0; i < Length; i++)
            {
                doubles[i] = DataRandom.Instance.RandomDouble();
            }
            return doubles;
        }

        [Benchmark]
        public long[] Random_longs()
        {
            for (var i = 0; i < Length; i++)
            {
                longs[i] = DataRandom.Instance.RandomInt64();
            }
            return longs;
        }

        [Benchmark]
        public decimal[] Random_decimals()
        {
            for (var i = 0; i < Length; i++)
            {
                decimals[i] = DataRandom.Instance.RandomDecimal();
            }
            return decimals;
        }

    }
}
