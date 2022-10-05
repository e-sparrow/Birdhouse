using System.IO;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace Birdhouse.Tools.Serialization.Adapters.Formatters
{
    public class JsonFormatterAdapter : SerializationFormatterAdapterBase
    {
        public JsonFormatterAdapter(DataContractJsonSerializerSettings settings = null)
        {
            settings ??= GetDefaultSerializerSettings();
            _settings = settings;
        }

        private readonly DataContractJsonSerializerSettings _settings;
        
        public override async Task Write<T>(Stream stream, T self)
        {
            var serializer = GetDefaultSerializer<T>();
            serializer.WriteObject(stream, self);
            
            await stream.FlushAsync();
        }

        public override async Task<T> Read<T>(Stream stream)
        {
            var serializer = GetDefaultSerializer<T>();
            var subject = serializer.ReadObject(stream);
            
            await stream.FlushAsync();

            var result = (T) subject;
            return result;
        }

        private DataContractJsonSerializerSettings GetDefaultSerializerSettings()
        {
            var settings = new DataContractJsonSerializerSettings()
            {
                UseSimpleDictionaryFormat = true,
                SerializeReadOnlyTypes = true
            };

            return settings;
        }
        
        private DataContractJsonSerializer GetDefaultSerializer<T>()
        {
            var serializer = new DataContractJsonSerializer(typeof(T), _settings);
            return serializer;
        }
    }
}