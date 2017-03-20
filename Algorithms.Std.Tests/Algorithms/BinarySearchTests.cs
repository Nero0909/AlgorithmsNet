using System;
using System.Collections.Generic;
using System.Linq;
using Algorithms.Std.Algorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Shouldly;

namespace Algorithms.Std.Tests.Algorithms
{
    [TestClass]
    public class BinarySearchTests
    {
        [Test]
        public void ShouldFindAscWithOneValue()
        {
            // Given
            var arr = Enumerable.Range(0, 1).ToArray();

            // When
            var resultAsc = arr.AscendingRank(0);

            // Then
            resultAsc.ShouldBe(0);
        }

        [Test]
        public void ShouldFindDescWithOneValue()
        {
            // Given
            var arrDesc = Enumerable.Range(0, 1).Reverse().ToArray();

            // When
            var resultDesc = arrDesc.DescendingRank(0);

            // Then
            resultDesc.ShouldBe(0);
        }

        [TestCase(0)]
        [TestCase(1)]
        public void ShouldFindAscWithTwoValues(int valueToFind)
        {
            // Given
            var arr = Enumerable.Range(0, 2).ToArray();
            var arrDesc = arr.Reverse().ToArray();

            // When
            var resultAsc = arr.AscendingRank(valueToFind);

            // Then
            resultAsc.ShouldBe(valueToFind);
        }

        [TestCase(0)]
        [TestCase(1)]
        public void ShouldFindDescWithTwoValues(int valueToFind)
        {
            // Given
            var arrDesc = Enumerable.Range(0, 2).Reverse().ToArray();

            // When
            var resultDesc = arrDesc.DescendingRank(valueToFind);

            // Then
            resultDesc.ShouldBe(Array.IndexOf(arrDesc, valueToFind));
        }

        [TestCase(30)]
        public void ShouldFindAsc(int capacity)
        {
            // Given
            var arr = Enumerable.Range(0, capacity).ToArray();
            var expectedListAsc = new List<int>(capacity);

            // When
            foreach (var item in arr)
            {
                expectedListAsc.Add(arr.AscendingRank(item));
            }

            // Then
            expectedListAsc.ShouldBe(arr);
        }

        [TestCase(30)]
        public void ShouldFindDesc(int capacity)
        {
            // Given
            var arr = Enumerable.Range(0, capacity).Reverse().ToArray();
            var expectedListDesc = new List<int>(capacity);

            // When
            foreach (var item in arr)
            {
                expectedListDesc.Add(arr.DescendingRank(item));
            }

            // Then
            expectedListDesc.ShouldBe(arr.Reverse());
        }

        [TestCase(20.0)]
        [TestCase(-2.5)]
        [TestCase(10.5)]
        public void ShouldNotFindAsc(double wrongValue)
        {
            // Given
            var arr = Enumerable.Range(0, 10).Select(x => (double)x).ToArray();

            // When
            var result = arr.AscendingRank(wrongValue);

            // Then
            result.ShouldBe(-1);
        }

        [TestCase(20.0)]
        [TestCase(-2.5)]
        [TestCase(10.5)]
        public void ShouldNotFindDesc(double wrongValue)
        {
            // Given
            var arr = Enumerable.Range(0, 10).Select(x => (double)x).Reverse().ToArray();

            // When
            var result = arr.AscendingRank(wrongValue);

            // Then
            result.ShouldBe(-1);
        }

        [Test]
        public void ShouldFindFirstIndex()
        {
            // Given
            var repeatedValue = 0;
            var arr = Enumerable.Repeat(repeatedValue, 10).ToArray();

            // When
            var result = arr.RankMin(repeatedValue);

            // Then
            result.ShouldBe(0);
        }

        [Test]
        public void ShouldNotFindFirstIndex()
        {
            // Given
            var repeatedValue = 0;
            var arr = Enumerable.Repeat(repeatedValue, 10).ToArray();

            // When
            var result = arr.RankMin(1);

            // Then
            result.ShouldBe(-1);
        }

        [TestCase(10, 9, 8, 7, 6, 5)]
        [TestCase(1, 2, 3, 4, 5, 6)]
        [TestCase(1, 2, 3, 4, 5, 6, 6)]
        [TestCase(-2, 1, 3, 10, 6, 5)]
        [TestCase(-2, 1, 3, 10, 10, 6, 5)]
        [TestCase(10)]
        [TestCase(10, 9)]
        [TestCase(9, 10)]
        [TestCase(9, 10, 10)]
        [TestCase(5, 6, 6, 6, 6, 7, 2)]
        [TestCase(5, 6, 6, 6, 6, 7)]
        [TestCase(5, 6, 6, 6, 6, 7, 6, 2)]
        public void ShouldFindBitonicMax(params int[] arr)
        {
            // Given
            var expectedMax = Array.LastIndexOf(arr, arr.Max());

            // When
            var result = arr.FindBitonicMax();

            // Then
            result.ShouldBe(expectedMax);
        }

        [TestCase(-2, 1, 3, 10, 10, 6, 5)]
        public void ShouldBitonicSearch(params int[] arr)
        {
            // Given
            var actualList = new List<int>(arr.Length);
            var expectedList = new[] {0, 1, 2, 3, 3, 5, 6};

            // When
            foreach (var item in arr)
            {
                actualList.Add(arr.BitonicSearch(item));
            }

            // Then
            actualList.ShouldBe(expectedList);
        }

    }
}