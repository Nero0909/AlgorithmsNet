namespace Algorithms.Std.Interfaces
{
    public interface IPipeline<T>
    {
        T Push(int T);

        T this[int index] { get; set; }
    }
}