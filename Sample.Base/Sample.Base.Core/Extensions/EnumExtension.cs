using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Sample.Base.Core.Extensions
{
    public static class EnumExtension
    {
        public static string ToDescription(this Enum e)
        {
            return GetEnumDescription(e);
        }

        public static T ToEnum<T>(this string description, bool ignoreCase = false) where T : IConvertible
        {
            StringComparer stringComparer = (ignoreCase == true ? StringComparer.OrdinalIgnoreCase : StringComparer.Ordinal);

            Array array = Enum.GetValues(typeof(T));

            var list = new List<T>(array.Length);

            for (int i = 0; i < array.Length; i++)
            {
                list.Add((T)array.GetValue(i));
            }

            var dict = list.Select(v =>
                new
                {
                    Value = v,
                    Description = GetEnumDescription(v)
                }
            ).ToDictionary(x => x.Description, x => x.Value, stringComparer);

            return dict[description];
        }

        public static string ToEnumString<T>(this string number) where T : IConvertible
        {
            var enumT = (T)Enum.ToObject(typeof(T), number);
            return enumT.ToString();
        }

        private static string GetEnumDescription<T>(T value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
            {
                return attributes[0].Description;
            }
            else
            {
                throw new Exception(string.Format("No description on {0}.{1}", value.GetType(), value.ToString()));
            }
        }
    }
}
