using SAS.Public.Def.Convert;
using System.Security.Cryptography;

namespace SAS.Public.Def.Data
{
    public class DataRandom
    {
        public static DataRandom Instance = new DataRandom();
        private DataRandom() { }

        public void FillMembersMin<T>(T o) where T : class, new()
        {
            var members = DataTypes.Instance.CheckMembers<T>();

            foreach (var member in members)
            {
                switch (member.TypeFullName)
                {
                    // 1
                    case DataNames.FullName_Boolean: member.SetValue(o, false); break;
                    case DataNames.FullName_Byte: member.SetValue(o, Byte.MinValue); break;
                    case DataNames.FullName_SByte: member.SetValue(o, SByte.MinValue); break;

                    // 2
                    case DataNames.FullName_Char: member.SetValue(o, Char.MinValue); break;
                    case DataNames.FullName_Int16: member.SetValue(o, Int16.MinValue); break;
                    case DataNames.FullName_UInt16: member.SetValue(o, UInt16.MinValue); break;

                    // 4
                    case DataNames.FullName_Int32: member.SetValue(o, Int32.MinValue); break;
                    case DataNames.FullName_UInt32: member.SetValue(o, UInt32.MinValue); break;
                    case DataNames.FullName_Single: member.SetValue(o, Single.MinValue); break;

                    // 8
                    case DataNames.FullName_Double: member.SetValue(o, Double.MinValue); break;
                    case DataNames.FullName_Int64: member.SetValue(o, Int64.MinValue); break;

                    // 16
                    case DataNames.FullName_Decimal: member.SetValue(o, Decimal.MinValue); break;

                    // ref
                    case DataNames.FullName_String: member.SetValue(o, null); break;
                    case DataNames.FullName_DateTime: member.SetValue(o, DateTime.MinValue); break;
                    case DataNames.FullName_Guid: member.SetValue(o, null); break;

                    default: break;
                }
            }
        }

        public void FillMembersMax<T>(T o) where T : class, new()
        {
            var members = DataTypes.Instance.CheckMembers<T>();

            foreach (var member in members)
            {
                switch (member.TypeFullName)
                {
                    // 1
                    case DataNames.FullName_Boolean: member.SetValue(o, true); break;
                    case DataNames.FullName_Byte: member.SetValue(o, Byte.MaxValue); break;
                    case DataNames.FullName_SByte: member.SetValue(o, SByte.MaxValue); break;

                    // 2
                    case DataNames.FullName_Char: member.SetValue(o, Char.MaxValue); break;
                    case DataNames.FullName_Int16: member.SetValue(o, Int16.MaxValue); break;
                    case DataNames.FullName_UInt16: member.SetValue(o, UInt16.MaxValue); break;

                    // 4
                    case DataNames.FullName_Int32: member.SetValue(o, Int32.MaxValue); break;
                    case DataNames.FullName_UInt32: member.SetValue(o, UInt32.MaxValue); break;
                    case DataNames.FullName_Single: member.SetValue(o, Single.MaxValue); break;

                    // 8
                    case DataNames.FullName_Double: member.SetValue(o, Double.MaxValue); break;
                    case DataNames.FullName_Int64: member.SetValue(o, Int64.MaxValue); break;

                    // 16
                    case DataNames.FullName_Decimal: member.SetValue(o, Decimal.MaxValue); break;

                    // ref
                    case DataNames.FullName_String: member.SetValue(o, RandomString()); break;
                    case DataNames.FullName_DateTime: member.SetValue(o, DateTime.MaxValue); break;
                    case DataNames.FullName_Guid:
                        member.SetValue(o, new Guid(
                        int.MaxValue, short.MaxValue, short.MaxValue,
                        byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue,
                        byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue)
                        ); break;

                    default: break;
                }
            }
        }

