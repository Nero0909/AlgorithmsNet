using System;

namespace Algorithms.Std.ExpressionInterpreter.Operations
{
    public class UnaryOperation : Operation
    {
        private readonly Func<double, double> unaryOperation;

        public UnaryOperation(Func<double, double> unaryOperation)
        {
            this.unaryOperation = unaryOperation;
        }

        public override double Evaluate(ExpressionContext context)
        {
            var operand = context.GetValue();

            return unaryOperation(operand);
        }
    }
}