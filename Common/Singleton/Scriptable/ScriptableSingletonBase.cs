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
            var instance = default(T);

            var filePath = GetResourcePath();
            if (!string.IsNullOrEmpty(filePath))
            {
                instance = Resources.Load<T>(filePath);
            }

#if UNITY_EDITOR
            if (instance != null)
            {
                return instance;
            }

            instance = CreateInstance<T>();
            UnityEditor.AssetDatabase.CreateAsset(instance, $"Assets/Resources/{filePath}.asset");

            return instance;
#endif
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
            DestroyImmediate(this, true);
#endif
        }
    }
}