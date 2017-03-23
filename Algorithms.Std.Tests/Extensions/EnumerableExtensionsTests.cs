using System;
using System.Collections.Generic;
using System.Linq;
using Algorithms.Std.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Shouldly;

namespace Algorithms.Std.Tests.Extensions
{
    [TestClass]
    public class EnumerableExtensionsTests
    {
        [Test]
        public void ShouldMergeArraysWithTheSameSize()
        {
            // Given
            var capacity = 20;
            var expectedResult = Enumerable.Range(0, capacity).ToArray();
            var even = Enumerable.Range(0, capacity).Where(x => x % 2 == 0);
            var odd = Enumerable.Range(0, capacity).Where(x => x % 2 != 0);

            // When
            var result = even.Merge(odd).ToArray();

            // Then
            result.Length.ShouldBe(capacity);
            result.ShouldBe(expectedResult);
        }

        [Test]
        public void ShouldMergeArraysWhereFirstIsBigger()
        {
            // Given
            var capacity = 20;
            var expectedResult = Enumerable.Range(0, capacity).ToArray();
            var first = Enumerable.Range(0, capacity / 2).Where(x => x % 2 == 0).Concat(Enumerable.Range(capacity / 2, capacity / 2));
            var second = Enumerable.Range(0, capacity / 2).Where(x => x % 2 != 0);

            // When
            var result = first.Merge(second).ToArray();

            // Then
            result.Length.ShouldBe(capacity);
            result.ShouldBe(expectedResult);
        }

        [Test]
        public void ShouldMergeArraysWhereSecondIsBigger()
        {
            // Given
            var capacity = 20;
            var expectedResult = Enumerable.Range(0, capacity).ToArray();
            var first = Enumerable.Range(0, capacity / 2).Where(x => x % 2 == 0);
            var second = Enumerable.Range(0, capacity / 2).Where(x => x % 2 != 0).Concat(Enumerable.Range(capacity / 2, capacity / 2));

            // When
            var result = first.Merge(second).ToArray();

            // Then
            result.Length.ShouldBe(capacity);
            result.ShouldBe(expectedResult);
        }

        [Test]
        public void ShouldMergeTheSameArray()
        {
            // Given
            var expectedResult = new[] {0, 0, 1, 1, 2, 2, 3, 3, 4, 4};
            var testArray = new[] {0, 1, 2, 3, 4};

            // When
            var result = testArray.Merge(testArray).ToArray();

            // Then
            result.Length.ShouldBe(10);
            result.ShouldBe(expectedResult);
        }

        [Test]
        public void ShouldThrowIfTheFirstArgumentIsNull()
        {
            // Given
            var first = new[] {1};
            IEnumerable<int> second = null;
            Action action = () => first.Merge(second);

            // Then
            action.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ShouldThrowIfTheSecondArgumentIsNull()
        {
            // Given
            var second = new[] {1};
            IEnumerable<int> first = null;
            Action action = () => first.Merge(second);

            // Then
            action.ShouldThrow<ArgumentNullException>();
        }
    }
}