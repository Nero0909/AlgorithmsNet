using System;
using System.Collections.Generic;
using Algorithms.Std.Extensions;
using MiscUtil.Collections;

namespace Algorithms.Std.Sort
{
    public static class Insertion
    {
        public static void Sort<T>(IList<T> arr)
        {
            var comparer = Comparer<T>.Default;

            Sort(arr, comparer);
        }

        public static void Sort<TSource, TKey>(IList<TSource> arr, Func<TSource, TKey> keySelector)
        {
            var comparer = ProjectionComparer<TSource>.Create(keySelector);

            Sort(arr, comparer);
        }

        public static void Sort<TSource>(IList<TSource> arr, IComparer<TSource> comparer)
        {
            for (var i = 1; i < arr.Count; i++)
            {
                for (var j = i; j > 0 && ArrayHelper.Less(comparer, arr[j], arr[j-1]); j--)
                {
                    ArrayHelper.Swap(arr, j, j - 1);
                }
            }
        }
    }
}