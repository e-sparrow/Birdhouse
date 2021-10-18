using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ESparrow.Utils.Serialization.Adapters.Formatters
{
    public class BinaryFormatterAdapter : SerializationFormatterAdapterBase
    {
        protected virtual BinaryFormatter GetFormatter<T>()
        {
            return new BinaryFormatter();
        }
        
        public override void Write<T>(Stream stream, T self)
        {
            GetFormatter<T>().Serialize(stream, self);
        }

        public override T Read<T>(Stream stream)
        {
            return (T) GetFormatter<T>().Deserialize(stream);
        }
    }
}