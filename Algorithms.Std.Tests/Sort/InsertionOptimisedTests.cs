namespace Algorithms.Std.Tests.Sort
{
    using System;
    using System.Collections.Generic;
    using global::Algorithms.Std.Sort;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class InsertionOptimisedTests : SortBase
    {
        protected override Action GetSortBySelector<TSource, TKey>(IList<TSource> arr, Func<TSource, TKey> keySelector)
        {
            return () => Insertion.SortOptimised(arr, keySelector);
        }

        protected override Action GetSortByComparer<TSource>(IList<TSource> arr, IComparer<TSource> comparer)
        {
            return () => Insertion.SortOptimised(arr, comparer);
        }

        protected override Action GetSimpleSort<TSource>(IList<TSource> arr)
        {
            return () => Insertion.SortOptimised(arr);
        }
    }
}