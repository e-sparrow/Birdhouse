using Birdhouse.Tools.Identification;
using Birdhouse.Tools.Identification.Interfaces;

namespace Birdhouse.Common.Helpers
{
    public static class IdentificationHelper
    {
        public static IUnifier<T> GetBlankUnifier<T>()
        {
            return new Unifier<T>(value => value);
        }
    }
}