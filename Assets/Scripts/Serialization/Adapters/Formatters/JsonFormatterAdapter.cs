using System.IO;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace ESparrow.Utils.Serialization.Adapters.Formatters
{
    public class JsonFormatterAdapter : SerializationFormatterAdapterBase
    {
        private static DataContractJsonSerializer GetSerializer<T>()
        {
            return new DataContractJsonSerializer(typeof(T));
        }
        
        public override async Task Write<T>(Stream stream, T self)
        {
            GetSerializer<T>().WriteObject(stream, self);
            
            await stream.FlushAsync();
        }

        public override async Task<T> Read<T>(Stream stream)
        {
            var subject = (T) GetSerializer<T>().ReadObject(stream);
            
            await stream.FlushAsync();

            return subject;
        }
    }
}