namespace Birdhouse.Common.Collections.Generic.Interfaces
{
    public interface ICircularBuffer<T> : IQueue<T>
    {
        bool IsFull
        {
            get;
        }
    }
}
