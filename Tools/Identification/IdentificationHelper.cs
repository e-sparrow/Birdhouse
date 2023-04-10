using Birdhouse.Tools.Identification.Interfaces;

namespace Birdhouse.Tools.Identification
{
    public static class IdentificationHelper
    {
        public static IUnifier<T> GetBlankUnifier<T>()
        {
            var result = new Unifier<T>(value => value);
            return result;
        }
        
        public static IUnifier<string> GetUpperCaseUnifier()
        {
            var result = new Unifier<string>(value => value.ToUpper());
            return result;
        }
        
        public static IUnifier<string> GetUpperInvariantCaseUnifier()
        {
            var result = new Unifier<string>(value => value.ToUpperInvariant());
            return result;
        }
        
        public static IUnifier<string> GetLowerCaseUnifier()
        {
            var result = new Unifier<string>(value => value.ToLower());
            return result;
        }
        
        public static IUnifier<string> GetLowerInvariantCaseUnifier()
        {
            var result = new Unifier<string>(value => value.ToLowerInvariant());
            return result;
        }
    }
}