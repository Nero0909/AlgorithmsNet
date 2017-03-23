using System;
using System.Collections;
using System.Collections.Generic;
using Algorithms.Std.Helpers;

namespace Algorithms.Std.Extensions
{
    public static class ArrayExtensions
    {
        /// <summary>
        /// Rearranges the elements of the entire array in uniformly random order.
        /// </summary>
        /// <param name="arr">The array to shuffle</param>
        /// <typeparam name="T"></typeparam>
        public static void Shuffle<T>(this IList<T> arr)
        {
            if (arr.Count < 2)
            {
                return;
            }

            Shuffle(arr, 0, arr.Count-1);
        }

        /// <summary>
        /// Rearranges the elements of the specified subarray in uniformly random order.
        /// </summary>
        /// <param name="arr">The array to shuffle</param>
        /// <param name="lo">The left endpoint (inclusive)</param>
        /// <param name="hi">The right endpoint (inclusive)</param>
        /// <typeparam name="T"></typeparam>
        public static void Shuffle<T>(this IList<T> arr, int lo, int hi)
        {
            if (lo < 0 || lo > hi || hi >= arr.Count)
            {
                ThrowHelper.ThrowInvalidArgumentException($"Invalid subarray range: [{lo}, {hi}]");
            }

            for (var i = lo; i <= hi; ++i)
            {
                var r = i + Random.Uniform(hi - i + 1);
                var tmp = arr[i];
                arr[i] = arr[r];
                arr[r] = tmp;
            }
        }

        /// <summary>
        /// Swap two element in list
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <typeparam name="T"></typeparam>
        public static void Swap<T>(this IList<T> arr, int i, int j)
        {
            if (arr == null)
            {
                throw new ArgumentNullException(nameof(arr));
            }

            if (i < 0 || i >= arr.Count || j < 0 || j >= arr.Count)
            {
                ThrowHelper.ThrowInvalidArgumentException($"Invalid indexes: {i}, {j}");
            }

            var tmp = arr[i];
            arr[i] = arr[j];
            arr[j] = tmp;
        }
    }
}