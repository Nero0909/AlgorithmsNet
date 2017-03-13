using Algorithms.Std.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Shouldly;

namespace Algorithms.Std.Tests.Tasks
{
    [TestClass]
    public class QueueTasksTests
    {
        [Test]
        public void ShouldJosephTask()
        {
            // Given
            var N = 7;
            var M = 2;
            var expectedResult = "1 3 5 0 4 2 6";

            // When
            var result = QueueTasks.JosephTask(N, M);

            // Then
            result.ShouldBe(expectedResult);
        }
    }
}