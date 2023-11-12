namespace Birdhouse.Common.Collections.Interfaces
{
    public interface ILazyBuffer<in TKey, out TValue>
    {
        TValue this[TKey key] => GetOrCreate(key);

        TValue GetOrCreate(TKey key);
    }
}