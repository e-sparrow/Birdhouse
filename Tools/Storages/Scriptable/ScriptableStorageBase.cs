using System.Collections.Generic;
using System.Linq;
using Birdhouse.Common.Generic.Pairs.Interfaces;
using Birdhouse.Tools.Storages.Interfaces;
using UnityEngine;

namespace Birdhouse.Tools.Storages.Scriptable
{
    public abstract class ScriptableStorageBase<TKey, TValue> : ScriptableObject, IStorage<TKey, TValue>
    {
        protected abstract bool IsFit(TKey key, IPair<TKey, TValue> pair);
        
        public TValue GetValue(TKey key)
        {
            return Data.FirstOrDefault(IsPairFit).Value;

            bool IsPairFit(IPair<TKey, TValue> pair)
            {
                return IsFit(key, pair);
            }
        }

        protected abstract IEnumerable<IPair<TKey, TValue>> Data
        {
            get;
        }
    }
}
