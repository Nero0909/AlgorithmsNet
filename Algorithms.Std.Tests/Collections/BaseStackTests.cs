using System;
using System.Linq;
using Algorithms.Std.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Shouldly;

namespace Algorithms.Std.Tests.Collections
{
    [TestClass]
    public abstract class BaseStackTests
    {
        [Test]
        public void ShouldPush()
        {
            // Given
            var capacity = 10;
            var stack = GetStack<int>();
            var expectedList = Enumerable.Range(0, capacity).Reverse().ToList();

            // When
            for (int i = 0; i < capacity; i++)
            {
                stack.Push(i);
            }

            // Then
            stack.Size.ShouldBe(capacity);
            using (var listIterator = expectedList.GetEnumerator())
            {
                listIterator.MoveNext();
                foreach (var item in stack)
                {
                    item.ShouldBe(listIterator.Current);
                    listIterator.MoveNext();
                }

                stack.Size.ShouldBe(capacity);
            }
        }

        [Test]
        public void ShouldPop()
        {
            // Given
            var expectedResult = "Result";
            var stack = GetStack<string>();

            // When
            stack.Push("123");
            stack.Push(expectedResult);
            var result = stack.Pop();

            // Then
            stack.Size.ShouldBe(1);
            result.ShouldBe(expectedResult);
        }

        [Test]
        public void ShouldThrowIfEmpty()
        {
            // Given
            var stack = GetStack<int>();
            Action action = () => stack.Pop();

            // Then
            action.ShouldThrow<InvalidOperationException>();
        }

        protected abstract IStack<T> GetStack<T>();
    }
}