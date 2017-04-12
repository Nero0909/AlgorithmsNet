using System;
using System.Linq;
using Algorithms.Std.Extensions;
using Algorithms.Std.Sort;
using BenchmarkDotNet.Attributes;
using Random = Algorithms.Std.Random;

namespace Algorithms.Benchmark.Sort
{
    using BenchmarkDotNet.Attributes.Jobs;

    [LegacyJitX64Job]
    public class RandomUniqueArrayBenchmark
    {
        private const int Capacity = 1000;
        private int[] _testArray;

        [Setup]
        public void SetupData()
        {
            //Random.SetSeed(DateTime.Now.Millisecond);
            _testArray = Enumerable.Range(0, Capacity).ToArray();
            _testArray.Shuffle();
        }

        [Benchmark]
        public void SelectionSort()
        {
            var arr = _testArray.ToArray();
            Selection.Sort(arr);
        }

        [Benchmark]
        public void InsertionSort()
        {
            var arr = _testArray.ToArray();
            Insertion.Sort(arr);
        }

        [Benchmark]
        public void InsertionSortOptimised()
        {
            var arr = _testArray.ToArray();
            Insertion.SortOptimised(arr);
        }

        [Benchmark]
        public void ShellSort()
        {
            var arr = _testArray.ToArray();
            Shell.Sort(arr);
        }

        [Benchmark]
        public void BCLSort()
        {
            var arr = _testArray.ToArray();
            Array.Sort(arr);
        }
    }
}