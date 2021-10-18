using System.Collections.Generic;
using ESparrow.Utils.Serialization.Interfaces;

namespace ESparrow.Utils.Serialization
{
    public abstract class SerializationStorageBase : ISerializationStorage
    {
        protected SerializationStorageBase(ISerializationController controller)
        {
            Controller = controller;
        }

        protected Dictionary<string, object> Dictionary = new Dictionary<string, object>();
        
        public abstract void Save();
        public abstract void Load();
        
        public T Get<T>(string key)
        {
            return (T) Dictionary[key];
        }

        public T Get<T>(string key, T defaultValue)
        {
            return Get<T>(key) ?? defaultValue;
        }

        public void Set(string key, object subject)
        {
            Dictionary[key] = subject;
            if (SaveWhenSet)
            {
                Save();
            }
        }

        public ISerializationController Controller
        {
            get;
        }

        /// <summary>
        /// Save the storage when setting the objects or not.
        /// </summary>
        public bool SaveWhenSet
        {
            get;
            set;
        }
    }
}