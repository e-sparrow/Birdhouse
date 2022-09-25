namespace Birdhouse.Tools.Storages.Interfaces
{
    public interface IRepository<in TSource, in TKey, out TValue> : IStorage<TKey, TValue>
    {
        void UpdateRepository(TSource source);
    }
}