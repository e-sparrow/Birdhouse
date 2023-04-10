using Birdhouse.Common.Reflection.Injectors.Interfaces;

namespace Birdhouse.Common.Reflection.Injectors
{
    public static class InjectorExtensions
    {
        public static bool TryInject<T>(this IInjector injector, out T result)
        {
            result = default;
            if (injector.TryInject(typeof(T), out var boxedResult))
            {
                result = (T) boxedResult;
                return true;
            }

            return default;
        }
    }
}