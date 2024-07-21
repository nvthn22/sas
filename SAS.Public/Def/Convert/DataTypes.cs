using System.Collections.Concurrent;
using System.Reflection;

namespace SAS.Public.Def.Convert
{
    public class DataTypes
    {
        public static DataTypes Instance = new DataTypes();

        private ConcurrentDictionary<Guid, IEnumerable<TypeResult>> maps;
        private DataTypes()
        {
            maps = new ConcurrentDictionary<Guid, IEnumerable<TypeResult>>();
        }

        public class TypeResult
        {
            public string? TypeFullName;
            public TypeIndex Index = TypeIndex.Unknow;
            public bool IsNullable;
            public FieldInfo? FieldInfo;
            public PropertyInfo? PropertyInfo;

            public object? GetValue(object? obj)
            {
                switch (Index)
                {
                    case TypeIndex.Unknow: break;
                    case TypeIndex.Field: return FieldInfo!.GetValue(obj);
                    case TypeIndex.Prop: return PropertyInfo!.GetValue(obj);
                }
                return null;
            }

            public void SetValue(object? obj, object? value)
            {
                switch (Index)
                {
                    case TypeIndex.Unknow: break;
                    case TypeIndex.Field: FieldInfo!.SetValue(obj, value); break;
                    case TypeIndex.Prop: PropertyInfo!.SetValue(obj, value); break;
                }
            }

            public string Name()
            {
                switch (Index)
                {
                    case TypeIndex.Unknow: break;
                    case TypeIndex.Field: return FieldInfo!.Name;
                    case TypeIndex.Prop: return PropertyInfo!.Name;
                }
                return string.Empty;
            }
        }

        public enum TypeIndex { Unknow, Field, Prop }

        public IEnumerable<TypeResult> CheckMembers<T>() where T : class
        {
            var typeId = typeof(T).GUID;
            if (!maps.ContainsKey(typeId))
            {
                var memberFields = typeof(T).GetFields();
                IEnumerable<TypeResult> fieldsResult = memberFields
                    .Select(p =>
                    {
                        if (p.FieldType.Name == DataNames.Name_NulableGeneric && p.FieldType.IsGenericType)
                        {
                            return new TypeResult()
                            {
                                TypeFullName = p.FieldType.GetGenericArguments()[0].FullName,
                                Index = TypeIndex.Field,
                                IsNullable = true,
                                FieldInfo = p,
                            };
                        }
                        else
                        {
                            return new TypeResult()
                            {
                                TypeFullName = p.FieldType.FullName,
                                Index = TypeIndex.Field,
                                IsNullable = false,
                                FieldInfo = p,
                            };
                        }
                    });

                var memberProps = typeof(T).GetProperties();
                IEnumerable<TypeResult> propsResult = memberProps
                    .Select(p =>
                    {
                        if (p.PropertyType.Name == DataNames.Name_NulableGeneric && p.PropertyType.IsGenericType)
                        {
                            return new TypeResult()
                            {
                                TypeFullName = p.PropertyType.GetGenericArguments()[0].FullName,
                                Index = TypeIndex.Prop,
                                IsNullable = true,
                                PropertyInfo = p,
                            };
                        }
                        else
                        {
                            return new TypeResult()
                            {
                                TypeFullName = p.PropertyType.FullName,
                                Index = TypeIndex.Prop,
                                IsNullable = false,
                                PropertyInfo = p,
                            };
                        }
                    });

                maps[typeId] = fieldsResult.Concat(propsResult);
            }

            return maps[typeId];
        }
    }
}
