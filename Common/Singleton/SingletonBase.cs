using System;

namespace Birdhouse.Common.Singleton
{
    public abstract class SingletonBase<T> where T : SingletonBase<T>, new()
    {
        private static readonly Lazy<T> LazyInstance = new Lazy<T>(() => new T());
        
        public static T Instance => LazyInstance.Value;
        public static bool HasInstance => LazyInstance.IsValueCreated;
    }
}