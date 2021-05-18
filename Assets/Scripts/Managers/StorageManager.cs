using System.IO;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using ESparrow.Utils.Enums;

namespace ESparrow.Utils.Managers
{
    public static class StorageManager
    {
        private static Dictionary<string, string> _storage = new Dictionary<string, string>();

        private static readonly string dataPath = Application.persistentDataPath + Path.DirectorySeparatorChar + fileName;
        private static readonly string fileName = "Storage.dat";

        static StorageManager()
        {
            Load();
        }

        public static void Set(string key, object value)
        {
            _storage[key] = JsonUtility.ToJson(value);
            Save();
        }

        public static T Get<T>(string key)
        {
            if (!HasKey(key))
            {
                Debug.LogWarning($"Storage has no pair with key {key}");
                return default;
            }

            return JsonUtility.FromJson<T>(_storage[key]);
        }

        public static bool HasKey(string key)
        {
            return _storage.ContainsKey(key);
        }

        private static void Save()
        {
            SerializationManager.Serialize(_storage, dataPath, ESerializationMethod.Xml);
        }

        private static void Load()
        {
            _storage = SerializationManager.Deserialize<Dictionary<string, string>>(dataPath, ESerializationMethod.Xml);
        }
    }
}
