using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Benchmark.Algorithms;
using Algorithms.Benchmark.Collections;
using Algorithms.Benchmark.Sort;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;

namespace Algorithms.Benchmark
{
    using global::Algorithms.Benchmark.Sort.Merge;

    class Program
    {
        static void Main(string[] args)
        {
            //var stackSum = BenchmarkRunner.Run<StackBenchmark>();
            //BenchmarkRunner.Run<UnionFindBenchmarks>();
            //var sort = BenchmarkRunner.Run<RandomUniqueArrayBenchmark>();
            //var sort = BenchmarkRunner.Run<EqualKeysArrayBenchmark>();
            //var sort = BenchmarkRunner.Run<OrderedArrBenchmark>();
            //BenchmarkRunner.Run<SimpleVsNotStableBenchmark>();
            BenchmarkRunner.Run<SimpleVsOptimisedBenchmark>();
        }
    }
}
