using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ESparrow.Utils.Collections.Generic
{
    [Serializable]
    public class KeyValueCollection<TKey, TValue> : IEnumerable
    {
        [SerializeField] protected List<KeyValuePair> _pairs;

        public KeyValueCollection()
        {
            _pairs = new List<KeyValuePair>();
        }

        public TValue this[TKey key]
        {
            get => GetPairByKey(key).value;
            set => GetPairByKey(key).value = value;
        }

        private KeyValuePair GetPairByKey(TKey key)
        {
            return _pairs.FirstOrDefault(value => value.key.Equals(key));
        }

        public IEnumerator GetEnumerator()
        {
            return _pairs.GetEnumerator();
        }

        [Serializable]
        protected class KeyValuePair
        {
            public TKey key;
            public TValue value;

            public KeyValuePair(TKey key, TValue value = default)
            {
                this.key = key;
                this.value = value;
            }
        }
    }
}
