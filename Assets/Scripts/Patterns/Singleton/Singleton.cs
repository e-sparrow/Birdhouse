using System;

namespace ESparrow.Utils.Patterns.Singleton
{
    public abstract class Singleton<T> where T : Singleton<T>, new()
    {
        public static T Instance => LazyInstance.Value;
        public static bool HasInstance => Instance != null;
        
        private static readonly Lazy<T> LazyInstance = new Lazy<T>(() => new T());
    }
}