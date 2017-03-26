using System.Collections;
using System.Collections.Generic;
using Algorithms.Std.Extensions;
using Algorithms.Std.Sort;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Shouldly;

namespace Algorithms.Std.Tests.Sort
{
    [TestClass]
    public class ArrayHelperTests
    {
        [Test]
        public void ShouldSwap()
        {
            // Given
            var arr = new[] {1, 2};

            // When
            ArrayHelper.Swap(arr, 0, 1);

            // Then
            arr[0].ShouldBe(2);
            arr[1].ShouldBe(1);
        }

        [Test]
        public void ShouldSwapTheSameElement()
        {
            // Given
            var arr = new[] {1};

            // When
            ArrayHelper.Swap(arr, 0, 0);

            // Then
            arr[0].ShouldBe(1);
        }

        [TestCase(0, 0)]
        [TestCase(0, 1)]
        [TestCase(1, 0)]
        public void ShouldLess(int first, int second)
        {
            // Given
            var comparer = Comparer<int>.Default;
            var expectedResult = first < second;

            // When
            var result = ArrayHelper.Less(comparer, first, second);

            // Then
            result.ShouldBe(expectedResult);
        }
    }
}