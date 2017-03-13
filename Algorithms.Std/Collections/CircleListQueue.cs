using System;
using System.Collections;
using System.Collections.Generic;
using Algorithms.Std.Helpers;
using Algorithms.Std.Interfaces;

namespace Algorithms.Std.Collections
{
    public class CircleListQueue<T> : IQueue<T>
    {
        private Node<T> last;

        public bool IsEmpty => Size == 0;

        public int Size { get; private set; }

        public T Dequeue()
        {
            if (IsEmpty)
            {
                ThrowHelper.ThrowInvalidOperationException("Queue is empty.");
            }

            var item = last.Next.Item;
            last.Next = last.Next.Next;

            Size--;
            if (IsEmpty)
            {
                last = null;
            }

            return item;
        }

        public void Enqueue(T item)
        {
            var oldLast = last;
            last = new Node<T> { Item = item, Next = null };
            if (IsEmpty)
            {
                last.Next = last;
            }
            else
            {
                last.Next = oldLast.Next;
                oldLast.Next = last;
            }

            Size++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var isFirstNode = true;
            for (var node = last.Next; node != node.Next && isFirstNode; node = node.Next)
            {
                isFirstNode = false;

                yield return node.Item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
