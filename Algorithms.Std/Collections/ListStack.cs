using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Algorithms.Std.Helpers;
using Algorithms.Std.Interfaces;

namespace Algorithms.Std.Collections
{
    public class ListStack<T> : IStack<T>
    {
        private Node<T> first;

        public bool IsEmpty => Size == 0;

        public int Size { get; private set; }

        public void Push(T item)
        {
            var oldFirst = first;
            first = new Node<T>() {Item = item, Next = oldFirst};
            Size++;
        }

        public T Pop()
        {
            if (first == null)
            {
                ThrowHelper.ThrowInvalidOperationException("Stack is empty.");
            }

            var item = first.Item;
            first = first.Next;
            Size--;

            return item;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (var node = first; node != null; node = node.Next)
            {
                yield return node.Item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
