using System.Collections.Generic;
using ESparrow.Utils.Data.Interfaces;
using ESparrow.Utils.Data.Transmission.Adapters;
using ESparrow.Utils.Serialization.Interfaces;

namespace ESparrow.Utils.Data.Transmission
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