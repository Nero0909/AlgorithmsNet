using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Std.Algorithms
{
    public static class Pairs
    {
        public static int CountTwoSums(this IList<int> input)
        {
            var arr = input.ToList();
            arr.Sort();

            var count = 0;
            var left = 0;
            var right = arr.Count - 1;

            while (left < right && arr[left] < 0 && arr[right] > 0)
            {
                var sum = arr[left] + arr[right];
                if (sum > 0)
                {
                    right--;
                }
                else if (sum > 0)
                {
                    left++;
                }
                else
                {
                    count++;
                    right--;
                    left++;
                }
            }

            return count;
        }

        public static int CountTwoSumsSlow(this IList<int> input)
        {
            var arr = input.ToList();
            arr.Sort();

            var count = 0;
            for (var i = 0; i < arr.Count; i++)
            {
                if (arr.AscendingRank(-arr[i]) > i)
                {
                    count++;
                }
            }

            return count;
        }

        public static Tuple<double, double> NearestPair(this IList<double> arr)
        {
            if (arr.Count == 0)
            {
                return new Tuple<double, double>(0, 0);
            }

            if (arr.Count < 2)
            {
                return new Tuple<double, double>(arr[0], arr[0]);
            }

            var firstMinIndex = 0;
            var secondMinIndex = 1;
            var firstMin = Math.Abs(arr[firstMinIndex]);
            var secondMin = Math.Abs(arr[secondMinIndex]);

            for (var i = 1; i < arr.Count; i++)
            {
                var itemAbs = Math.Abs(arr[i]);
                if (!(Math.Abs(arr[i]) < firstMin))
                {
                    continue;
                }

                firstMin = itemAbs;
                firstMinIndex = i;
            }

            for (var i = 2; i < arr.Count; i++)
            {
                var itemAbs = Math.Abs(arr[i]);
                if (itemAbs == firstMin || !(itemAbs < secondMin))
                {
                    continue;
                }

                secondMin = itemAbs;
                secondMinIndex = i;
            }
            return new Tuple<double, double>(arr[firstMinIndex], arr[secondMinIndex]);
        }
    }
}