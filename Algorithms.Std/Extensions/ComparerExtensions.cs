using System.Collections.Generic;

namespace Algorithms.Std.Extensions
{
    public static class ComparerExtensions
    {
        public static bool Less<T>(this IComparer<T> comparer, T first, T second)
        {
            return comparer.Compare(first, second) < 0;
        }

        public static bool Greater<T>(this IComparer<T> comparer, T first, T second)
        {
            return comparer.Compare(first, second) > 0;
        }
        
        public static bool Equal<T>(this IComparer<T> comparer, T first, T second)
        {
            return comparer.Compare(first, second) == 0;
        }
    }
}