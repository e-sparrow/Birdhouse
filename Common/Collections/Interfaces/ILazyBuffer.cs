namespace Birdhouse.Common.Collections.Interfaces
{
    public interface ILazyBuffer<in TKey, out TValue>
    {
        TValue this[TKey key]
        {
            get;
        }

        TValue GetOrCreate(TKey key);
    }
}