namespace SAS.Public.Def.Convert
{
    public class DataNames
    {
        public const string FullName_Boolean = "System.Boolean";
        public const string FullName_Byte = "System.Byte";
        public const string FullName_SByte = "System.SByte";
        public const string FullName_Char = "System.Char";
        public const string FullName_Int16 = "System.Int16";
        public const string FullName_UInt16 = "System.UInt16";
        public const string FullName_Int32 = "System.Int32";
        public const string FullName_UInt32 = "System.UInt32";
        public const string FullName_Single = "System.Single";
        public const string FullName_Double = "System.Double";
        public const string FullName_Int64 = "System.Int64";
        public const string FullName_Decimal = "System.Decimal";

        public const string FullName_String = "System.String";
        public const string FullName_DateTime = "System.DateTime";
        public const string FullName_Guid = "System.Guid";

        public const string Name_NulableGeneric = "Nullable`1";

        public static string GetTypeName<T>()
        {
            return typeof(T).Name;
        }

        public static string? GetTypeFullName<T>()
        {
            return typeof(T).FullName;
        }
    }
}
