namespace Algorithms.Std.Interfaces
{
    public interface IDoubleBuffer<T>
    {
        int PushA(T value);

        int PushB(T value);
    }
}