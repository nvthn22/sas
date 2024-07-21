using SAS.Public.Def.Convert;

namespace SAS.Public.Def.Extensions
{
    public class MembersCompare
    {
        public class CompareResult
        {
            public bool IsEqual { get; set; }
            public string? FirstDiff { get; set; }
        }

        public static CompareResult Compare<T>(T expected, T actual) where T : class
        {
            var members = DataTypes.Instance.CheckMembers<T>();

            foreach (var member in members)
            {
                var left = member.GetValue(expected);
                var right = member.GetValue(actual);

                bool equal;
                switch (member.TypeFullName)
                {
                    // 1
                    case DataNames.FullName_Boolean: equal = ((bool?)left == (bool?)right); break;
                    case DataNames.FullName_Byte: equal = ((byte?)left == (byte?)right); break;
                    case DataNames.FullName_SByte: equal = ((sbyte?)left == (sbyte?)right); break;

                    // 2
                    case DataNames.FullName_Char: equal = ((char?)left == (char?)right); break;
                    case DataNames.FullName_Int16: equal = ((short?)left == (short?)right); break;
                    case DataNames.FullName_UInt16: equal = ((ushort?)left == (ushort?)right); break;

                    // 4
                    case DataNames.FullName_Int32: equal = ((int?)left == (int?)right); break;
                    case DataNames.FullName_UInt32: equal = ((uint?)left == (uint?)right); break;
                    case DataNames.FullName_Single: equal = ((float?)left == (float?)right); break;

                    // 8
                    case DataNames.FullName_Double: equal = ((double?)left == (double?)right); break;
                    case DataNames.FullName_Int64: equal = ((long?)left == (long?)right); break;

                    // 16
                    case DataNames.FullName_Decimal: equal = ((decimal?)left == (decimal?)right); break;

                    // ref
                    case DataNames.FullName_String: equal = string.Equals((string?)left, (string?)right); break;
                    case DataNames.FullName_DateTime: equal = ((DateTime?)left == (DateTime?)right); break;
                    case DataNames.FullName_Guid:
                        {
                            var _left = (Guid?)left;
                            var _right = (Guid?)right;
                            var isNull = (_left == null) && (_right == null);
                            var isNotNull = (_left != null) && (_right != null);

                            equal = isNull || (isNotNull && _left.Equals(_right));
                        }
                        break;

                    default: equal = Object.ReferenceEquals(left, right); break;
                }
                if (!equal) return new CompareResult() { IsEqual = false, FirstDiff = member.Name() };
            }

            return new CompareResult() { IsEqual = true };
        }
    }
}
