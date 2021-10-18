using System.IO;
using ESparrow.Utils.Serialization.Interfaces;

namespace ESparrow.Utils.Serialization
{
    public class SerializationMethod : SerializationMethodBase
    {
        public SerializationMethod(ISerializationFormatter formatter) : base(formatter)
        {
            _formatter = formatter;
        }

        private readonly ISerializationFormatter _formatter;
        
        public override void Serialize<T>(T self, Stream stream)
        {
            _formatter.Write(stream, self);
        }

        public override T Deserialize<T>(Stream stream)
        {
            return (T) _formatter.Read<T>(stream);
        }
    }
}