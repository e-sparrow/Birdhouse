using UnityEngine;
using ESparrow.Utils.Extensions;

namespace ESparrow.Utils.Patterns.Singleton
{
    public abstract class UnitySingleton<T> : MonoBehaviour where T : UnitySingleton<T>
    {
        private static UnitySingleton<T> _instance;

        public static UnitySingleton<T> Instance
        {
            get
            {
                if (_instance == null)
                {
                    CreateNew();
                }

                return _instance;
            }
        }

        private static void CreateNew()
        {
            var gameObject = new GameObject(typeof(T).Name);
            _instance = gameObject.AddComponent<UnitySingleton<T>>();
        }

        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(this);
                Debug.LogWarning($"Second <color={Color.cyan.ToHexadecimal()}>{typeof(T).Name}</color> sigleton component detected and removed!");
            }
            else
            {
                _instance = this; 
                DontDestroyOnLoad(this);
            }
        }

        private void OnDestroy()
        {
            if (_instance == this)
            {
                CreateNew();
            }
        }

        protected UnitySingleton()
        {

        }
    }
}
