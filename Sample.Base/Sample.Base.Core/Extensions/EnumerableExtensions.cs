using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sample.Base.Core.Extensions
{
    public static class EnumerableExtensions
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable)
        {
            if (enumerable == null)
            {
                return true;
            }
            ICollection<T> collection;
            if ((collection = (enumerable as ICollection<T>)) != null)
            {
                return collection.Count < 1;
            }
            return !enumerable.Any();
        }

        public static IEnumerable<int> IndexesWhere<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            int index = 0;
            foreach (T item in source)
            {
                if (predicate(item))
                {
                    yield return index;
                }
                index++;
            }
        }

        public static T ElementAtOrDefault<T>(this IEnumerable<T> list, int index, T @default)
        {
            if (index < 0 || index >= list.Count())
            {
                return @default;
            }
            return list.ElementAt(index);
        }
    }
}
