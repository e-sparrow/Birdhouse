using System.Threading.Tasks;

namespace Birdhouse.Tools.Serialization.Interfaces
{
    public interface ISerializationStorage<in TKey>
    {
        /// <summary>
        /// Save method.
        /// </summary>
        Task Save();
        /// <summary>
        /// Load method.
        /// </summary>
        Task Load();
        
        /// <summary>
        /// Checks is dictionary has a specified key.
        /// </summary>
        /// <param name="key">Key to check</param>
        /// <returns>True if dictionary has the key and false otherwise</returns>
        bool HasKey(TKey key);
        
        /// <summary>
        /// Gets the object by key.
        /// </summary>
        /// <param name="key">Key to get object</param>
        /// <typeparam name="T">Object type</typeparam>
        /// <returns>Object by specified key or null if key is wrong</returns>
        T Get<T>(TKey key);
        
        /// <summary>
        /// Set method.
        /// </summary>
        /// <param name="key">Key to get subject by Get method</param>
        /// <param name="subject">Subject to save</param>
        void Set(TKey key, object subject);
    }
}