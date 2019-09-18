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
    }
}
