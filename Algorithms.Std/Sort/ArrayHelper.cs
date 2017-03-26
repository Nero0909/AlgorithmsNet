using System.Collections.Generic;

namespace Algorithms.Std.Sort
{
    public static class ArrayHelper
    {
        public static void Swap<T>(IList<T> a, int i, int j)
        {
            if (i == j)
            {
                return;
            }

            var obj = a[i];
            a[i] = a[j];
            a[j] = obj;
        }

        public static bool Less<T>(IComparer<T> comparer, T first, T second)
        {
            return comparer.Compare(first, second) < 0;
        }
    }
}