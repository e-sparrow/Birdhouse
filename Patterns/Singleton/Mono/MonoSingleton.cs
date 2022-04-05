using UnityEngine;
using ESparrow.Utils.Extensions;

namespace ESparrow.Utils.Patterns.Singleton.Mono
{
    public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
    {
        private static T _instance;

        private static void CreateNew()
        {
            var gameObject = new GameObject(typeof(T).Name);
            _instance = gameObject.AddComponent<T>();
        }

        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                DestroyImmediate(gameObject);
                Debug.LogWarning($"Second Unity singleton component of type {typeof(T).Name.WithColor(Color.cyan).Bold()} detected and removed!");
            }
            else
            {
                _instance = (T) this;

                if (!Application.isPlaying) return;
                
                gameObject.transform.SetParent(null);
                DontDestroyOnLoad(gameObject);
            }
        }

        public static T Instance
        {
            get
            {
                if (_instance != null) return _instance;
                
                var array = FindObjectsOfType<T>();
                if (array.Length == 0)
                {
                    CreateNew();
                }
                else
                {
                    if (array.Length > 1)
                    {
                        for (int i = 1; i < array.Length; i++)
                        {
                            DestroyImmediate(array[i]);
                        }
                    }

                    _instance = array[0];
                }

                return _instance;
            }
        }
    }
}
