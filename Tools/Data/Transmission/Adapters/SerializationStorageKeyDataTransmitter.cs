using Birdhouse.Tools.Data.Transmission.Interfaces;
using Birdhouse.Tools.Serialization.Interfaces;

namespace Birdhouse.Tools.Data.Transmission.Adapters
{
    public sealed class SerializationStorageKeyDataTransmitter<TKey, TData>
        : IDataTransmitter<TData>
    {
        public SerializationStorageKeyDataTransmitter(ISerializationStorage<TKey> storage, TKey key, bool autoSave = true)
        {
            _storage = storage;
            _key = key;
            _autoSave = autoSave;
        }

        private readonly ISerializationStorage<TKey> _storage;
        private readonly TKey _key;
        private readonly bool _autoSave;

        public void Upload(TData data)
        {
            _storage.Set(_key, data);

            if (_autoSave)
            {
                _storage.Save();
            }
        }

        public TData Download()
        {
            var result = _storage.Get<TData>(_key);
            return result;
        }

        public bool IsValid()
        {
            var result = _storage.HasKey(_key);
            return result;
        }
    }
}