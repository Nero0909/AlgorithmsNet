using Algorithms.Std.Interfaces;

namespace Algorithms.Std.Algorithms.UnionFind
{
    public class CompressedFastUnionFind : IUnionFind
    {
        private readonly int[] _id;
        private readonly int[] _sizes;

        public CompressedFastUnionFind(int n)
        {
            Count = n;
            _id = new int[n];
            _sizes = new int[n];

            for (var i = 0; i < n; i++)
            {
                _id[i] = i;
                _sizes[i] = 1;
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

            if (_sizes[pRoot] < _sizes[qRoot])
            {
                _id[pRoot] = qRoot;
                _sizes[qRoot] += _sizes[pRoot];
            }
            else
            {
                _id[qRoot] = pRoot;
                _sizes[pRoot] += _sizes[qRoot];
            }
            Count--;
        }

        public int Find(int p)
        {
            var root = p;
            while (root != _id[root])
            {
                root = _id[root];
            }

            while (p != _id[p])
            {
                p = _id[p];
                _id[p] = root;
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