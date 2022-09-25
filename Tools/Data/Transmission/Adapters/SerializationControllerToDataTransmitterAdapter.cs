using System.Threading.Tasks;
using Birdhouse.Tools.Data.Transmission.Interfaces;
using Birdhouse.Tools.Serialization.Interfaces;

namespace Birdhouse.Tools.Data.Transmission.Adapters
{
    public class SerializationControllerToDataTransmitterAdapter<TData> : IAsyncDataTransmitter<TData>, IDataTransmitter<TData>
    {
        public SerializationControllerToDataTransmitterAdapter(ISerializationController serializationController)
        {
            _serializationController = serializationController;
        }

        private readonly ISerializationController _serializationController;

        void IDataTransmitter<TData>.SetData(TData data)
        {
            _serializationController.Serialize(data);
        }

        TData IDataTransmitter<TData>.GetData()
        {
            if (_serializationController.IsExist())
            {
                return _serializationController.Deserialize<TData>().Result;
            }

            return default;
        }

        async Task IAsyncDataTransmitter<TData>.SetData(TData data)
        { 
            await _serializationController.Serialize(data);
        }

        async Task<TData> IAsyncDataTransmitter<TData>.GetData()
        {
            if (_serializationController.IsExist())
            {
                return await _serializationController.Deserialize<TData>();
            }

            return default;
        }
    }
}