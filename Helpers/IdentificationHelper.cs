using ESparrow.Utils.Identification;
using ESparrow.Utils.Identification.Interfaces;

namespace ESparrow.Utils.Helpers
{
    public static class IdentificationHelper
    {
        public static IUnifier<T> GetBlankUnifier<T>()
        {
            return new Unifier<T>(value => value);
        }
    }
}