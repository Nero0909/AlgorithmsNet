using Algorithms.Std.Interfaces;

namespace Algorithms.Std.Algorithms.UnionFind
{
    public class FastUnionFind : IUnionFind
    {
        private readonly int[] _id;

        public FastUnionFind(int n)
        {
            Count = n;
            _id = new int[n];
            for (var i = 0; i < n; i++)
            {
                _id[i] = i;
            }
        }

        public void Union(int p, int q)
        {
            var pRoot = Find(p);
            var qRoot = Find(q);

            if (pRoot == qRoot)
            {
                return;
            }

            _id[pRoot] = qRoot;
            Count--;
        }

        public int Find(int p)
        {
            while (p != _id[p])
            {
                p = _id[p];
            }

            return p;
        }

        public bool Connected(int p, int q)
        {
            return Find(p) == Find(q);
        }

        public int Count { get; private set; }
    }
}