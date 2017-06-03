using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Algorithms.Std.Extensions;
using Algorithms.Std.Interfaces;
using MiscUtil.Collections;

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

        public void AddAfter(Node<T> srcNode, Node<T> newNode)
        {
            var next = srcNode.Next;
            srcNode.Next = newNode;
            newNode.Next = next;
        }
        
        public void AddAfter(Node<T> srcNode, T value)
        {
            var next = srcNode.Next;
            srcNode.Next = new Node<T>(){Item = value, Next = next};
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

        public void Sort()
        {
            Sort(Comparer<T>.Default);
        }
        
        public void Sort<TKey>(Func<T, TKey> keySelector)
        {
            var comparer = ProjectionComparer<T>.Create(keySelector);
            Sort(comparer);
        }
        
        public void Sort(IComparer<T> comparer)
        {
            if (Size < 2)
            {
                return;
            }

            _first = SortInternal(_first, comparer, Size);
        }

        private Node<T> SortInternal(Node<T> node, IComparer<T> comparer, int size)
        {
            if (size < 2)
            {
                return node;
            }

            var leftSize = size / 2;
            var rightSize = size / 2 + size % 2;
            var oldHead = node;
            var newHead = Split(node, size);

            var left = SortInternal(oldHead, comparer, leftSize);
            var right = SortInternal(newHead, comparer, rightSize);
            return Merge(left, right, comparer);
        }

        private Node<T> Split(Node<T> node, int size)
        {
            var splitTail = node;
            var counter = 0;

            while (counter < size / 2)
            {
                splitTail = node;
                node = node.Next;
                counter++;
            }
            
            var newHead = splitTail.Next;
            splitTail.Next = null;
            
            return newHead;
        }

        private Node<T> Merge(Node<T> left, Node<T> right, IComparer<T> comp)
        {
            Node<T> result = null;

            if (left == null)
            {
                return right;
            }
            if (right == null)
            {
                return left;
            }
            if (comp.Less(left.Item, right.Item))
            {
                result = left;
                result.Next = Merge(left.Next, right, comp);
            }
            else
            {
                result = right;
                result.Next = Merge(left, right.Next, comp);
            }

            return result;
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
