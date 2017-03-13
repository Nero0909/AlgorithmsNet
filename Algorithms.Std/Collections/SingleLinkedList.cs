using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Std.Interfaces;

namespace Algorithms.Std.Collections
{
    public class SingleLinkedList<T> : ILinkedList<T>
    {
        private Node<T> _first;

        public Node<T> First
        {
            get { return _first; }
        }

        public bool IsEmpty => Size == 0;

        public int Size { get; private set; }

        public void AddFirst(T item)
        {
            var oldFirst = _first;
            _first = new Node<T>() { Item = item, Next = oldFirst };
            Size++;
        }

        public bool Find(T item)
        {
            return this.Contains(item);
        }

        public T Max()
        {
            if (_first == null)
            {
                return default(T);
            }

            return Max(_first, _first.Item, Comparer<T>.Default);
        }

        private T Max(Node<T> node, T curMax, IComparer<T> comparer)
        {
            if (node.Next == null)
            {
                return curMax;
            }

            if (comparer.Compare(curMax, node.Next.Item) < 0)
            {
                curMax = node.Next.Item;
            }

            return Max(node.Next, curMax, comparer);
        }

        public void Reverse()
        {
            var first = _first;
            Node<T> reverse = null;

            while (first != null)
            {
                var second = first.Next;
                first.Next = reverse;
                reverse = first;
                first = second;
            }

            _first = reverse;
        }

        public void ReverseRecursive()
        {
            _first = ReverseRecursive(_first);
        }

        private Node<T> ReverseRecursive(Node<T> first)
        {
            if (first == null)
            {
                return null;
            }

            if (first.Next == null)
            {
                return first;
            }

            var second = first.Next;
            var reverse = ReverseRecursive(second);
            second.Next = first;
            first.Next = null;

            return reverse;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (var node = _first; node != null; node = node.Next)
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
