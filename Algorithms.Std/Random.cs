using System;
using Algorithms.Std.Helpers;

namespace Algorithms.Std
{
    public static class Random
    {
        private static System.Random _random;
        private static int _seed;

        static Random()
        {
            _seed = DateTime.Now.Millisecond;
            _random = new System.Random(_seed);
        }

        /// <summary>
        /// Sets the seed of the pseudorandom number generator.
        /// This method enables you to produce the same sequence of "random"
        /// number for each execution of the program.
        /// Ordinarily, you should call this method at most once per program.
        /// </summary>
        /// <param name="seed"></param>
        static void SetSeed(int seed)
        {
            _seed = seed;
            _random = new System.Random(_seed);
        }

        /// <summary>
        /// Returns a random real number uniformly in [0, 1).
        /// </summary>
        /// <returns> A random real number uniformly in [0, 1)</returns>
        public static double Uniform()
        {
            return _random.NextDouble();
        }

        /// <summary>
        /// Returns a random integer uniformly in [0, n).
        /// </summary>
        /// <param name="n">number of possible integers</param>
        /// <returns>A random integer uniformly between 0 (inclusive) and n</returns>
        public static int Uniform(int n)
        {
            if (n < 0)
            {
                ThrowHelper.ThrowInvalidArgumentException("Argument must be positive.");
            }

            return _random.Next(n);
        }

        /// <summary>
        /// Returns a random integer uniformly in [a, b).
        /// </summary>
        /// <param name="a">the left endpoint</param>
        /// <param name="b">the right endpoint</param>
        /// <returns>A random integer uniformly in [a, b)</returns>
        public static int Uniform(int a, int b)
        {
            if((b <= a) || ((long)b - a >= int.MaxValue))
            {
                ThrowHelper.ThrowInvalidArgumentException($"Invalid range: [{a}, {b}");
            }

            return a + Uniform(b - a);
        }

        /// <summary>
        /// Returns a random real number uniformly in [a, b).
        /// </summary>
        /// <param name="a">the left endpoint</param>
        /// <param name="b">the right endpoint</param>
        /// <returns>A random real number uniformly in [a, b)</returns>
        public static double Uniform(double a, double b)
        {
            if(!(a < b))
            {
                ThrowHelper.ThrowInvalidArgumentException($"Invalid range: [{a}, {b}");
            }

            return a + Uniform() * (b - a);
        }
    }
}