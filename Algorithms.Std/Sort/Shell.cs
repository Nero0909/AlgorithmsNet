using System;
using System.Collections.Generic;
using Algorithms.Std.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiscUtil.Collections;

namespace Algorithms.Std.Sort
{
    [TestClass]
    public static class Shell
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
            var h = ComputeH(arr.Count);
            while (h >= 1)
            {
                for (var i = h; i < arr.Count; i++)
                {
                    for (var j = i; j >= h && comparer.Less(arr[j], arr[j-h]); j -= h)
                    {
                        arr.Swap(j, j - h);
                    }
                }
                h /= 3;
            }
        }

        private static int ComputeH(int n)
        {
            var h = 1;
            while (h < n/3)
            {
                h = 3 * h + 1;
            }

            return h;
        }
    }
}