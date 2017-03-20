using System;

namespace Algorithms.Std.Tasks
{
    public static class BinarySearchTasks
    {
        public static int GetMinimumFloorSlow(int houseHeigh, int threshHold)
        {
            var destoryed = true;
            var left = 1;
            var right = houseHeigh;
            var curFloor = -1;

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