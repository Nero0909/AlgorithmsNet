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
    public abstract class SortBase
    {
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(50)]
        public void ShouldSort(int capacity)
        {
            // Given
            var expectedArr = Enumerable.Range(0, capacity).ToArray();
            var arrayToSort = expectedArr.ToArray();
            arrayToSort.Shuffle();

            // When
            GetSimpleSort(arrayToSort).Invoke();

            // Then
            arrayToSort.ShouldBe(expectedArr);
        }

        [TestCase(50)]
        public void ShouldSortWithRepeatedValues(int capacity)
        {
            // Given
            var testArr = Enumerable.Range(0, capacity).ToArray();
            var expectedArr = testArr.Merge(testArr).ToArray();
            var arrayToSort = expectedArr.ToArray();
            arrayToSort.Shuffle();

            // When
            GetSimpleSort(arrayToSort).Invoke();

            // Then
            arrayToSort.ShouldBe(expectedArr);
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(50)]
        public void ShouldSortSameValues(int capacity)
        {
            // Given
            var expectedArr = Enumerable.Repeat(0, capacity).ToArray();
            var arrayToSort = expectedArr.ToArray();

            // When
            GetSimpleSort(arrayToSort).Invoke();

            // Then
            arrayToSort.ShouldBe(expectedArr);
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(50)]
        public void ShouldSortBySelector(int capacity)
        {
            // Given
            var expectedArr = Enumerable.Range(0, capacity)
                .Select(x => new TestDto {Id = x, Name = x.ToString()})
                .ToArray();
            var arrayToSort = expectedArr.ToArray();
            arrayToSort.Shuffle();

            // When
            GetSortBySelector(arrayToSort, x => x.Id).Invoke();

            // Then
            arrayToSort.ShouldBe(expectedArr);
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(50)]
        public void ShouldSortByComparer(int capacity)
        {
            // Given
            var expectedArr = Enumerable.Range(0, capacity)
                .Select(x => new TestDto {Id = x, Name = x.ToString()})
                .ToArray();
            var arrayToSort = expectedArr.ToArray();
            arrayToSort.Shuffle();
            var comparer = new TestComparer();

            // When
            GetSortByComparer(arrayToSort, comparer).Invoke();

            // Then
            arrayToSort.ShouldBe(expectedArr);
        }

        protected abstract Action GetSortBySelector<TSource, TKey>(IList<TSource> arr, Func<TSource, TKey> keySelector);

        protected abstract Action GetSortByComparer<TSource>(IList<TSource> arr, IComparer<TSource> comparer);

        protected abstract Action GetSimpleSort<TSource>(IList<TSource> arr);

        private class TestDto
        {
            public int Id;

            public string Name;
        }

        private class TestComparer : IComparer<TestDto>
        {
            public int Compare(TestDto x, TestDto y)
            {
                if (x == null && y == null)
                {
                    return 0;
                }
                if (x == null)
                {
                    return -1;
                }
                if (y == null)
                {
                    return 1;
                }

                return x.Id.CompareTo(y.Id);
            }
        }
    }
}