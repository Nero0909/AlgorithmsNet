using Algorithms.Std.ExpressionInterpreter;
using Algorithms.Std.ExpressionInterpreter.Operations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace Algorithms.Std.Tests.ExpressionInterpreter.Operations
{
    [TestClass]
    public class BinaryOperationTests
    {
        [TestMethod]
        public void ShouldAdd()
        {
            // Given
            var context = new ExpressionContext();
            var left = 10.0;
            var right = 25.0;
            context.AddValue(left);
            context.AddValue(right);
            var operation = new BinaryOperation((l, r) => l + r);
            context.AddOperation(operation);

            var expectedResult = left + right;

            // When
            var result = operation.Calculate(context);

            // Then
            result.ShouldBe(expectedResult);
        }

        [TestMethod]
        public void ShouldSub()
        {
            // Given
            var context = new ExpressionContext();
            var left = 10.0;
            var right = 25.0;
            context.AddValue(left);
            context.AddValue(right);
            var operation = new BinaryOperation((l, r) => l - r);
            context.AddOperation(operation);

            var expectedResult = left - right;

            // When
            var result = operation.Calculate(context);

            // Then
            result.ShouldBe(expectedResult);
        }

        [TestMethod]
        public void ShouldMul()
        {
            // Given
            var context = new ExpressionContext();
            var left = 10.0;
            var right = 25.0;
            context.AddValue(left);
            context.AddValue(right);
            var operation = new BinaryOperation((l, r) => l * r);
            context.AddOperation(operation);

            var expectedResult = left * right;

            // When
            var result = operation.Calculate(context);

            // Then
            result.ShouldBe(expectedResult);
        }

        [TestMethod]
        public void ShouldDiv()
        {
            // Given
            var context = new ExpressionContext();
            var left = 10.0;
            var right = 25.0;
            context.AddValue(left);
            context.AddValue(right);
            var operation = new BinaryOperation((l, r) => l / r);
            context.AddOperation(operation);

            var expectedResult = left / right;

            // When
            var result = operation.Calculate(context);

            // Then
            result.ShouldBe(expectedResult);
        }
    }
}