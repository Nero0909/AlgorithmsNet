using Algorithms.Std.Algorithms.UnionFind;
using Algorithms.Std.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Std.Tests.Algorithms.UnionFind
{
    [TestClass]
    public class WeightedFastUnionFindTests : UnionFindTestsBase
    {
        public override IUnionFind GetUnionFind(int n)
        {
            return new WeightedFastUnionFind(n);
        }
    }
}