        public void FillMembersRandom<T>(T o) where T : class, new()
        {
            var members = DataTypes.Instance.CheckMembers<T>();

            foreach (var member in members)
            {
                switch (member.TypeFullName)
                {
                    // 1
                    case DataNames.FullName_Boolean: member.SetValue(o, RandomBoolean()); break;
                    case DataNames.FullName_Byte: member.SetValue(o, RandomByte()); break;
                    case DataNames.FullName_SByte: member.SetValue(o, RandomSByte()); break;

                    // 2
                    case DataNames.FullName_Char: member.SetValue(o, RandomChar()); break;
                    case DataNames.FullName_Int16: member.SetValue(o, RandomInt16()); break;
                    case DataNames.FullName_UInt16: member.SetValue(o, RandomUInt16()); break;

                    // 4
                    case DataNames.FullName_Int32: member.SetValue(o, RandomInt32()); break;
                    case DataNames.FullName_UInt32: member.SetValue(o, RandomUInt32()); break;
                    case DataNames.FullName_Single: member.SetValue(o, RandomSingle()); break;

                    // 8
                    case DataNames.FullName_Double: member.SetValue(o, RandomDouble()); break;
                    case DataNames.FullName_Int64: member.SetValue(o, RandomInt64()); break;

                    // 16
                    case DataNames.FullName_Decimal: member.SetValue(o, RandomDecimal()); break;

                    // ref
                    case DataNames.FullName_String: member.SetValue(o, RandomString()); break;
                    case DataNames.FullName_DateTime: member.SetValue(o, RandomDateTime()); break;
                    case DataNames.FullName_Guid: member.SetValue(o, Guid.NewGuid()); break;

                    default: break;
                }
            }
        }

        public string RandomString(int minLength = 10, int maxLength = 20)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var length = RandomNumberGenerator.GetInt32(minLength, maxLength);
            var stringChars = new char[length];

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[Random.Shared.Next(chars.Length)];
            }

            return new String(stringChars);
        }

        public DateTime RandomDateTime()
        {
            var rndUInt64 = (ulong)(BitConverter.ToUInt64(RandomNumberGenerator.GetBytes(sizeof(long))));
            var rndDateTimeBinary = (long)(rndUInt64 % 3_155_378_976_000_000_000);
            var rndDateTime = DateTime.FromBinary(rndDateTimeBinary);
            return rndDateTime;
        }

        public Guid RandomGuid()
        {
            return Guid.NewGuid();
        }

        public bool RandomBoolean() { return (bool)((RandomNumberGenerator.GetBytes(1)[0] & 0b100) == 0); }
        public byte RandomByte() { return (byte)(RandomNumberGenerator.GetBytes(1)[0]); }
        public sbyte RandomSByte() { return (sbyte)(RandomNumberGenerator.GetBytes(1)[0]); }
        public char RandomChar() { return (char)(BitConverter.ToChar(RandomNumberGenerator.GetBytes(sizeof(char)))); }
        public short RandomInt16() { return (short)(BitConverter.ToInt16(RandomNumberGenerator.GetBytes(sizeof(short)))); }
        public ushort RandomUInt16() { return (ushort)(BitConverter.ToUInt16(RandomNumberGenerator.GetBytes(sizeof(ushort)))); }
        public int RandomInt32() { return (int)(BitConverter.ToInt32(RandomNumberGenerator.GetBytes(sizeof(int)))); }
        public uint RandomUInt32() { return (uint)(BitConverter.ToUInt32(RandomNumberGenerator.GetBytes(sizeof(uint)))); }
        public float RandomSingle() { return (float)(BitConverter.ToSingle(RandomNumberGenerator.GetBytes(sizeof(float)))); }
        public double RandomDouble() { return (double)(BitConverter.ToDouble(RandomNumberGenerator.GetBytes(sizeof(double)))); }
        public long RandomInt64() { return (long)(BitConverter.ToInt64(RandomNumberGenerator.GetBytes(sizeof(long)))); }
        public decimal RandomDecimal() {
            var bytes = RandomNumberGenerator.GetBytes(13);
            
            var int1 = BitConverter.ToInt32(bytes, 0);
            var int2 = BitConverter.ToInt32(bytes, 4);
            var int3 = BitConverter.ToInt32(bytes, 8);
            var sign = (bytes[8] & 0b100) == 0;
            var scale = (byte)(bytes[12] % 28);
            
            return (new decimal(int1, int2, int3, sign, scale));
        }

    }
}
