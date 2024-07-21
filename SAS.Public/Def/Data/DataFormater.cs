using System.Runtime.InteropServices;

namespace SAS.Public.Def.Data
{
    public static class DataFormater
    {
        // string property attribute: [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 100)]

        public static byte[] ToBytes<T>(T o) where T : struct
        {
            int size = Marshal.SizeOf(o);
            byte[] arr = new byte[size];

            nint ptr = nint.Zero;
            try
            {
                ptr = Marshal.AllocHGlobal(size);
                Marshal.StructureToPtr(o, ptr, true);
                Marshal.Copy(ptr, arr, 0, size);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
            return arr;
        }

        public static T ToClass<T>(byte[] bytes) where T : struct
        {
            var obj = new T();
            int size = Marshal.SizeOf(obj);
            nint ptr = nint.Zero;
            try
            {
                ptr = Marshal.AllocHGlobal(size);

                Marshal.Copy(bytes, 0, ptr, size);

                obj = (T)Marshal.PtrToStructure(ptr, obj.GetType());
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
            return obj;
        }
    }
}
