using System.Collections.Generic;
using System.Threading.Tasks;
using Birdhouse.Tools.Serialization.Interfaces;

namespace Birdhouse.Tools.Serialization
{
    public abstract class SerializationStorageBase<TKey> 
        : ISerializationStorage<TKey>
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
            var result = _dictionary.ContainsKey(key);
            return result;
        }
        
        public T Get<T>(TKey key)
        {
            var result = (T) _dictionary[key];
            return result;
        }

        public T Get<T>(TKey key, T defaultValue)
        {
            var result = Get<T>(key) ?? defaultValue;
            return result;
        }

        public void Set(TKey key, object subject)
        {
            _dictionary[key] = subject;
        }
    }
}