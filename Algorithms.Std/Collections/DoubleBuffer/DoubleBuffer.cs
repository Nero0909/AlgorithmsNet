namespace Algorithms.Std.Collections.DoubleBuffer
{
    using System;
    using System.Linq;
    using global::Algorithms.Std.Extensions;
    using global::Algorithms.Std.Interfaces;

    public sealed class DoubleBuffer<T> : IDoubleBuffer<T>
    {
        private T[] aBuffer;
        private T[] bBuffer;
        private int aSize;
        private int Size;
        private readonly int[] aCommonIndexes;
        private readonly int[] bCommonIndexes;
        private int aLastValueIndex;
        private int bLastValueIndex;
        private Direction currentDirection = Direction.Forward;

        public DoubleBuffer(int aCapacity, int bCapacity) : this(aCapacity, bCapacity, null, null)
        {

        }

        public DoubleBuffer(int aCapacity, int bCapacity, int[] aCommonIndexes, int[] bCommonIndexes)
        {
            if (aCapacity <= 0 || bCapacity <= 0)
            {
                throw new ArgumentException($"{(aCapacity > 0 ? bCapacity : aCapacity)} is invalid capacity.");
            }

            var minCapacity = Math.Min(aCapacity, bCapacity);
            if (aCommonIndexes == null || bCommonIndexes == null)
            {
                var intersectionsCount = minCapacity / 4 > 0 ? minCapacity / 4 : 1;
                this.aCommonIndexes = GenerateCommonIndexes(intersectionsCount, aCapacity);
                this.bCommonIndexes = GenerateCommonIndexes(intersectionsCount, bCapacity);
            }
            else
            {
                if (aCommonIndexes.Length != bCommonIndexes.Length)
                {
                    throw new ArgumentException("Indexes should have the same size.");
                }

                this.aCommonIndexes = InitializeCommonIndexes(aCapacity, minCapacity, aCommonIndexes, "A buffer");
                this.bCommonIndexes = InitializeCommonIndexes(bCapacity, minCapacity, bCommonIndexes, "B buffer");
            }

            aBuffer = new T[aCapacity];
            bBuffer = new T[bCapacity];

            aSize = 0;
            Size = 0;
            aLastValueIndex = 0;
            bLastValueIndex = 0;
        }

        public int PushA(T value)
        {
            var isBufferFull = aSize == aBuffer.Length;

            //var currentIndex =


            return 0;
        }

        public int PushB(T value)
        {
            var isBufferFull = Size == bBuffer.Length;




            return 0;
        }

        private int[] InitializeCommonIndexes(int srcArrayCapacity, int minCapacity, int[] commonIndexes, string bufferName)
        {
            if (commonIndexes.Length >= minCapacity || commonIndexes.Any(x => x > srcArrayCapacity))
            {
                throw new ArgumentOutOfRangeException($"{bufferName} common indexes are invalid.");
            }

            return commonIndexes;
        }

        private int[] GenerateCommonIndexes(int intersectionsCount, int srcArrayCapacity)
        {
            var randomNumbers = Enumerable.Range(0, srcArrayCapacity).ToArray();
            randomNumbers.Shuffle();

            var indexes = new int[intersectionsCount];

            for (var i = 0; i < intersectionsCount; i++)
            {
                indexes[i] = randomNumbers[i];
            }

            return indexes;
        }

        private int GetNexIndex()
        {
            return 0;
        }

        private bool IsIntersection()
        {
            return true;
        }

        private enum Direction
        {
            Forward,
            Reverse
        }
    }

}