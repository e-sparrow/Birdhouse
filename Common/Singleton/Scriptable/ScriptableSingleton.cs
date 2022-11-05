using UnityEngine;

namespace Birdhouse.Common.Singleton.Scriptable
{
    public class ScriptableSingleton<T> : ScriptableObject where T : ScriptableSingleton<T>
    {
        public static T Instance => GetInstance();

        private static T GetInstance()
        {
            
        }

        private static bool TryFindInstance(out T instance)
        {
            
        }

        private static T CreateInstance()
        {
            
        }
        
        [CreateAssetMenu(menuName = "Create ScriptableSingletonExample", fileName = "ScriptableSingletonExample", order = 0)]
        private class ScriptableSingletonExample : ScriptableSingleton<ScriptableSingletonExample>
        {
            
        }
    }
}