using Algorithms.Std.Extensions;

namespace Algorithms.Std.Sort
{
    using System;
    using System.Collections.Generic;
    using MiscUtil.Collections;

    public static class MergeBU
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
            var N = arr.Count;

            for (var sz = 1; sz < N; sz = sz + sz)
            {
                for (var lo = 0; lo < N - sz; lo += sz + sz)
                {
                    MergeInternal(tmp, arr, comparer, lo, lo + sz - 1, Math.Min(lo + sz + sz - 1, N - 1));
                }
            }
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