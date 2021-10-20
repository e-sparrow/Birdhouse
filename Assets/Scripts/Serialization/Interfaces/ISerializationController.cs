namespace ESparrow.Utils.Serialization.Interfaces
{
    public interface ISerializationController
    {
        /// <summary>
        /// Serialize object.
        /// </summary>
        /// <param name="self">Self object to serialize</param>
        /// <typeparam name="T">Type of object to serialize</typeparam>
        void Serialize<T>(T self);
        /// <summary>
        /// Deserialize object.
        /// </summary>
        /// <typeparam name="T">Type of object to deserialize</typeparam>
        /// <returns>Deserialized object</returns>
        T Deserialize<T>();
        /// <summary>
        /// Tries to deserialize object.
        /// </summary>
        /// <param name="subject">Deserialized object</param>
        /// <typeparam name="T">Type of deserialized object</typeparam>
        /// <returns>True if object is deserialized and false otherwise</returns>
        bool TryDeserialize<T>(out T subject);

        /// <summary>
        /// Method of serialization. 
        /// </summary>
        ISerializationMethod Method
        {
            get;
        }
    }
}