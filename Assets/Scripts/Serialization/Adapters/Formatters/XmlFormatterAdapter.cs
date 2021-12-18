using System.IO;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ESparrow.Utils.Serialization.Adapters.Formatters
{
    public class XmlFormatterAdapter : SerializationFormatterAdapterBase
    {
        public override async Task Write<T>(Stream stream, T self)
        {
            var serializer = new XmlSerializer(typeof(T));
            serializer.Serialize(stream, self);

            await stream.FlushAsync();
        }

        public override async Task<T> Read<T>(Stream stream)
        {
            var serializer = new XmlSerializer(typeof(T));
            var subject = serializer.Deserialize(stream);

            await stream.FlushAsync();

            return (T) subject;
        }
    }
}