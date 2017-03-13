using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Std.Helpers;
using Algorithms.Std.Interfaces;

namespace Algorithms.Std.Collections
{
    public class ArrayStack<T> : IStack<T>
    {
        private T[] _innerArr;

        public bool IsEmpty => Size == 0;

        public int Size { get; private set; }

        public ArrayStack()
        {
            _innerArr = new T[4];
            Size = 0;
        }

        public ArrayStack(int capacity)
        {
            _innerArr = new T[capacity];
            Size = 0;
        }

        public void Push(T item)
        {
            if (_innerArr.Length == Size)
            {
                Resize(_innerArr.Length * 2);
            }

            _innerArr[Size++] = item;
        }

        public T Pop()
        {
            if (Size == 0)
            {
                ThrowHelper.ThrowInvalidOperationException("Stack is empty.");
            }

            var item = _innerArr[--Size];
            _innerArr[Size] = default(T);
            return item;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ReverseArrayIterator(Size);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private IEnumerator<T> ReverseArrayIterator(int size)
        {
            yield return _innerArr[--size];
        }

        private void Resize(int capacity)
        {
            var newArr = new T[capacity];
            Array.Copy(_innerArr, newArr, _innerArr.Length);
            _innerArr = newArr;
        }
    }
}
