using System.Collections.Generic;
using Algorithms.Std.Collections;

namespace Algorithms.Std.Interfaces
{
    public interface ILinkedList<T> : IEnumerable<T>
    {
        Node<T> First { get; }

        int Size { get; }

        void AddFirst(T item);

        T Max();

        bool Find(T item);

        void Reverse();

        void ReverseRecursive();
    }
}