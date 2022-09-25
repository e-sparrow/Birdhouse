using System.IO;
using System.Threading.Tasks;

namespace Birdhouse.Tools.Serialization.Interfaces
{
    public interface ISerializationFormatter
    {
        /// <summary>
        /// Format object to serialized form.
        /// </summary>
        /// <param name="stream">Specified stream</param>
        /// <param name="self">Self object to serialize</param>
        /// <typeparam name="T">Type of object to serialize</typeparam>
        Task Write<T>(Stream stream, T self);
        /// <summary>
        /// Format object from serialized form to deserialized one.
        /// </summary>
        /// <param name="stream">Specified stream</param>
        /// <typeparam name="T">Type of object to deserialize</typeparam>
        /// <returns>Deserialized object</returns>
        Task<T> Read<T>(Stream stream);
    }
}