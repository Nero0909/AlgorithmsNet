using System;
using Algorithms.Std.Helpers;

namespace Algorithms.Std.ExpressionInterpreter.Operations
{
    public class BinaryOperation : Operation
    {
        private readonly Func<double, double, double> binaryOperation;

        public BinaryOperation(Func<double, double, double> binaryOperation)
        {
            this.binaryOperation = binaryOperation;
        }

        public override double Evaluate(ExpressionContext context)
        {
            var rightOperand = context.GetValue();
            var leftOperand = context.GetValue();

            return binaryOperation(leftOperand, rightOperand);
        }
    }
}