using System.IO;
using System.Threading.Tasks;
using Birdhouse.Tools.Serialization.Interfaces;

namespace Birdhouse.Tools.Serialization
{
    public class SerializationMethod : SerializationMethodBase
    {
        public SerializationMethod(ISerializationFormatter formatter)
        {
            _formatter = formatter;
        }

        private readonly ISerializationFormatter _formatter;
        
        public override async Task Serialize<T>(T self, Stream stream)
        {
            await _formatter.Write(stream, self);
        }

        public override async Task<T> Deserialize<T>(Stream stream)
        {
            return await _formatter.Read<T>(stream);
        }
    }
}