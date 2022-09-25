using Birdhouse.Common.Helpers;
using Birdhouse.Tools.Serialization.Enums;
using Birdhouse.Tools.Serialization.Interfaces;
using UnityEngine;

namespace Birdhouse.Tools.Serialization.Examples.Mono
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