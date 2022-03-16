using ESparrow.Utils.Helpers;
using ESparrow.Utils.Serialization.Enums;
using ESparrow.Utils.Serialization.Interfaces;
using UnityEngine;

namespace ESparrow.Utils.Serialization.Examples.Mono
{
    public class MonoSerializationStorageExample : MonoBehaviour
    {
        [SerializeField] private string key;
        [SerializeField] private string information;
        
        private ISerializationStorage<string> _storage;

        private void Start()
        {
            _storage = SerializationHelper.GetDefaultSerializationStorage<string>(ESerializationMethod.Binary,
                Application.persistentDataPath + "information");
        }
    
        [ContextMenu("Save")]
        private void Save()
        {
            _storage.Set(key, information);
            _storage.Save();
        }

        [ContextMenu("Load")]
        private void Load()
        {
            _storage.Load();
            Debug.Log(_storage.Get<string>(key));
        }
    }
}