using System.IO;
using System.Threading.Tasks;

namespace ESparrow.Utils.Serialization.Interfaces
{
    public interface ISerializationMethod
    {
        /// <summary>
        /// Serialize self object by specified stream.
        /// </summary>
        /// <param name="self">Self object</param>
        /// <param name="stream">Specified stream</param>
        /// <typeparam name="T">Type of object to serialize</typeparam>
        Task Serialize<T>(T self, Stream stream);
        /// <summary>
        /// Deserialize object by specified stream and return it.
        /// </summary>
        /// <param name="stream">Specified stream</param>
        /// <typeparam name="T">Type of object to deserialize</typeparam>
        /// <returns>Deserialized object</returns>
        Task<T> Deserialize<T>(Stream stream);
    }
}