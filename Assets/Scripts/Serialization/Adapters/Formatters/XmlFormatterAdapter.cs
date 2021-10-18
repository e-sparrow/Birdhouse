using System.IO;
using System.Xml.Serialization;

namespace ESparrow.Utils.Serialization.Adapters.Formatters
{
    public class XmlFormatterAdapter : SerializationFormatterAdapterBase
    {
        private static XmlSerializer GetSerializer<T>()
        {
            return new XmlSerializer(typeof(T));
        }
        
        public override void Write<T>(Stream stream, T self)
        {
            GetSerializer<T>().Serialize(stream, self);
        }

        public override T Read<T>(Stream stream)
        {
            return (T) GetSerializer<T>().Deserialize(stream);
        }
    }
}