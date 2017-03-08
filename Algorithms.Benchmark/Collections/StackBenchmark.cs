using Algorithms.Std.Collections;
using BenchmarkDotNet.Attributes;

namespace Algorithms.Benchmark.Collections
{
    public class StackBenchmark
    {
        private readonly int operationsCount;

        public StackBenchmark()
        {
            operationsCount = 200000;
        }

        [Benchmark]
        public void ArrayStackPush()
        {
            var stack = new ArrayStack<int>();

            for (var i = 0; i < operationsCount; ++i)
            {
                stack.Push(i);
            }
        }

        [Benchmark]
        public void ListStackPush()
        {
            var stack = new ListStack<int>();

            for (var i = 0; i < operationsCount; ++i)
            {
                stack.Push(i);
            }
        }
    }
}
