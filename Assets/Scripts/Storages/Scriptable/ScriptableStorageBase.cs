using System;
using System.Collections.Generic;
using System.Linq;
using ESparrow.Utils.Storages.Interfaces;
using UnityEngine;

namespace ESparrow.Utils.Storages.Scriptable
{
    public abstract class ScriptableStorageBase<TKey, TValue> : ScriptableObject, IKeyValueStorage<TKey, TValue>
    {
        [SerializeField] private List<SerializablePair> pairs;

        protected abstract bool IsFit(TKey key, SerializablePair pair);
        
        public TValue GetValue(TKey key)
        {
            return pairs.FirstOrDefault(IsPairFit).value;

            bool IsPairFit(SerializablePair pair)
            {
                return IsFit(key, pair);
            }
        }

        [Serializable]
        protected struct SerializablePair
        {
            public TKey key;
            public TValue value;
        }
    }
}
