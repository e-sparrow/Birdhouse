using System.IO;
using System.Runtime.Serialization.Json;

namespace ESparrow.Utils.Serialization.Adapters.Formatters
{
    public class JsonFormatterAdapter : SerializationFormatterAdapterBase
    {
        private static DataContractJsonSerializer GetSerializer<T>()
        {
            return new DataContractJsonSerializer(typeof(T));
        }
        
        public override void Write<T>(Stream stream, T self)
        {
            GetSerializer<T>().WriteObject(stream, self);
        }

        public override T Read<T>(Stream stream)
        {
            return (T) GetSerializer<T>().ReadObject(stream);
        }
    }
}