using System.IO;
using ESparrow.Utils.Serialization.Interfaces;

namespace ESparrow.Utils.Serialization
{
    public abstract class SerializationMethodBase : ISerializationMethod
    {
        protected SerializationMethodBase(ISerializationFormatter formatter)
        {
            Formatter = formatter;
        }

        public abstract void Serialize<TSelf>(TSelf self, Stream stream);
        public abstract TSelf Deserialize<TSelf>(Stream stream);

        public ISerializationFormatter Formatter
        {
            get;
        }
    }
}