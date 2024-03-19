namespace Birdhouse.Features.DI
{
    public struct Injectable<T>
    {
        public Injectable(T value)
        {
            Value = value;
        }

        public T Value
        {
            get;
        }
    }
}