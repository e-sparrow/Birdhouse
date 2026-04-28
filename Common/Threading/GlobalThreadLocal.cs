using System.Threading;

namespace Birdhouse.Common.Threading
{
    public static class GlobalThreadLocal<T>
        where T : new()
    {
        private static readonly ThreadLocal<T> ThreadLocal = new ThreadLocal<T>(() => new T());

        public static bool IsValueCreated => ThreadLocal.IsValueCreated;
        public static T Value => ThreadLocal.Value;
    }
}