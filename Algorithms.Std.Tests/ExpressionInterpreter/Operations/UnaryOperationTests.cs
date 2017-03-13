using System;
using Algorithms.Std.ExpressionInterpreter;
using Algorithms.Std.ExpressionInterpreter.Operations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Shouldly;

namespace Algorithms.Std.Tests.ExpressionInterpreter.Operations
{
    [TestClass]
    public class UnaryOperationTests
    {
        [Test]
        public void ShouldSqrt()
        {
            // Given
            var context = new ExpressionContext();
            var operand = 2246;
            context.AddValue(operand);
            var operation = new UnaryOperation(Math.Sqrt);
            context.AddOperation(operation);

            var expectedResult = Math.Sqrt(operand);
            // When
            var result = operation.Evaluate(context);

            // Then
            result.ShouldBe(expectedResult);
        }
    }
}