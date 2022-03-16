using System.Collections.Generic;
using System.Linq;
using ESparrow.Utils.Generic.Pairs.Interfaces;
using ESparrow.Utils.Storages.Interfaces;
using UnityEngine;

namespace ESparrow.Utils.Storages.Scriptable
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
