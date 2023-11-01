using Birdhouse.Tools.Storages.Interfaces;
using UnityEngine;

namespace Birdhouse.Tools.Storages.Scriptable
{
    public abstract class ScriptableStorageBase<TKey, TValue> 
        : ScriptableObject, IStorage<TKey, TValue>
    {
        public abstract TValue GetValue(TKey key);
    }
}
