using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Std.Interfaces;
using Algorithms.Std.Helpers;

namespace Algorithms.Std.Collections
{
    public class ListQueue<T> : IQueue<T>
    {
        private Node<T> first;
        private Node<T> last;

        public bool IsEmpty => first == null;

        public int Size { get; private set; }

        public T Dequeue()
        {
            if (IsEmpty)
            {
                ThrowHelper.ThrowInvalidOperationException("Queue is empty.");
            }

            var item = first.Item;
            first = first.Next;

            if (IsEmpty)
            {
                last = null;
            }

            Size--;

            return item;
        }

        public void Enqueue(T item)
        {
            var oldLast = last;
            last = new Node<T> { Item = item, Next = null };
            if (IsEmpty)
            {
                first = last;
            }
            else
            {
                oldLast.Next = last;
            }

            Size++;
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
