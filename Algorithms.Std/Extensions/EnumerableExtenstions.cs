using System;
using System.Collections;
using System.Collections.Generic;

namespace Algorithms.Std.Extensions
{
    public static class EnumerableExtenstions
    {
        /// <summary>
        /// Merge two enumerables into the one sequence.
        /// Each element from the second enumerable will be follow up after the element from the first.
        /// </summary>
        /// <param name="first">The first enumerable</param>
        /// <param name="second">The second enumerable</param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IEnumerable<T> Merge<T>(this IEnumerable<T> first, IEnumerable<T> second)
        {
            if (first == null)
            {
                throw new ArgumentNullException(nameof(first));
            }
            if (second == null)
            {
                throw new ArgumentNullException(nameof(second));
            }

            return MergeIterator(first, second);
        }

        private static IEnumerable<T> MergeIterator<T>(IEnumerable<T> first, IEnumerable<T> second)
        {
            using (var firstEnumerator = first.GetEnumerator())
            using (var secondEnumerator = second.GetEnumerator())
            {
                while (firstEnumerator.MoveNext())
                {
                    yield return firstEnumerator.Current;

                    if (secondEnumerator.MoveNext())
                    {
                        yield return secondEnumerator.Current;
                    }
                }

                while (secondEnumerator.MoveNext())
                {
                    yield return secondEnumerator.Current;
                }
            }
        }
    }
}