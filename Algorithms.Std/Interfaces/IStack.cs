using System.Collections.Generic;

namespace Algorithms.Std.Interfaces
{
    public interface IStack<T> : IEnumerable<T>
    {
        bool IsEmpty { get; }

        int Size { get; }

        void Push(T item);

        T Pop();
    }
}