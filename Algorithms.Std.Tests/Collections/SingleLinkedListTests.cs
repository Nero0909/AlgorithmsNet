using System.Collections.Generic;
using System.Linq;
using Algorithms.Std.Collections;
using Algorithms.Std.Extensions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Shouldly;

namespace Algorithms.Std.Tests.Collections
{
    [TestClass]
    public class SingleLinkedListTests
    {
        [Test]
        public void ShouldAppend()
        {
            // Given
            var capacity = 10;
            var linkedList = new SingleLinkedList<string>();
            var expectedList = Enumerable.Range(0, capacity).Select(x => x.ToString()).Reverse().ToList();

            // When
            for (int i = 0; i < capacity; i++)
            {
                linkedList.AddFirst(i.ToString());
            }

            // Then
            linkedList.ShouldBeEquivalentTo(expectedList, options => options.WithStrictOrdering());
        }

        [Test]
        public void ShouldFind()
        {
            // Given
            var list = new SingleLinkedList<string>();
            var expectedValue = "value";

            // When
            list.AddFirst(expectedValue);
            var result = list.Find(expectedValue);

            // Then
            result.ShouldBe(true);
        }

        [Test]
        public void ShouldGetMaxWithOneElement()
        {
            // Given
            var list = new SingleLinkedList<double>();
            var max = 80;

            // When
            list.AddFirst(max);
            var result = list.Max();

            // Then
            result.ShouldBe(max);
        }

        [Test]
        public void ShouldGetFirstMax()
        {
            // Given
            var list = new SingleLinkedList<double>();
            var max = 80;

            // When
            list.AddFirst(0);
            list.AddFirst(23);
            list.AddFirst(56);
            list.AddFirst(3);
            list.AddFirst(1);
            list.AddFirst(max);
            var result = list.Max();

            // Then
            result.ShouldBe(max);
        }

        [Test]
        public void ShouldGetLastMax()
        {
            // Given
            var list = new SingleLinkedList<double>();
            var max = 80;

            // When
            list.AddFirst(max);
            list.AddFirst(23);
            list.AddFirst(56);
            list.AddFirst(3);
            list.AddFirst(1);
            list.AddFirst(34);
            var result = list.Max();

            // Then
            result.ShouldBe(max);
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(10)]
        public void ShouldReverse(int capacity)
        {
            // Given
            var list = new SingleLinkedList<int>();
            var expectedList = Enumerable.Range(0, capacity).ToList();

            // When
            for (var i = 0; i < capacity; ++i)
            {
                list.AddFirst(i);
            }
            list.Reverse();

            // Then
            list.ShouldBeEquivalentTo(expectedList, options => options.WithStrictOrdering());
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(10)]
        public void ShouldReverseRecursive(int capacity)
        {
            // Given
            var list = new SingleLinkedList<int>();
            var expectedList = Enumerable.Range(0, capacity).ToList();

            // When
            for (var i = 0; i < capacity; ++i)
            {
                list.AddFirst(i);
            }
            list.ReverseRecursive();

            // Then
            list.ShouldBeEquivalentTo(expectedList, options => options.WithStrictOrdering());
        }

        [Test]
        public void ShouldSort()
        {
            // Given
            var capacity = 50;
            var list = new SingleLinkedList<int>();
            var expectedList = Enumerable.Range(0, capacity).ToArray();
            var randomNumbers = expectedList.ToArray();
            randomNumbers.Shuffle();

            foreach (var number in randomNumbers)
            {
                list.AddFirst(number);
            }
            
            // When
            list.Sort();
            
            // Then
            list.ShouldBeEquivalentTo(expectedList, options => options.WithStrictOrdering());
        }
        
        [Test]
        public void ShouldSortWithComparer()
        {
            // Given
            var capacity = 50;
            var list = new SingleLinkedList<KeyValuePair<int, string>>();
            var expectedList = Enumerable.Range(0, capacity)
                .Select(x => new KeyValuePair<int, string>(x, x.ToString()))
                .ToArray();
            var randomNumbers = expectedList.ToArray();
            randomNumbers.Shuffle();

            foreach (var number in randomNumbers)
            {
                list.AddFirst(number);
            }
            
            // When
            list.Sort(x => x.Key);
            
            // Then
            list.ShouldBeEquivalentTo(expectedList, options => options.WithStrictOrdering());
        }
    }
}