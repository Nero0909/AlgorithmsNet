using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Algorithms.Std.Algorithms.UnionFind;
using BenchmarkDotNet.Attributes;

namespace Algorithms.Benchmark.Algorithms
{
    public class UnionFindBenchmarks
    {
        private readonly int _nodesCount;
        private readonly List<Connection> _values;

        public UnionFindBenchmarks()
        {
            var fileName = "mediumUF.txt";
            var testFile = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"..\..\..\TestData\" + fileName;
            using (var sr = new StreamReader(testFile))
            {
                var nodesCountStr = sr.ReadLine();
                if (nodesCountStr == null)
                {
                    return;
                }

                _nodesCount = int.Parse(nodesCountStr);
                _values = new List<Connection>(_nodesCount);

                var line = string.Empty;
                while ((line = sr.ReadLine()) != null)
                {
                    var pq = Regex.Split(line, @"\W+").Select(int.Parse).ToArray();
                    _values.Add(new Connection(pq[0], pq[1]));
                }
            }
        }

        [Benchmark]
        public void FastUnionFind()
        {
            var uf = new FastUnionFind(_nodesCount);

            foreach (var pq in _values)
            {
                uf.Union(pq.P, pq.Q);
            }
        }

        [Benchmark]
        public void UnionFastFind()
        {
            var uf = new UnionFastFind(_nodesCount);

            foreach (var pq in _values)
            {
                uf.Union(pq.P, pq.Q);
            }
        }

        [Benchmark]
        public void WeightedFastUnionFind()
        {
            var uf = new WeightedFastUnionFind(_nodesCount);

            foreach (var pq in _values)
            {
                uf.Union(pq.P, pq.Q);
            }
        }

        [Benchmark]
        public void CompressedFastUnionFind()
        {
            var uf = new CompressedFastUnionFind(_nodesCount);

            foreach (var pq in _values)
            {
                uf.Union(pq.P, pq.Q);
            }
        }
    }
}