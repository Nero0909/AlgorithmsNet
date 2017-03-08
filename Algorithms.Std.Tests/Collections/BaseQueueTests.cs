using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Std.Collections;
using Algorithms.Std.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace Algorithms.Std.Tests.Collections
{
    [TestClass]
    public abstract class BaseQueueTests
    {
        [TestMethod]
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
        [TestMethod]
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

        [TestMethod]
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
