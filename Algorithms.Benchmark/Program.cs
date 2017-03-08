using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Benchmark.Collections;
using BenchmarkDotNet.Running;

namespace Algorithms.Benchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            var stackSum = BenchmarkRunner.Run<StackBenchmark>();
        }
    }
}
