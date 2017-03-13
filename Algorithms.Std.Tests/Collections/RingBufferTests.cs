using System.Collections.Generic;
using System.Linq;
using Algorithms.Std.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Shouldly;

namespace Algorithms.Std.Tests.Collections
{
    [TestClass]
    public class RingBufferTests
    {
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(10)]
        public void ShouldFillBuffer(int capacity)
        {
            // Given
            var queue = new RingBuffer<int>(capacity);

            // When
            while (queue.TryEnqueue(1)){}

            // Then
            queue.IsFull.ShouldBe(true);
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(10)]
        public void ShouldClearBuffer(int capacity)
        {
            // Given
            var queue = new RingBuffer<int>(capacity);

            // When
            while (queue.TryEnqueue(1)){}
            while (!queue.IsEmpty)
            {
                queue.Dequeue();
            }

            // Then
            queue.IsEmpty.ShouldBe(true);
        }

        [Test]
        public void ShouldDequeueHalfElements()
        {
            // Given
            var capacity = 10;
            var queue = new RingBuffer<int>(capacity);
            var sum = 0;
            var expectedSum = capacity / 2;

            // When
            while (queue.TryEnqueue(1)){}
            for (var i = 0; i < capacity / 2; ++i)
            {
                sum += queue.Dequeue();
            }

            // Then
            sum.ShouldBe(expectedSum);
            queue.Size.ShouldBe(capacity / 2);
            queue.IsEmpty.ShouldBe(false);
            queue.IsFull.ShouldBe(false);
        }

        [Test]
        public void ShouldEnqueueWithHalfCapacity()
        {
            // Given
            var capacity = 10;
            var queue = new RingBuffer<int>(capacity);
            var added = true;

            // When
            while (queue.TryEnqueue(1)){}
            for (var i = 0; i < capacity / 2; ++i)
            {
                queue.Dequeue();
            }
            for (var i = 0; i < capacity / 2 + capacity%2; ++i)
            {
                added &= queue.TryEnqueue(2);
            }

            // Then
            queue.IsFull.ShouldBe(true);
            added.ShouldBe(true);
        }

        [Test]
        public void ShouldEnumerate()
        {
            // Given
            var capacity = 10;
            var queue = new RingBuffer<int>(capacity);
            var expectedList = Enumerable.Range(capacity / 2, capacity).ToList();
            var added = true;

            // When
            var counter = 0;
            while (!queue.IsFull)
            {
                added &= queue.TryEnqueue(counter++);
            }

            for (var i = 0; i < capacity / 2; ++i)
            {
                queue.Dequeue();
            }

            while (!queue.IsFull)
            {
                added &= queue.TryEnqueue(counter++);
            }

            // Then
            added.ShouldBe(true);
            queue.Size.ShouldBe(capacity);
            queue.IsFull.ShouldBe(true);
            using (var enumerator = expectedList.GetEnumerator())
            {
                enumerator.MoveNext();
                foreach (var item in queue)
                {
                    item.ShouldBe(enumerator.Current);
                    enumerator.MoveNext();
                }
                queue.Size.ShouldBe(capacity);
            }
        }
    }
}