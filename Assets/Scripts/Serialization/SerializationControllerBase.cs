using System.IO;
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
        
        public void Serialize<T>(T self)
        {
            Method.Serialize(self, GetStreamToWrite());
        }

        public T Deserialize<T>()
        {
            return Method.Deserialize<T>(GetStreamToRead());
        }

        public ISerializationMethod Method
        {
            get;
        }
    }
}
