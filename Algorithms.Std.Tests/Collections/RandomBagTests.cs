using System;
using System.Collections.Generic;
using System.Linq;
using Algorithms.Std.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Shouldly;

namespace Algorithms.Std.Tests.Collections
{
    [TestClass]
    public class RandomBagTests
    {
        [Test]
        public void ShouldEnumerateThroughBag()
        {
            // Given
            var operationsCount = 50;
            var capacity = 50;
            var bag = new RandomBag<int>();
            var masterList = Enumerable.Range(0, capacity).ToList();

            // When
            foreach (var item in masterList)
            {
                bag.Add(item);
            }

            // Then
            for (var i = 0; i < operationsCount; i++)
            {
                var actualList = bag.ToList();
                actualList.ShouldNotBe(masterList);
            }
        }

        [Test]
        public void ShouldEnumerateThroughEmptyBag()
        {
            // Given
            var bag = new RandomBag<int>();

            // When
            var result = bag.ToArray();

            // Then
            result.Length.ShouldBe(0);
        }

        [Test]
        public void ShouldAdd()
        {
            // Given
            var operations = 50;
            var bag = new RandomBag<int>();

            // When
            for (int i = 0; i < operations; i++)
            {

            }
        }
    }
}