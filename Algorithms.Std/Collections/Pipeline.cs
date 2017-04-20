namespace Algorithms.Std.Collections
{
    using global::Algorithms.Std.Interfaces;
    internal sealed class Pipeline<T> : IPipeline<T>
    {
        public T Push(int T)
        {
            throw new System.NotImplementedException();
        }

        public T this[int index]
        {
            get { throw new System.NotImplementedException(); }
            set { throw new System.NotImplementedException(); }
        }
    }
}