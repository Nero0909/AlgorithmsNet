using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Algorithms.Std.Extensions;
using Algorithms.Std.Interfaces;

namespace Algorithms.Std.Collections
{
    public class RandomBag<T> : IRandomBag<T>
    {
        private readonly List<T> _innerArr;

        public RandomBag(int capacity)
        {
            _innerArr = new List<T>(capacity);
        }

        public RandomBag() : this(4)
        {

        }

        public bool IsEmpty => _innerArr.Count == 0;

        public int Size => _innerArr.Count;

        public void Add(T item)
        {
            _innerArr.Add(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            var shuffledArr = _innerArr.ToList();
            shuffledArr.Shuffle();

            return shuffledArr.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}