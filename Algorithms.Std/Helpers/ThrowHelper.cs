using System;

namespace Algorithms.Std.Helpers
{
    internal static class ThrowHelper
    {
        public static void ThrowInvalidOperationException(string message)
        {
            throw new InvalidOperationException(message);
        }

        public static void ThrowInvalidArgumentException(string message)
        {
            throw new ArgumentException(message);
        }
    }
}