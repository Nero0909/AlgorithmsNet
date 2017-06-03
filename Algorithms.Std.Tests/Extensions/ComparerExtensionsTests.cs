using System.Collections.Generic;
using Algorithms.Std.Extensions;
using FluentAssertions;
using NUnit.Framework;
using Ploeh.AutoFixture.NUnit3;

namespace Algorithms.Std.Tests.Extensions
{
    [TestFixture]
    public class ComparerExtensionsTests
    {
        [Test, AutoData]
        public void ShouldCompareLess(int first, int second)
        {
            // Given
            var comparer = Comparer<int>.Default;
            var expectedResult = first < second;
            
            // When
            var result = comparer.Less(first, second);
            
            // Then
            result.Should().Be(expectedResult);
        }
        
        [Test, AutoData]
        public void ShouldCompareGreater(int first, int second)
        {
            // Given
            var comparer = Comparer<int>.Default;
            var expectedResult = first > second;
            
            // When
            var result = comparer.Greater(first, second);
            
            // Then
            result.Should().Be(expectedResult);
        }
        
        [Test, AutoData]
        public void ShouldCompareEqual(int first, int second)
        {
            // Given
            var comparer = Comparer<int>.Default;
            var expectedResult = first == second;
            
            // When
            var result = comparer.Equal(first, second);
            
            // Then
            result.Should().Be(expectedResult);
        }
    }
}