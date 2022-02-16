namespace ESparrow.Utils.Storages.Interfaces
{
    public interface IKeyValueStorage<in TKey, out TValue>
    {
        TValue GetValue(TKey key);
    }
}