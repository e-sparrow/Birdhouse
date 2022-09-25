using System.IO;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Birdhouse.Tools.Serialization.Adapters.Formatters
{
    public class DefaultFormatterAdapter : SerializationFormatterAdapterBase
    {
        public DefaultFormatterAdapter(IFormatter formatter)
        {
            _formatter = formatter;
        }

        private readonly IFormatter _formatter;
        
        public override async Task Write<T>(Stream stream, T self)
        {
            _formatter.Serialize(stream, self);

            await stream.FlushAsync();
        }

        public override async Task<T> Read<T>(Stream stream)
        {
            var subject = (T) _formatter.Deserialize(stream);

            await stream.FlushAsync();

            return subject;
        }
    }
}