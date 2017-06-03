using System;
using System.Collections.Generic;

namespace Algorithms.Std.Extensions
{
    public static class ListExtensions
    {
        public static void Swap<T>(this IList<T> list, int i, int j)
        {
            if (list == null)
            {
                throw new ArgumentNullException(nameof(list));
            }
            
            if (i == j)
            {
                return;
            }

            var obj = list[i];
            list[i] = list[j];
            list[j] = obj;
        }
    }
}