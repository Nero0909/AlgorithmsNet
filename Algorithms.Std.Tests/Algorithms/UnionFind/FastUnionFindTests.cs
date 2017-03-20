using Algorithms.Std.Algorithms.UnionFind;
using Algorithms.Std.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Std.Tests.Algorithms.UnionFind
{
    [TestClass]
    public class FastUnionFindTests : UnionFindTestsBase
    {
        public override IUnionFind GetUnionFind(int n)
        {
            return new FastUnionFind(n);
        }
    }
}