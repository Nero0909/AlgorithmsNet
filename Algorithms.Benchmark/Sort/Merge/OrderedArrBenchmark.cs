namespace Algorithms.Benchmark.Sort.Merge
{
    using System.Linq;
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Attributes.Jobs;
    using global::Algorithms.Std.Extensions;
    using global::Algorithms.Std.Sort;

    [LegacyJitX64Job]
    public class OrderedArrBenchmark
    {
        private const int Capacity = 100000;
        private int[] _testArray;

        [Setup]
        public void SetupData()
        {
            //Random.SetSeed(DateTime.Now.Millisecond);
            _testArray = Enumerable.Range(0, Capacity).ToArray();
        }

        [Benchmark]
        public void MergeSort()
        {
            var arr = _testArray.ToArray();
            Merge.Sort(arr);
        }

        [Benchmark]
        public void ImprovementMergeSort()
        {
            var arr = _testArray.ToArray();
            MergeOrderedArrImprovement.Sort(arr);
        }
    }
}