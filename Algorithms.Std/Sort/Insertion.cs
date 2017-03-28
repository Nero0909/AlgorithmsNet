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

        public static void SortOptimised<T>(IList<T> arr)
        {
            var comparer = Comparer<T>.Default;

            SortOptimised(arr, comparer);
        }

        public static void SortOptimised<TSource, TKey>(IList<TSource> arr, Func<TSource, TKey> keySelector)
        {
            var comparer = ProjectionComparer<TSource>.Create(keySelector);

            SortOptimised(arr, comparer);
        }

        public static void SortOptimised<TSource>(IList<TSource> arr, IComparer<TSource> comparer)
        {
            if (CreateSentinel(arr, comparer) > 0)
            {
                SortWithHalfExch(arr, comparer);
            }
        }

        private static int CreateSentinel<TSource>(IList<TSource> arr, IComparer<TSource> comparer)
        {
            var exchanges = 0;
            for (var i = arr.Count - 1; i > 0 ; i--)
            {
                if (ArrayHelper.Less(comparer, arr[i], arr[i-1]))
                {
                    ArrayHelper.Swap(arr, i, i-1);
                    exchanges++;
                }
            }

            return exchanges;
        }

        private static void SortWithHalfExch<TSource>(IList<TSource> arr, IComparer<TSource> comparer)
        {
            for (var i = 2; i < arr.Count; i++)
            {
                var tmp = arr[i];
                var j = i;
                while (ArrayHelper.Less(comparer, tmp, arr[j-1]))
                {
                    arr[j] = arr[j - 1];
                    j--;
                }

                arr[j] = tmp;
            }
        }
    }
}