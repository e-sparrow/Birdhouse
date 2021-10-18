namespace ESparrow.Utils.Serialization.Interfaces
{
    public interface ISerializationStorage
    {
        /// <summary>
        /// Save method.
        /// </summary>
        void Save();
        /// <summary>
        /// Load method.
        /// </summary>
        void Load();
        
        /// <summary>
        /// Gets the object by key.
        /// </summary>
        /// <param name="key">Key to get object</param>
        /// <typeparam name="T">Object type</typeparam>
        /// <returns>Object by specified key or null if key is wrong</returns>
        T Get<T>(string key);
        /// <summary>
        /// Set method.
        /// </summary>
        /// <param name="key">Key to get subject by Get method</param>
        /// <param name="subject">Subject to save</param>
        void Set(string key, object subject);

        /// <summary>
        /// Controller used to serialize objects in the storage.
        /// </summary>
        ISerializationController Controller
        {
            get;
        }
    }
}