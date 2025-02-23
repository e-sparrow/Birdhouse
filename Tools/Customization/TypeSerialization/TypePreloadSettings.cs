using System;
using System.Collections.Generic;
using System.Reflection;

namespace Birdhouse.Tools.Customization.TypeSerialization
{
    public readonly struct TypePreloadSettings
    {
        public TypePreloadSettings(Predicate<Type> predicate, IEnumerable<Assembly> assemblies)
        {
            Predicate = predicate;
            Assemblies = assemblies;
        }

        public Predicate<Type> Predicate
        {
            get;
        }

        public IEnumerable<Assembly> Assemblies
        {
            get;
        }
    }
}