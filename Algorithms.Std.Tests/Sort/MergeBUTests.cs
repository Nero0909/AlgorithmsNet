namespace Algorithms.Std.Tests.Sort
{
    using System;
    using System.Collections.Generic;
    using global::Algorithms.Std.Sort;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    internal sealed class MergeBUTests : SortBase
    {
        protected override Action GetSortBySelector<TSource, TKey>(IList<TSource> arr, Func<TSource, TKey> keySelector)
        {
            return () => MergeBU<TSource>.Sort(arr, keySelector);
        }

        protected override Action GetSortByComparer<TSource>(IList<TSource> arr, IComparer<TSource> comparer)
        {
            return () => MergeBU<TSource>.Sort(arr, comparer);
        }

        protected override Action GetSimpleSort<TSource>(IList<TSource> arr)
        {
            return () => MergeBU<TSource>.Sort(arr);
        }
    }
}