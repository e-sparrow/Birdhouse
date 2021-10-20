using System.IO;
using ESparrow.Utils.Serialization.Interfaces;

namespace ESparrow.Utils.Serialization.Adapters.Formatters
{
    public abstract class SerializationFormatterAdapterBase : ISerializationFormatter
    {
        public abstract void Write<T>(Stream stream, T self);
        public abstract T Read<T>(Stream stream);
    }
}