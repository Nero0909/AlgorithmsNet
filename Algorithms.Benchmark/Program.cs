using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Benchmark.Algorithms;
using Algorithms.Benchmark.Collections;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;

namespace Algorithms.Benchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            //var stackSum = BenchmarkRunner.Run<StackBenchmark>();
            var uf = BenchmarkRunner.Run<UnionFindBenchmarks>();
        }
    }
}
