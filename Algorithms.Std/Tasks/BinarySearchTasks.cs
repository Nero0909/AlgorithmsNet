using System;

namespace Algorithms.Std.Tasks
{
    public static class BinarySearchTasks
    {
        public static int GetMinimumFloorSlow(int houseHeigh, int threshHold)
        {
            var left = 0;
            var right = houseHeigh;

            while (left <= right)
            {
                var mid = left + (right - left) / 2;

                if (mid >= threshHold)
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }

            return left;
        }

        public static int GetMinimumFloorFast(int houseHeigh, int threshHold)
        {
            var floor = 1;
            var ceiling = 1;
            while (floor < houseHeigh)
            {
                if (floor < threshHold)
                {
                    ceiling = floor;
                }
                else
                {
                    break;
                }

                floor <<= 1;
            }

            var left = ceiling;
            var right = Math.Min(floor, houseHeigh);
            var curFloor = 0;
            while (left <= right)
            {
                curFloor = left + (right - left) / 2;

                if (curFloor >= threshHold)
                {
                    right = curFloor - 1;
                }
                else
                {
                    left = curFloor + 1;
                }
            }

            return curFloor;
        }
    }
}