using System.Collections;
using System.Collections.Generic;
using Algorithms.Std.Interfaces;

namespace Algorithms.Std.Collections
{
    public class RingBuffer<T> : IRingBuffer<T>
    {
        private readonly T[] _innerArr;
        private readonly int _capacity;
        private int _firstEl;
        private int _freeEl;

        public bool IsFull => Size == _capacity;
        public bool IsEmpty => Size == 0;
        public int Size { get; private set; }

        public RingBuffer(int capacity)
        {
            _capacity = capacity;
            _innerArr = new T[capacity];
            _firstEl = 0;
            _freeEl = 0;
            Size = 0;
        }

        public bool TryEnqueue(T item)
        {
            if (IsFull)
            {
                return false;
            }

            _innerArr[_freeEl] = item;
            _freeEl = GetNextIndex(_freeEl);
            Size++;

            return true;
        }

        public T Dequeue()
        {
            var item = _innerArr[_firstEl];
            _innerArr[_firstEl] = default(T);
            _firstEl = GetNextIndex(_firstEl);
            Size--;

            return item;
        }

        private int GetNextIndex(int current)
        {
            return (current + 1) % _capacity;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (var i = _firstEl; i != _freeEl; i = GetNextIndex(i))
            {
                yield return _innerArr[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}