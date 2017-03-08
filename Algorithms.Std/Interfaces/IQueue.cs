using System.Collections.Generic;

namespace Algorithms.Std.Interfaces
{
    public interface IQueue<T> : IEnumerable<T>
    {
        bool IsEmpty { get; }

        int Size { get; }

        T Dequeue();

        void Enqueue(T item);
    }
}