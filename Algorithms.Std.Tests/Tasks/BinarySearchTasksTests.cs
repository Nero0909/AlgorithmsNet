using Algorithms.Std.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Shouldly;

namespace Algorithms.Std.Tests.Tasks
{
    [TestClass]
    public class BinarySearchTasksTests
    {
        [TestCase(80, 10)]
        [TestCase(80, 80)]
        [TestCase(80, 1)]
        public void ShouldGetMinumumFloorSlow(int houseHeigh, int expectedResult)
        {
            // When
            var result = BinarySearchTasks.GetMinimumFloorSlow(houseHeigh, expectedResult);

            // Then
            result.ShouldBe(expectedResult);
        }

        [TestCase(80, 10)]
        [TestCase(80, 80)]
        [TestCase(80, 1)]
        public void ShouldGetMinumumFloorFast(int houseHeigh, int expectedResult)
        {
            // When
            var result = BinarySearchTasks.GetMinimumFloorFast(houseHeigh, expectedResult);

            // Then
            result.ShouldBe(expectedResult);
        }
    }
}