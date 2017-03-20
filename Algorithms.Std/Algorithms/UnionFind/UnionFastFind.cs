using Algorithms.Std.Interfaces;

namespace Algorithms.Std.Algorithms.UnionFind
{
    public sealed class UnionFastFind : IUnionFind
    {
        private readonly int[] _id;

        public UnionFastFind(int n)
        {
            Count = n;
            _id = new int[n];
            for (var i = 0; i < n; ++i)
            {
                _id[i] = i;
            }
        }


        public void Union(int p, int q)
        {
            var pId = Find(p);
            var qId = Find(q);

            if (pId == qId)
            {
                return;
            }

            for (var i = 0; i < _id.Length; i++)
            {
                if (_id[i] == pId)
                {
                    _id[i] = qId;
                }
            }

            Count--;
        }

        public int Find(int p)
        {
            return _id[p];
        }

        public bool Connected(int p, int q)
        {
            return Find(p) == Find(q);
        }

        public int Count { get; private set; }
    }
}