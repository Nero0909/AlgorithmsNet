using System;
using System.Globalization;
using Algorithms.Std.ExpressionInterpreter.Operations;

namespace Algorithms.Std.ExpressionInterpreter
{
    public class ExpressionInterpreter
    {
        public double Interpret(string expression)
        {
            var context = new ExpressionContext();

            foreach (var str in expression.Split(' '))
            {
                if (str.Equals("("))
                {
                    continue;
                }

                if (str.Equals("+"))
                {
                    context.AddOperation(new BinaryOperation((l, r) => l + r));
                }
                else if (str.Equals("-"))
                {
                    context.AddOperation(new BinaryOperation((l, r) => l - r));
                }
                else if (str.Equals("*"))
                {
                    context.AddOperation(new BinaryOperation((l, r) => l * r));
                }
                else if (str.Equals("/"))
                {
                    context.AddOperation(new BinaryOperation((l, r) => l / r));
                }
                else if (str.Equals("sqrt"))
                {
                    context.AddOperation(new UnaryOperation(Math.Sqrt));
                }
                else if (str.Equals(")"))
                {
                    var operation = context.GetOperation();
                    var result = operation.Evaluate(context);
                    context.AddValue(result);
                }
                else
                {
                    var result = Convert.ToDouble(str, CultureInfo.InvariantCulture);
                    context.AddValue(result);
                }
            }

            return context.GetValue();
        }
    }
}