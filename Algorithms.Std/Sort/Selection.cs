using System;
using System.Collections.Generic;
using Algorithms.Std.Extensions;
using MiscUtil.Collections;

namespace Algorithms.Std.Sort
{
    public static class Selection
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
            for (var i = 0; i < arr.Count; i++)
            {
                var min = i;
                for (var j = i+1; j < arr.Count; j++)
                {
                    if (comparer.Compare(arr[j], arr[min]) < 0)
                    {
                        min = j;
                    }
                }

                arr.Swap(i, min);
            }
        }
    }
}