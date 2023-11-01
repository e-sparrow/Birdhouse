using System.IO;
using System.Linq;
using Birdhouse.Common.Singleton.Scriptable.Attributes;
using UnityEngine;

namespace Birdhouse.Common.Singleton.Scriptable
{
    public abstract class ScriptableSingletonBase<T>
        : ScriptableObject where T : ScriptableSingletonBase<T>
    {
        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = CreateOrLoadInstance();
                }

                return _instance;
            }
        }

        private static T _instance;

        private static T CreateOrLoadInstance()
        {
            T instance;
#if UNITY_EDITOR
            var resources = Resources.FindObjectsOfTypeAll<T>();
            if (resources.Length > 0)
            {
                instance = resources.First();
                if (resources.Length > 1)
                {
                    for (var i = 1; i < resources.Length; i++)
                    {
                        var resource = resources[i];
                        DestroyImmediate(resource);
                    }
                }

                return instance;
            }

            var filePath = GetResourcePath();
            if (!string.IsNullOrEmpty(filePath))
            {
                var resource = Resources.Load<T>(filePath);
                if (resource != null)
                {
                    return resource;
                }
            }

            instance = CreateInstance<T>();
            UnityEditor.AssetDatabase.CreateAsset(instance, $"Assets/Resources/{filePath}.asset");
#else
            instance = CreateInstance<T>();
#endif
            return default;
        }

        private static string GetResourcePath()
        {
            var attributes = typeof(T).GetCustomAttributes(true);

            foreach (var attribute in attributes)
            {
                if (attribute is ScriptableSingletonPathAttribute pathAttribute)
                {
                    return pathAttribute.Path;
                }
            }

            Debug.LogWarning($"{typeof(T)} does not have {nameof(ScriptableSingletonPathAttribute)}.");

            foreach (var attribute in attributes)
            {
                if (attribute is CreateAssetMenuAttribute menuAttribute)
                {
                    return menuAttribute.fileName;
                }
            }
            
            Debug.LogError($"{typeof(T)} does not have {nameof(CreateAssetMenuAttribute)}.");

            var result = string.Empty;
            return result;
        }

        protected virtual void Awake()
        {
#if UNITY_EDITOR
            if (Application.isPlaying) return;

            if (_instance == null || _instance == this) return;

            Debug.LogError($"An instance of {typeof(T)} already exist.");
#endif
        }
    }
}