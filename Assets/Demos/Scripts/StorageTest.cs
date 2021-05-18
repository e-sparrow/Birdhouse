using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ESparrow.Utils.Managers;

namespace Demos
{
    public class StorageTest : MonoBehaviour
    {
        [SerializeField] private string testValue;

        private const string testKey = "TEST_KEY";

        private void Start()
        {
            bool hasKey = StorageManager.HasKey(testKey);
            Debug.Log($"StorageManager.HasKey(\"{testKey}\"): {hasKey}");
            
            if (hasKey)
            {
                Debug.Log($"StorageManager.Get<string>({testKey}) = {StorageManager.Get<string>(testKey)}");
            }

            Debug.Log($"StorageManager.Set({testKey}, {testValue})");
            StorageManager.Set(testKey, testValue);
        }
    }
}
