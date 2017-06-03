using System.Collections.Generic;
using Algorithms.Std.Extensions;
using FluentAssertions;
using NUnit.Framework;

namespace Algorithms.Std.Tests.Extensions
{
    [TestFixture]
    public class ListExtensionsTests
    {
        [Test]
        public void ShouldSwap()
        {
            // Given
            var arr = new int[] {0, 1, 2};
            
            var firstEl = arr[0];
            var secondEl = arr[1];
            
            // When
            arr.Swap(0, 1);
            
            // Then
            arr[0].Should().Be(secondEl);
            arr[1].Should().Be(firstEl);
        }
    }
}