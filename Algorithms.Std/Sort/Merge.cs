using Algorithms.Std.Extensions;

namespace Algorithms.Std.Sort
{
    using System;
    using System.Collections.Generic;
    using MiscUtil.Collections;

    public static class Merge
    {
        public static void Sort<TSource>(IList<TSource> arr)
        {
            var comparer = Comparer<TSource>.Default;

            Sort(arr, comparer);
        }

        public static void Sort<TSource, TKey>(IList<TSource> arr, Func<TSource, TKey> keySelector)
        {
            var comparer = ProjectionComparer<TSource>.Create(keySelector);

            Sort(arr, comparer);
        }

        public static void Sort<TSource>(IList<TSource> arr, IComparer<TSource> comparer)
        {
            var tmp = new TSource[arr.Count];

            Sort(tmp, arr, comparer, 0, arr.Count-1);
        }

        private static void Sort<TSource>(IList<TSource> tmp, IList<TSource> src, IComparer<TSource> comparer, int lo, int hi)
        {
            if (hi <= lo)
            {
                return;
            }

            var mid = lo + (hi - lo) / 2;
            Sort(tmp, src, comparer, lo, mid);
            Sort(tmp, src, comparer, mid+ 1, hi);
            MergeInternal(tmp, src, comparer, lo, mid, hi);
        }

        private static void MergeInternal<TSource>(IList<TSource> tmp, IList<TSource> src, IComparer<TSource> comparer, int lo, int mid, int hi)
        {
            var i = lo;
            var j = mid + 1;

            for (var k = lo; k <= hi; k++)
            {
                tmp[k] = src[k];
            }

            for (var k = lo; k <= hi; k++)
            {
                if (i > mid)
                {
                    src[k] = tmp[j++];
                }
                else if (j > hi)
                {
                    src[k] = tmp[i++];
                }
                else if (comparer.Less(tmp[j], tmp[i]))
                {
                    src[k] = tmp[j++];
                }
                else
                {
                    src[k] = tmp[i++];
                }
            }
        }
    }
}