using Algorithms.Std.Helpers;
using System;

namespace Algorithms.Std.ExpressionInterpreter.Operations
{
    public abstract class Operation
    {
        public abstract double Evaluate(ExpressionContext context);
    }
}