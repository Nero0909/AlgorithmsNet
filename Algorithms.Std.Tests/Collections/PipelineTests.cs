namespace Algorithms.Std.Tests.Collections
{
    using System;
    using System.Linq;
    using global::Algorithms.Std.Collections;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NUnit.Framework;
    using Shouldly;

    [TestClass]
    internal sealed class PipelineTests
    {
        [Test]
        public void ShouldCreateInstance()
        {
            // Given
            var capacity = 20;
            Action action = () => new Pipeline<int>(capacity);

            // Then
            action.ShouldNotThrow();
        }

        [Test]
        public void ShouldPush()
        {
            // Given
            var capacity = 10;
            var iterationsCount = 100;
            var pipe = new Pipeline<int>(capacity);
            var actualArray = new int[iterationsCount];
            var expectedArray = Enumerable.Range(0, iterationsCount).ToArray();

            // When
            for (var i = 0; i < iterationsCount; i++)
            {
                pipe.Push(i);
                actualArray[i] = pipe[0];
            }

            // Then
            actualArray.ShouldBe(expectedArray);
        }
    }
}