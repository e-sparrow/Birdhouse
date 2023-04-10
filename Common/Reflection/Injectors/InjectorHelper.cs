using Birdhouse.Tools.Identification.Interfaces;

namespace Birdhouse.Common.Reflection.Injectors
{
    public static class InjectorHelper
    {
        public static bool TryInjectFromPlayerPrefs<T>(out T result, IUnifier<string> unifier = null)
        {
            result = default;

            var injector = new PlayerPrefsInjector(unifier);

            var canInject = injector.TryInject(out result);
            return canInject;
        }
    }
}