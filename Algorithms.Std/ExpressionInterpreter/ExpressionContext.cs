using Algorithms.Std.Collections;
using Algorithms.Std.ExpressionInterpreter.Operations;
using Algorithms.Std.Interfaces;

namespace Algorithms.Std.ExpressionInterpreter
{
    public class ExpressionContext
    {
        private readonly IStack<Operation> operations;
        private readonly IStack<double> values;

        public ExpressionContext()
        {
            operations = new ArrayStack<Operation>(10);
            values = new ArrayStack<double>(10);
        }

        public void AddOperation(Operation operation)
        {
            operations.Push(operation);
        }

        public void AddValue(double value)
        {
            values.Push(value);
        }

        public Operation GetOperation()
        {
            return operations.Pop();
        }

        public double GetValue()
        {
            return values.Pop();
        }
    }
}