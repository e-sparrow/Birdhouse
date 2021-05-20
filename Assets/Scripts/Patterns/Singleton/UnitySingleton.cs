using UnityEngine;
using ESparrow.Utils.Extensions;

namespace ESparrow.Utils.Patterns.Singleton
{
    public abstract class UnitySingleton<T> : MonoBehaviour where T : UnitySingleton<T>
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
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
                }

                return _instance;
            }
        }

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
                Debug.LogWarning($"Second <color={Color.cyan.ToHexadecimal()}>{typeof(T).Name}</color> sigleton component detected and removed!");
            }
            else
            {
                _instance = (T) this;

                if (Application.isPlaying)
                {
                    gameObject.transform.SetParent(null);
                    DontDestroyOnLoad(gameObject);
                }
            }
        }

        protected UnitySingleton()
        {

        }
    }
}
