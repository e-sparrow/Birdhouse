using System.Collections.Generic;
using Birdhouse.Tools.Data.Transmission.Adapters;
using Birdhouse.Tools.Data.Transmission.Interfaces;
using Birdhouse.Tools.Serialization.Interfaces;

namespace Birdhouse.Tools.Data.Transmission
{
    public abstract class FileBasedPersistentDataServiceBase<TKey> : IPersistentDataService<TKey>
    {
        protected FileBasedPersistentDataServiceBase(IDictionary<TKey, ISerializationController> controllers = null)
        {
            controllers ??= new Dictionary<TKey, ISerializationController>();
            _controllers = controllers;
        }

        private readonly IDictionary<TKey, ISerializationController> _controllers;

        protected abstract ISerializationController CreateController(TKey key);

        public IAsyncDataTransmitter<T> GetDataTransmitter<T>(TKey key)
        {
            var result = GetAdapter<T>(key);
            return result;
        }

        private SerializationControllerToDataTransmitterAdapter<T> GetAdapter<T>(TKey key)
        {
            if (_controllers.ContainsKey(key))
            {
                var controller = _controllers[key];
                
                var adapter = new SerializationControllerToDataTransmitterAdapter<T>(controller);
                return adapter;
            }
            else
            {
                var controller = CreateController(key);
                _controllers[key] = controller;

                var adapter = new SerializationControllerToDataTransmitterAdapter<T>(controller);
                return adapter;
            }
        }
    }
}