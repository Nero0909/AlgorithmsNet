using System.Linq;
using Algorithms.Std.Algorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Shouldly;

namespace Algorithms.Std.Tests.Algorithms
{
    using System;

    [TestClass]
    public class TwoSumsTest
    {
        [Test]
        public void ShouldCount()
        {
            // Given
            var capacity = 20;
            var arr = Enumerable.Range(0, capacity).Select(x => x - capacity / 2).ToArray();

            // When
            var result = arr.CountTwoSums();

            // Then
            result.ShouldBe(capacity / 2 - 1);
        }

        [Test]
        public void ShouldCountWithOnePair()
        {
            // Given
            var arr = new[] {-5, -4, -3, -2, -1, 0, 1};

            // When
            var result = arr.CountTwoSums();

            // Then
            result.ShouldBe(1);
        }

        [Test]
        public void ShouldNotCountPairs()
        {
            // Given
            var arr = new[] {-5, -4, -3, -2, -1, 0, 10};

            // When
            var result = arr.CountTwoSums();

            // Then
            result.ShouldBe(0);
        }

        [Test]
        public void ShouldCountSlowAndFast()
        {
            // Given
            var capacity = 20;
            var arr = Enumerable.Range(0, capacity).Select(x => x - capacity / 2).ToArray();

            // When
            var resultFast = arr.CountTwoSums();
            var resultSlow = arr.CountTwoSumsSlow();

            // Then
            resultFast.ShouldBe(resultSlow);
        }

        [TestCase(-4,-3.2, -2, 0, 1, 3)]
        public void ShouldFindPositiveNearestPair(params double[] arr)
        {
            // Given
            var expectedResult = new Tuple<double, double>(0.0, 1.0);

            // When
            var result = arr.NearestPair();

            // Then
            expectedResult.Item1.ShouldBe(result.Item1);
            expectedResult.Item2.ShouldBe(result.Item2);
        }

        [TestCase(-4,-3.2, -2, -1, 1, 3)]
        public void ShouldFindNegativeNearestPair(params double[] arr)
        {
            // Given
            var expectedResult = new Tuple<double, double>(-1.0, -2.0);

            // When
            var result = arr.NearestPair();

            // Then
            expectedResult.Item1.ShouldBe(result.Item1);
            expectedResult.Item2.ShouldBe(result.Item2);
        }


        [TestCase(-10.0,-7.2, -2, 1, 5, 10)]
        public void ShouldFindMixedNearestPair(params double[] arr)
        {
            // Given
            var expectedResult = new Tuple<double, double>(1.0, -2.0);

            // When
            var result = arr.NearestPair();

            // Then
            expectedResult.Item1.ShouldBe(result.Item1);
            expectedResult.Item2.ShouldBe(result.Item2);
        }
    }
}