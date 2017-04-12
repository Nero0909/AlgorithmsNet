namespace Algorithms.Std.Sort
{
    using System;
    using System.Collections.Generic;
    using MiscUtil.Collections;

    public class MergeNotStable
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
            for (var k = lo; k <= mid; k++)
            {
                tmp[k] = src[k];
            }

            for (var k = mid+1; k <= hi; k++)
            {
                tmp[k] = src[hi - k + mid + 1];
            }

            var i = lo;
            var j = hi;
            for (var k = lo; k <= hi; k++)
            {
                if (ArrayHelper.Less(comparer, tmp[j], tmp[i]))
                {
                    src[k] = tmp[j--];
                }
                else
                {
                    src[k] = tmp[i++];
                }
            }
        }
    }
}