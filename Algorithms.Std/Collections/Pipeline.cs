namespace Algorithms.Std.Collections
{
    using System;
    using global::Algorithms.Std.Interfaces;

    public sealed class Pipeline<T> : IPipeline<T>
    {
        private readonly T[] buffer;
        private int head;
        private int tail;

        public Pipeline(int capacity)
        {
            buffer = new T[capacity];
            head = capacity - 1;
            tail = head;
            Size = 0;
        }

        public T Push(T value)
        {
            var lastValue = buffer[head];
            buffer[head] = value;
            tail = head;

            if (head == 0)
            {
                head = buffer.Length - 1;
            }
            else
            {
                head--;
            }

            if (Size < buffer.Length)
            {
                Size++;
            }

            return lastValue;
        }

        public T this[int index]
        {
            get
            {
                CheckIndex(index);
                return buffer[GetValidIndex(index)];
            }
            set
            {
                CheckIndex(index);
                buffer[GetValidIndex(index)] = value;
            }
        }

        public int Size { get; private set; }

        private void CheckIndex(int index)
        {
            if (index < 0 || index > Size)
            {
                throw new IndexOutOfRangeException($"{index} should be less than 0 and greater than {Size}.");
            }
        }

        private int GetValidIndex(int index)
        {
            var upperBound = buffer.Length - 1;
            var offset = tail + index;
            if (offset > upperBound)
            {
                return offset % upperBound;
            }
            return offset;
        }
    }
}