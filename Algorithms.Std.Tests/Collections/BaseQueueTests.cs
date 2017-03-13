using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Algorithms.Std.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace Algorithms.Std.Tests.Collections
{
    [TestClass]
    public abstract class BaseQueueTests
    {
        [Test]
        public void ShouldEnqueue()
        {
            // Given
            var capacity = 10;
            var queue = GetQueue<int>();
            var expectedList = Enumerable.Range(0, capacity).ToList();

            // When
            for (int i = 0; i < capacity; i++)
            {
                queue.Enqueue(i);
            }

            // Then
            queue.Size.ShouldBe(capacity);
            using (var listIterator = expectedList.GetEnumerator())
            {
                listIterator.MoveNext();
                foreach (var item in queue)
                {
                    item.ShouldBe(listIterator.Current);
                    listIterator.MoveNext();
                }
                queue.Size.ShouldBe(capacity);
            }
        }

        [Test]
        public void ShouldDeque()
        {
            // Given
            var expectedResult = "Result";
            var queue = GetQueue<string>();

            // When
            queue.Enqueue(expectedResult);
            queue.Enqueue("some string");
            var result = queue.Dequeue();

            // Then
            queue.Size.ShouldBe(1);
            result.ShouldBe(expectedResult);
        }

        [Test]
        public void ShouldDequeWithOneElement()
        {
            // Given
            var expectedResult = "Result";
            var queue = GetQueue<string>();

            // When
            queue.Enqueue(expectedResult);
            var result = queue.Dequeue();

            // Then
            queue.Size.ShouldBe(0);
            result.ShouldBe(expectedResult);
        }

        [Test]
        public void ShouldThrowIfEmpty()
        {
            // Given
            var queue = GetQueue<string>();
            Action action = () => queue.Dequeue();

            // Then
            action.ShouldThrow<InvalidOperationException>();
        }

        protected abstract IQueue<T> GetQueue<T>();
    }
}
