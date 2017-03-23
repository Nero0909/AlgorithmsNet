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
    public class ArrayExtensionsTests
    {
        [TestCase(0)]
        [TestCase(1)]
        public void ShouldNotShuffleArray(int capacity)
        {
            // Given
            var arr = Enumerable.Range(0, capacity).ToArray();
            var shuffledArray = arr.ToArray();

            // When
            shuffledArray.Shuffle();

            // Then
            shuffledArray.ShouldBe(arr);
        }

        [Test]
        public void ShouldShuffleEntireArray()
        {
            // Given
            var capacity = 50;
            var arr = Enumerable.Range(0, capacity).ToArray();
            var shuffledArray = arr.ToArray();

            // When
            shuffledArray.Shuffle();

            // Then
            shuffledArray.ShouldNotBe(arr);
        }

        [Test]
        public void ShouldShuffleHalfArray()
        {
            // Given
            var capacity = 50;
            var arr = Enumerable.Range(0, capacity).ToArray();
            var shuffledArray = arr.ToArray();
            var hi = capacity / 2;

            // When
            shuffledArray.Shuffle(0, hi);

            // Then
            for (var i=hi+1; i < capacity; i++)
            {
                shuffledArray[i].ShouldBe(arr[i]);
            }
        }

        [TestCase(-1, 1, 10)]
        [TestCase(5, 1, 10)]
        [TestCase(0, 10, 10)]
        [TestCase(0, 11, 10)]
        public void ShouldThrowExceptionBecauseOfInvalidRange(int lo, int hi, int capacity)
        {
            // Given
            var arr = Enumerable.Range(0, capacity).ToArray();
            Action action = () => arr.Shuffle(lo, hi);

            // Then
            action.ShouldThrow<ArgumentException>();
        }

        [Test]
        public void ShouldSwap()
        {
            // Given
            var arr = new[] {1, 2};

            // When
            arr.Swap(0, 1);

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
            arr.Swap(0, 0);

            // Then
            arr[0].ShouldBe(1);
        }

        [TestCase(-1, 1, 10)]
        [TestCase(11, 0, 10)]
        [TestCase(0, -1, 10)]
        [TestCase(0, 11, 10)]
        public void ShouldThrowExceptionInSwapBecauseOfInvalidIndexes(int i, int j, int capacity)
        {
            // Given
            var arr = Enumerable.Range(0, capacity).ToArray();
            Action action = () => arr.Swap(i, j);

            // Then
            action.ShouldThrow<ArgumentException>();
        }


        [Test]
        public void ShouldThrowExceptionInSwapBecauseOfNull()
        {
            // Given
            IList<int> arr = null;
            Action action = () => arr.Swap(0, 0);

            // Then
            action.ShouldThrow<ArgumentNullException>();
        }
    }
}