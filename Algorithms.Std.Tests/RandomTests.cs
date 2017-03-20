using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Shouldly;

namespace Algorithms.Std.Tests
{
    [TestClass]
    public class RandomTests
    {
        [Test]
        public void ShouldGetUniformDouble()
        {
            // Given
            var operationsCount = 50;

            // Then
            for (var i = 0; i < operationsCount; i++)
            {
                var r = Random.Uniform();
                var assertion = r >= 0 && r < 1;
                assertion.ShouldBe(true);
            }
        }

        [Test]
        public void ShouldGetRandomIntWithHighBound()
        {
            // Given
            var operationsCount = 50;

            // Then
            for (var i = 1; i < operationsCount; i++)
            {
                var r = Random.Uniform(1);
                var assertion = r >= 0 && r < i;
                assertion.ShouldBe(true);
            }
        }

        [Test]
        public void ShouldGetRandomIntWithinRange()
        {
            // Given
            var operationsCount = 50;
            var interval = 10;

            // Then
            for (var i = 1; i < operationsCount; i++)
            {
                var lo = i;
                var hi = i + interval;
                var r = Random.Uniform(lo, hi);
                var assertion = r >= lo && r < hi;
                assertion.ShouldBe(true);
            }
        }

        [Test]
        public void ShouldGetRandomDoubleWithinRange()
        {
            // Given
            var operationsCount = 50;
            var interval = 10;

            // Then
            for (var i = 1; i < operationsCount; i++)
            {
                var lo = i + 0.5;
                var hi = i + interval + 0.5;
                var r = Random.Uniform(lo, hi);
                var assertion = r >= lo && r < hi;
                assertion.ShouldBe(true);
            }
        }
    }
}