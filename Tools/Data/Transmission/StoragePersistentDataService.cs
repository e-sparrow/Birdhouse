using System.Threading.Tasks;
using Birdhouse.Tools.Data.Transmission.Interfaces;
using Birdhouse.Tools.Serialization.Interfaces;

namespace Birdhouse.Tools.Data.Transmission.Routine
{
    public class StoragePersistentDataService<TKey> : IPersistentDataService<TKey>
    {
        public StoragePersistentDataService(ISerializationStorage<TKey> storage)
        {
            _storage = storage;
        }

        private readonly ISerializationStorage<TKey> _storage;

        public IAsyncDataTransmitter<T> GetDataTransmitter<T>(TKey key)
        {
            var result = new StorageDataTransmitter<T>(_storage, key);
            return result;
        }

        private class StorageDataTransmitter<T> : IAsyncDataTransmitter<T>
        {
            public StorageDataTransmitter(ISerializationStorage<TKey> storage, TKey key)
            {
                _storage = storage;
                _key = key;
            }

            private readonly ISerializationStorage<TKey> _storage;
            private readonly TKey _key;

            public bool IsValid()
            {
                var result = _storage.HasKey(_key);
                return result;
            }
            
            public Task<T> GetData()
            {
                var result = _storage.Get<T>(_key);

                var task = Task.FromResult(result);
                return task;
            }

            public Task SetData(T data)
            {
                _storage.Set(_key, data);
                
                var task = Task.CompletedTask;
                return task;
            }
        }
    }
}