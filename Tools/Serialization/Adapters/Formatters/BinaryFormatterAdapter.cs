using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;

namespace Birdhouse.Tools.Serialization.Adapters.Formatters
{
    public class BinaryFormatterAdapter : SerializationFormatterAdapterBase
    {
        public override async Task Write<T>(Stream stream, T self)
        {
            new BinaryFormatter().Serialize(stream, self);

            await stream.FlushAsync();
        }

        public override async Task<T> Read<T>(Stream stream)
        {
            var subject = new BinaryFormatter().Deserialize(stream);

            await stream.FlushAsync();

            return (T) subject;
        }
    }
}