using System.Threading.Tasks;
using ESparrow.Utils.Data.Interfaces;
using ESparrow.Utils.Serialization.Interfaces;

namespace Data.Transmission.Adapters
{
    public class SerializationControllerToTransmittableAdapter<TData> : IAsyncTransmittable<TData>, ITransmittable<TData>
    {
        public SerializationControllerToTransmittableAdapter(ISerializationController serializationController)
        {
            _serializationController = serializationController;
        }

        private readonly ISerializationController _serializationController;

        void ITransmittable<TData>.SetData(TData data)
        {
            _serializationController.Serialize(data);
        }

        TData ITransmittable<TData>.GetData()
        {
            if (_serializationController.IsExist())
            {
                return _serializationController.Deserialize<TData>().Result;
            }

            return default;
        }

        async Task IAsyncTransmittable<TData>.SetData(TData data)
        { 
            await _serializationController.Serialize(data);
        }

        async Task<TData> IAsyncTransmittable<TData>.GetData()
        {
            if (_serializationController.IsExist())
            {
                return await _serializationController.Deserialize<TData>();
            }

            return default;
        }
    }
}