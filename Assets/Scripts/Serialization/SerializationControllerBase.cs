using System.IO;
using System.Threading.Tasks;
using ESparrow.Utils.Extensions;
using ESparrow.Utils.Serialization.Interfaces;

namespace ESparrow.Utils.Serialization
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
            bool canDeserialize = stream.IsNotEmpty();
            stream.Close();
            
            return canDeserialize;
        }

        private ISerializationMethod Method
        {
            get;
        }
    }
}
