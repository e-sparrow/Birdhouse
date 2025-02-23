using System;
using System.Collections.Generic;
using System.Reflection;
using Birdhouse.Tools.Customization.TypeSerialization.Abstractions;

namespace Birdhouse.Tools.Customization.TypeSerialization
{
    public static class PreloadedTypesHelper
    {
        public static IReadOnlyTypePreloader GetAssignablesPreloader(Type type, IEnumerable<Assembly> assemblies = null, bool nonAbstract = true, bool noInterfaces = true)
        {
            assemblies ??= AppDomain.CurrentDomain.GetAssemblies();
            
            var settings = new TypePreloadSettings(IsAssignable, assemblies);
            var result = PreloadedTypesProvider.GetPreloader(settings);
            return result;

            bool IsAssignable(Type other)
            {
                var isValid = type.IsAssignableFrom(other);
                
                if (nonAbstract)
                {
                    isValid = isValid && !other.IsAbstract;
                }

                if (noInterfaces)
                {
                    isValid = isValid && !other.IsInterface;
                }
                
                return isValid;
            }
        }
    }
}