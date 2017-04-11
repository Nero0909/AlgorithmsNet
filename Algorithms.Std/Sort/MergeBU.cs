namespace Algorithms.Std.Sort
{
    using System;
    using System.Collections.Generic;
    using MiscUtil.Collections;

    public static class MergeBU<TSource>
    {
        private static TSource[] tmp;

        public static void Sort(IList<TSource> arr)
        {
            var comparer = Comparer<TSource>.Default;

            Sort(arr, comparer);
        }

        public static void Sort<TKey>(IList<TSource> arr, Func<TSource, TKey> keySelector)
        {
            var comparer = ProjectionComparer<TSource>.Create(keySelector);

            Sort(arr, comparer);
        }

        public static void Sort(IList<TSource> arr, IComparer<TSource> comparer)
        {
            tmp = new TSource[arr.Count];
            var N = arr.Count;

            for (var sz = 1; sz < N; sz = sz + sz)
            {
                for (var lo = 0; lo < N - sz; lo += sz + sz)
                {
                    MergeInternal(arr, comparer, lo, lo + sz - 1, Math.Min(lo + sz + sz - 1, N - 1));
                }
            }
        }

        private static void MergeInternal(IList<TSource> arr, IComparer<TSource> comparer, int lo, int mid, int hi)
        {
            var i = lo;
            var j = mid + 1;

            for (var k = lo; k <= hi; k++)
            {
                tmp[k] = arr[k];
            }

            for (var k = lo; k <= hi; k++)
            {
                if (i > mid)
                {
                    arr[k] = tmp[j++];
                }
                else if (j > hi)
                {
                    arr[k] = tmp[i++];
                }
                else if (ArrayHelper.Less(comparer, tmp[j], tmp[i]))
                {
                    arr[k] = tmp[j++];
                }
                else
                {
                    arr[k] = tmp[i++];
                }
            }
        }
    }
}