using System;
using System.Collections.Generic;

namespace Algorithms.Std.Algorithms
{
    public static class BinarySearch
    {
        public static int AscendingRank<T>(this IList<T> arr, T val)
        {
            var comparer = Comparer<T>.Default;
            var left = 0;
            var right = arr.Count - 1;

            return arr.AscendingRank(val, left, right, comparer);
        }

        private static int AscendingRank<T>(this IList<T> arr, T val, int left, int right, IComparer<T> comparer)
        {
            while (left <= right)
            {
                var mid = left + (right - left) / 2;
                var compResult = comparer.Compare(val, arr[mid]);

                if (compResult < 0)
                {
                    right = mid - 1;
                }
                else if (compResult > 0)
                {
                    left = mid + 1;
                }
                else
                {
                    return mid;
                }
            }

            return -1;
        }

        public static int DescendingRank<T>(this IList<T> arr, T val)
        {
            var comparer = Comparer<T>.Default;
            var left = 0;
            var right = arr.Count - 1;

            return arr.DescendingRank(val, left, right, comparer);
        }

        public static int DescendingRank<T>(this IList<T> arr, T val, int left, int right, IComparer<T> comparer)
        {
            while (left <= right)
            {
                var mid = left + (right - left) / 2;
                var compResult = comparer.Compare(val, arr[mid]);

                if (compResult > 0)
                {
                    right = mid - 1;
                }
                else if (compResult < 0)
                {
                    left = mid + 1;
                }
                else
                {
                    return mid;
                }
            }

            return -1;
        }

        public static int RankMin<T>(this IList<T> arr, T val)
        {
            var comparer = Comparer<T>.Default;
            var left = 0;
            var right = arr.Count - 1;
            var minIndex = arr.Count;

            while (left <= right)
            {
                var mid = left + (right - left) / 2;
                var compResult = comparer.Compare(val, arr[mid]);

                if (compResult < 0)
                {
                    right = mid - 1;
                }
                else if (compResult > 0)
                {
                    left = mid + 1;
                }
                else
                {
                    minIndex = mid;
                    right = mid - 1;
                }
            }

            return minIndex == arr.Count ? -1 : minIndex;
        }

        public static int BitonicSearch<T>(this IList<T> arr, T val)
        {
            var comparer = Comparer<T>.Default;
            var left = 0;
            var right = arr.Count - 1;
            var maxValueIndex = arr.FindBitonicMax();

            var ascSearch = arr.AscendingRank(val, left, maxValueIndex, comparer);
            var desSearch = arr.DescendingRank(val, maxValueIndex, right, comparer);

            if (ascSearch != -1)
            {
                return ascSearch;
            }

            if (desSearch != -1)
            {
                return desSearch;
            }

            return -1;
        }

        public static int FindBitonicMax<T>(this IList<T> arr)
        {
            var comparer = Comparer<T>.Default;
            var left = 0;
            var right = arr.Count - 1;

            while (left <= right)
            {
                var mid = left + (right - left) / 2;
                if (mid == right)
                {
                    return right;
                }

                if (mid == left)
                {
                    var comp = comparer.Compare(arr[mid + 1], arr[mid]);
                    var maxValueIndex = 0;

                    if (comp >= 1)
                    {
                        maxValueIndex = mid + 1;
                    }
                    else
                    {
                        maxValueIndex = left;
                    }

                    return maxValueIndex;
                }

                var compLeft = comparer.Compare(arr[mid], arr[mid - 1]);
                var compRight = comparer.Compare(arr[mid + 1], arr[mid]);

                if (compLeft >= 0 && compRight >= 0)
                {
                    left = mid + 1;
                    continue;
                }

                if (compLeft <= 0 && compRight <= 0)
                {
                    right = mid - 1;
                    continue;
                }

                return mid;
            }

            return -1;
        }
    }
}