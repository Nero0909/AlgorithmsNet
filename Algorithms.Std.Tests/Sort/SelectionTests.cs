using System;
using System.Collections.Generic;
using System.Linq;
using Algorithms.Std.Extensions;
using Algorithms.Std.Sort;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Shouldly;

namespace Algorithms.Std.Tests.Sort
{
    [TestClass]
    public class SelectionTests : SortBase
    {
        protected override Action GetSortBySelector<TSource, TKey>(IList<TSource> arr,
            Func<TSource, TKey> keySelector)
        {
            return () => Selection.Sort(arr, keySelector);
        }

        protected override Action GetSortByComparer<TSource>(IList<TSource> arr,
            IComparer<TSource> comparer)
        {
            return () => Selection.Sort(arr, comparer);
        }

        protected override Action GetSimpleSort<TSource>(IList<TSource> arr)
        {
            return () => Selection.Sort(arr);
        }
    }
}