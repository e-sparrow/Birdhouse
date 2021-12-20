using System.Threading.Tasks;

namespace ESparrow.Utils.Serialization.Interfaces
{
    public interface ISerializationController
    {
        /// <summary>
        /// Serialize object.
        /// </summary>
        /// <param name="self">Self object to serialize</param>
        /// <typeparam name="T">Type of object to serialize</typeparam>
        Task Serialize<T>(T self);
        /// <summary>
        /// Deserialize object.
        /// </summary>
        /// <typeparam name="T">Type of object to deserialize</typeparam>
        /// <returns>Deserialized object</returns>
        Task<T> Deserialize<T>();
        /// <summary>
        /// Checks is the object exists.
        /// </summary>
        /// <typeparam name="T">Type of object</typeparam>
        /// <returns>True if it's exist and false otherwise</returns>
        bool IsExist();
    }
}