namespace Algorithms.Std.Tests.Collections.DoubleBufferTests
{
    using System;
    using global::Algorithms.Std.Collections.DoubleBuffer;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NUnit.Framework;
    using Shouldly;

    [TestClass]
    internal sealed class DoubleBufferTests
    {
        [Test]
        public void ShouldCreateInstanceWithGeneratedCommonIndexes()
        {
            // Given
            var capacityA = 10;
            var capacityB = 20;
            Action action = () => new DoubleBuffer<int>(capacityA, capacityB);

            // Then
            action.ShouldNotThrow();
        }

        [Test]
        public void ShouldCreateInstanceWithCustomCommonIndexes()
        {
            // Given
            var capacityA = 10;
            var capacityB = 20;
            var aIndexes = new []{1, 3, 6, 8};
            var bIndexes = new[] {4, 5, 10, 14};
            Action action = () => new DoubleBuffer<int>(capacityA, capacityB, aIndexes, bIndexes);

            // Then
            action.ShouldNotThrow();
        }

        [TestCase(0, 0)]
        [TestCase(0, 1)]
        [TestCase(1, 0)]
        [TestCase(-1, -1)]
        [TestCase(1, -1)]
        [TestCase(-1, 1)]
        public void ShouldNotCreateInstanceWithGeneratedCommonIndexes(int capacityA, int capacityB)
        {
            // Given
            Action action = () => new DoubleBuffer<int>(capacityA, capacityB);

            // Then
            action.ShouldThrow<ArgumentException>();
        }

        [TestCase(2, 4, new []{0, 2}, new []{0, 1})]
        [TestCase(2, 4, new []{0, 1}, new []{0, 10})]
        [TestCase(2, 4, new []{0, 1, 2}, new []{0, 1, 2})]
        public void ShouldNotCreateInstanceWithIncorrectCustomCommonIndexes(int capacityA, int capacityB, int[] aIndexes, int[] bIndexes)
        {
            // Given
            Action action = () => new DoubleBuffer<int>(capacityA, capacityB, aIndexes, bIndexes);

            action.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [TestCase(2, 4, new []{0, 1, 2}, new []{0, 1})]
        [TestCase(2, 4, new []{0, 1}, new []{0, 1, 2})]
        public void ShouldNotCreateInstanceWithCustomCommonIndexesWithInvalidSize(int capacityA, int capacityB, int[] aIndexes, int[] bIndexes)
        {
            // Given
            Action action = () => new DoubleBuffer<int>(capacityA, capacityB, aIndexes, bIndexes);

            action.ShouldThrow<ArgumentException>();
        }
    }
}