using System.Collections.Generic;
using System.Threading.Tasks;
using ESparrow.Utils.Serialization.Interfaces;

namespace ESparrow.Utils.Serialization
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
            return await _serializationController.Deserialize<Dictionary<TKey, object>>();
        }
    }
}