using System.Collections.Generic;
using Birdhouse.Tools.Data.Transmission.Adapters;
using Birdhouse.Tools.Data.Transmission.Interfaces;
using Birdhouse.Tools.Serialization.Interfaces;

namespace Birdhouse.Tools.Data.Transmission
{
    public abstract class FileBasedPersistentDataServiceBase<TKey> : IPersistentDataService<TKey>
    {
        protected FileBasedPersistentDataServiceBase(IDictionary<TKey, ISerializationController> controllers)
        {
            _controllers = controllers;
        }

        private readonly IDictionary<TKey, ISerializationController> _controllers;

        protected abstract ISerializationController CreateController(TKey key);

        public IDataTransmitter<T> GetDataTransmitter<T>(TKey key)
        {
            return GetAdapter<T>(key);
        }

        public IAsyncDataTransmitter<T> GetAsyncDataTransmitter<T>(TKey key)
        {
            return GetAdapter<T>(key);
        }

        private SerializationControllerToDataTransmitterAdapter<T> GetAdapter<T>(TKey key)
        {
            if (_controllers.ContainsKey(key))
            {
                var adapter = new SerializationControllerToDataTransmitterAdapter<T>(_controllers[key]);
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