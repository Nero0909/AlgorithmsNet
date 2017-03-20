using System.Collections;
using System.Collections.Generic;

namespace Algorithms.Std.Interfaces
{
    public interface IRandomBag<T> : IEnumerable<T>
    {
        bool IsEmpty { get; }

        int Size { get; }

        void Add(T item);
    }
}