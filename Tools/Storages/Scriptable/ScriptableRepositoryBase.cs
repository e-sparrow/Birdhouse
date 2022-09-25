using Birdhouse.Tools.Storages.Interfaces;

namespace Birdhouse.Tools.Storages.Scriptable
{
    public abstract class ScriptableRepositoryBase<TSource, TKey, TValue> : ScriptableStorageBase<TKey, TValue>, IRepository<TSource, TKey, TValue>
    {
        public abstract void UpdateRepository(TSource source);
    }
}