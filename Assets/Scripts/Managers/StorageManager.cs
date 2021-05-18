using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ESparrow.Utils.Enums;

namespace ESparrow.Utils.Managers
{
    public static class StorageManager
    {
        private static Dictionary<string, object> _storage = new Dictionary<string, object>();

        private static readonly string dataPath = Application.persistentDataPath + Path.DirectorySeparatorChar + fileName;
        private static readonly string fileName = "Storage.binary";

        static StorageManager()
        {
            Load();
        }

        public static void Set(string key, object value)
        {
            _storage.Add(key, value);
            Save();
        }

        public static T Get<T>(string key)
        {
            return (T) _storage[key];
        }

        private static void Save()
        {
            SerializationManager.Serialize(_storage, dataPath, ESerializationMethod.Binary);
        }

        private static void Load()
        {
            SerializationManager.Deserialize<Dictionary<string, object>>(dataPath, ESerializationMethod.Binary);
        }
    }
}
