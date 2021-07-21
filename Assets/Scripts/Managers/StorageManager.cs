using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using ESparrow.Utils.Enums;

namespace ESparrow.Utils.Managers
{
    public class StorageManager
    {
        private static readonly StorageManager _main;

        private static readonly string _defaultDataPath = Application.persistentDataPath + Path.DirectorySeparatorChar + _defaultFileName;
        private static readonly string _defaultFileName = "MainStorage.dat";

        public static StorageManager Main => _main;

        public event Action OnStorageLoaded = () => { };
        public event Action OnStorageChanged = () => { };
        public event Action OnStorageSaved = () => { };

        private Dictionary<string, string> _storage = new Dictionary<string, string>();

        private readonly string _dataPath;

        static StorageManager()
        {
            _main = new StorageManager(_defaultDataPath);
        }

        public StorageManager(string dataPath)
        {
            _dataPath = dataPath;
            Load();
        }

        public void Set(string key, object value)
        {
            _storage[key] = JsonUtility.ToJson(value);
            Save();

            OnStorageChanged.Invoke();
        }

        public T Get<T>(string key, T defaultValue = default)
        {
            if (!HasKey(key))
            {
                return defaultValue;
            }

            return JsonUtility.FromJson<T>(_storage[key]);
        }

        public bool HasKey(string key)
        {
            return _storage.ContainsKey(key);
        }

        private void Save()
        {
            SerializationManager.Serialize(_storage, _dataPath, ESerializationMethod.Binary);

            OnStorageSaved.Invoke();
        }

        private void Load()
        {
            _storage = SerializationManager.Deserialize<Dictionary<string, string>>(_dataPath, ESerializationMethod.Binary);

            OnStorageLoaded.Invoke();
        }
    }
}
