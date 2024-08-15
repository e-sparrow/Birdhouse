using System.Threading.Tasks;
using Birdhouse.Tools.Data.Transmission.Interfaces;
using Birdhouse.Tools.Serialization.Interfaces;

namespace Birdhouse.Tools.Data.Transmission.Adapters
{
    public class SerializationControllerToDataTransmitterAdapter<TData> 
        : IAsyncDataTransmitter<TData>
    {
        public SerializationControllerToDataTransmitterAdapter(ISerializationController serializationController)
        {
            _serializationController = serializationController;
        }

        private readonly ISerializationController _serializationController;
        
        public bool IsValid()
        {
            var result = _serializationController.IsExist();
            return result;
        }
        
        public async Task SetData(TData data)
        { 
            await _serializationController.Serialize(data);
        }

        public async Task<TData> GetData()
        {
            if (_serializationController.IsExist())
            {
                var result = await _serializationController.Deserialize<TData>();
                return result;
            }

            return default;
        }
    }
}