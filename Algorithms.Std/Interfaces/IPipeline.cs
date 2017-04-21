namespace Algorithms.Std.Interfaces
{
    public interface IPipeline<T>
    {
        T Push(T value);

        T this[int index] { get; set; }

        int Size { get; }
    }
}