using System.IO;

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
        void Serialize<T>(T self, Stream stream);
        /// <summary>
        /// Deserialize object by specified stream and return it.
        /// </summary>
        /// <param name="stream">Specified stream</param>
        /// <typeparam name="T">Type of object to deserialize</typeparam>
        /// <returns>Deserialized object</returns>
        T Deserialize<T>(Stream stream);

        /// <summary>
        /// Formatter for serialization method.
        /// </summary>
        ISerializationFormatter Formatter
        {
            get;
        }
    }
}