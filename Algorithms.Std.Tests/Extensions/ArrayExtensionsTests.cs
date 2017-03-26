using System;
using System.Collections;
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
            for (var i = hi + 1; i < capacity; i++)
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
        public void ShouldThrowExceptionBecauseOfNull()
        {
            // Given
            IList<int> arr = null;
            Action action = () => arr.Shuffle();

            // Then
            action.ShouldThrow<ArgumentNullException>();
        }
    }
}