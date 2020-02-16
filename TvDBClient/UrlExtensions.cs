using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;

namespace TvDBClient
{
    internal static class UrlExtensions
    {
        public static string ToQueryParam(this Enum @enum)
        {
            var elements = @enum
            .ToString()
            .Split(',')
            .Select(element => element.Trim().ToPascalCase())
            .OrderBy(element => element);

            return string.Join(",", elements);
        }

        internal static string ToQueryParams<T>(this T obj)
        {
            var parts = new List<string>();

            foreach (var propertyInfo in typeof(T).GetTypeInfo().DeclaredProperties.OrderBy(info => info.Name))
            {
                var value = propertyInfo.GetValue(obj);

                if (value != null)
                {
                    parts.Add($"{propertyInfo.Name.ToPascalCase()}={Uri.EscapeDataString(value.ToString())}");
                }
            }

            return string.Join("&", parts);
        }

        internal static string ToPascalCase(this string name)
        {
            var array = name.ToCharArray();

            array[0] = char.ToLower(array[0]);

            return new string(array);
        }
    }
}
