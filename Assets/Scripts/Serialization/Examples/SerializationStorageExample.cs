using ESparrow.Utils.Enums;
using ESparrow.Utils.Helpers;
using ESparrow.Utils.Serialization.Interfaces;
using UnityEngine;

namespace ESparrow.Utils.Serialization.Examples
{
    public class SerializationStorageExample : MonoBehaviour
    {
        [SerializeField] private string information;
        
        private ISerializationStorage _storage;

        private void Start()
        {
            _storage = SerializationHelper.GetDefaultSerializationStorage(ESerializationMethod.Binary,
                Application.persistentDataPath + "information");
        }

        [ContextMenu("Save")]
        private void Save()
        {
            _storage.Set("information", information);
            _storage.Save();
        }

        [ContextMenu("Load")]
        private void Load()
        {
            _storage.Load();
            Debug.Log(_storage.Get<string>("information"));
        }
    }
}