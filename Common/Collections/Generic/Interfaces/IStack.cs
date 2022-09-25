namespace Birdhouse.Common.Collections.Generic.Interfaces
{
    public interface IStack<T>
    {
        T Peek();
        T Pop();

        void Push(T element);
    }
}