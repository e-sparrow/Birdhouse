using ESparrow.Utils.Storages.Interfaces;

namespace ESparrow.Utils.Storages.Scriptable
{
    public abstract class ScriptableRepositoryBase<TSource, TKey, TValue> : ScriptableStorageBase<TKey, TValue>, IRepository<TSource, TKey, TValue>
    {
        public abstract void UpdateRepository(TSource source);
    }
}