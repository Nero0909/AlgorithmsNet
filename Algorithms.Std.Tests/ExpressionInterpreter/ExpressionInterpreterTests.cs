using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Shouldly;

namespace Algorithms.Std.Tests.ExpressionInterpreter
{
    [TestClass]
    public class ExpressionInterpreterTests
    {
        [TestCase("( 1 + ( ( 2 + 3 ) * ( 4 * 5 ) ) )", 101.0)]
        [TestCase("( ( 1 + sqrt ( 4.0 ) ) / ( 2.0 )", 1.5)]
        public void ShouldInterpret(string expression, double expectedResult)
        {
            // Given
            var interpreter = new Std.ExpressionInterpreter.ExpressionInterpreter();

            // When
            var result = interpreter.Interpret(expression);

            // Then
            result.ShouldBe(expectedResult);
        }
    }
}