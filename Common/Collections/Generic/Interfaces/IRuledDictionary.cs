namespace Birdhouse.Common.Collections.Generic.Interfaces
{
    public interface IRuledDictionary<in TKey, out TValue>
    {
        TValue this[TKey key]
        {
            get;
        }
        
        TValue GetValue(TKey key);
    }
}
