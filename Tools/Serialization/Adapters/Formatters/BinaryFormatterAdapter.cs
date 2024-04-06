using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;

namespace Birdhouse.Tools.Serialization.Adapters.Formatters
{
    public class BinaryFormatterAdapter : SerializationFormatterAdapterBase
    {
        public override async Task Write<T>(Stream stream, T self)
        {
            var formatter = new BinaryFormatter();
            formatter.Serialize(stream, self);

            await stream.FlushAsync();
            stream.Dispose();
        }

        public override async Task<T> Read<T>(Stream stream)
        {
            var formatter = new BinaryFormatter();
            var subject = formatter.Deserialize(stream);

            await stream.FlushAsync();
            stream.Dispose();

            return (T) subject;
        }
    }
}