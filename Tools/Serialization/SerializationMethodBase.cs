using System.IO;
using System.Threading.Tasks;
using Birdhouse.Tools.Serialization.Interfaces;

namespace Birdhouse.Tools.Serialization
{
    public abstract class SerializationMethodBase : ISerializationMethod
    {
        public abstract Task Serialize<TSelf>(TSelf self, Stream stream);
        public abstract Task<TSelf> Deserialize<TSelf>(Stream stream);
    }
}