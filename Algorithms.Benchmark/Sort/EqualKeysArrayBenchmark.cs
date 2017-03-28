namespace Algorithms.Benchmark.Sort
{
    using System.Linq;
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Attributes.Jobs;
    using global::Algorithms.Std.Extensions;
    using global::Algorithms.Std.Sort;

    [LegacyJitX64Job]
    public class EqualKeysArrayBenchmark
    {
        private const int Capacity = 1000;
        private readonly int[] _testArray;

        public EqualKeysArrayBenchmark()
        {
            //Random.SetSeed(DateTime.Now.Millisecond);
            _testArray = Enumerable.Repeat(0, Capacity / 2).Concat(Enumerable.Repeat(1, Capacity / 2)).ToArray();
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
    }
}