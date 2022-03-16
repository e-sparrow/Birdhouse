using System;

namespace ESparrow.Utils.Patterns.Singleton
{
    public abstract class SingletonBase<T> where T : SingletonBase<T>, new()
    {
        protected SingletonBase()
        {
            
        }

        private static readonly Lazy<T> _lazyInstance = new Lazy<T>(() => new T());
        
        public static T Instance => _lazyInstance.Value;
        public static bool HasInstance => _lazyInstance.IsValueCreated;
    }
}