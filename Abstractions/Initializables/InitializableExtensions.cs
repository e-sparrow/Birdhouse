using Birdhouse.Abstractions.Initializables.Interfaces;

namespace Birdhouse.Abstractions.Initializables
{
    public static class InitializableExtensions
    {
        public static T InitializeSelf<T>(this T self)
            where T : IInitializable
        {
            self.Initialize();
            return self;
        }
    }
}