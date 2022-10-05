using System.Collections.Generic;
using System.Threading.Tasks;
using Birdhouse.Tools.Serialization.Interfaces;

namespace Birdhouse.Tools.Serialization
{
    public class SerializationStorage<TKey> : SerializationStorageBase<TKey>
    {
        public SerializationStorage(ISerializationController serializationController)
        {
            _serializationController = serializationController;
        }

        private readonly ISerializationController _serializationController;
        
        protected override async Task SaveDictionary(Dictionary<TKey, object> dictionary)
        {
            await _serializationController.Serialize(dictionary);
        }

        protected override async Task<Dictionary<TKey, object>> LoadDictionary()
        {
            if (_serializationController.IsExist())
            {
                var value = await _serializationController.Deserialize<Dictionary<TKey, object>>();
                return value;
            }

            var empty = new Dictionary<TKey, object>();
            return empty;
        }
    }
}