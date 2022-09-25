using System.IO;
using System.Threading.Tasks;
using Birdhouse.Tools.Serialization.Interfaces;

namespace Birdhouse.Tools.Serialization.Adapters.Formatters
{
    public abstract class SerializationFormatterAdapterBase : ISerializationFormatter
    {
        public abstract Task Write<T>(Stream stream, T self);
        public abstract Task<T> Read<T>(Stream stream);
    }
}