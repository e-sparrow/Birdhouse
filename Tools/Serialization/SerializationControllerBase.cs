using System.IO;
using System.Threading.Tasks;
using Birdhouse.Common.Extensions;
using Birdhouse.Tools.Serialization.Interfaces;

namespace Birdhouse.Tools.Serialization
{
    public abstract class SerializationControllerBase : ISerializationController
    {
        protected SerializationControllerBase(ISerializationMethod method)
        {
            Method = method;
        }

        protected abstract Stream GetStreamToWrite();
        protected abstract Stream GetStreamToRead();
        
        public async Task Serialize<T>(T self)
        {
            var stream = GetStreamToWrite();
            await Method.Serialize(self, stream);
            stream.Close();
        }

        public async Task<T> Deserialize<T>()
        {
            var stream = GetStreamToRead();
            
            var value = await Method.Deserialize<T>(stream);
            stream.Close();
            
            return value;
        }  

        public bool IsExist()
        {
            var stream = GetStreamToRead();

            var isNotZeroLength = stream.Length != 0;
            var isNotEmpty = stream.IsNotEmpty();
            var canDeserialize = isNotZeroLength && isNotEmpty;
            
            stream.Close();
            
            return canDeserialize;
        }

        private ISerializationMethod Method
        {
            get;
        }
    }
}
