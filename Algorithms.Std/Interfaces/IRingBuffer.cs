using System.Collections.Generic;

namespace Algorithms.Std.Interfaces
{
    public interface IRingBuffer<T> : IEnumerable<T>
    {
        bool IsFull { get; }

        bool IsEmpty { get; }

        int Size { get; }

        bool TryEnqueue(T item);

        T Dequeue();
    }
}