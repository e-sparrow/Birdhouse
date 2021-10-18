using System.IO;
using System.Runtime.Serialization;

namespace ESparrow.Utils.Serialization.Adapters.Formatters
{
    public class DefaultFormatterAdapter : SerializationFormatterAdapterBase
    {
        public DefaultFormatterAdapter(IFormatter formatter)
        {
            _formatter = formatter;
        }

        private readonly IFormatter _formatter;
        
        public override void Write<T>(Stream stream, T self)
        {
            _formatter.Serialize(stream, self);
        }

        public override T Read<T>(Stream stream)
        {
            return (T) _formatter.Deserialize(stream);
        }
    }
}