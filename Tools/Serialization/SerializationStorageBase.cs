using System.Collections.Generic;
using System.Threading.Tasks;
using Birdhouse.Tools.Serialization.Interfaces;

namespace Birdhouse.Tools.Serialization
{
    public abstract class SerializationStorageBase<TKey> : ISerializationStorage<TKey>
    {
        private Dictionary<TKey, object> _dictionary = new Dictionary<TKey, object>();
        
        protected abstract Task SaveDictionary(Dictionary<TKey, object> dictionary);
        protected abstract Task<Dictionary<TKey, object>> LoadDictionary();

        public async Task Save()
        {
            await SaveDictionary(_dictionary);
        }

        public async Task Load()
        {
            _dictionary = await LoadDictionary();
        }

        public bool HasKey(TKey key)
        {
            return _dictionary.ContainsKey(key);
        }
        
        public T Get<T>(TKey key)
        {
            return (T) _dictionary[key];
        }

        public T Get<T>(TKey key, T defaultValue)
        {
            return Get<T>(key) ?? defaultValue;
        }

        public void Set(TKey key, object subject)
        {
            _dictionary[key] = subject;
        }
    }
}