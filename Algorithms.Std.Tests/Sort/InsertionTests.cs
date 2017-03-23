using System;
using System.Collections.Generic;
using Algorithms.Std.Sort;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Std.Tests.Sort
{
    [TestClass]
    public class InsertionTests : SortBase
    {
        protected override Action GetSortBySelector<TSource, TKey>(IList<TSource> arr, Func<TSource, TKey> keySelector)
        {
            return () => Insertion.Sort(arr, keySelector);
        }

        protected override Action GetSortByComparer<TSource>(IList<TSource> arr, IComparer<TSource> comparer)
        {
            return () => Insertion.Sort(arr, comparer);
        }

        protected override Action GetSimpleSort<TSource>(IList<TSource> arr)
        {
            return () => Insertion.Sort(arr);
        }
    }
}