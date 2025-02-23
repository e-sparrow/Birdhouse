using System;
using System.Collections.Generic;
using System.Linq;
using Birdhouse.Common.Extensions;
using Birdhouse.Tools.Customization.TypeSerialization.Abstractions;
using UnityEditor;

namespace Birdhouse.Tools.Customization.TypeSerialization
{
    public static class PreloadedTypesProvider
    {
        private static readonly IDictionary<TypePreloadSettings, ITypePreloader> Preloaders 
            = new Dictionary<TypePreloadSettings, ITypePreloader>();

        public static IReadOnlyTypePreloader GetPreloader(TypePreloadSettings settings)
        {
            var hasPreloader = Preloaders.TryGetValue(settings, out var result);
            if (!hasPreloader)
            {
                result = new TypePreloader(settings);
                result.Update();
                
                Preloaders[settings] = result;
            }

            return result;
        }

        [InitializeOnLoadMethod]
        private static void UpdatePreloaders()
        {
            foreach (var preloader in Preloaders.Values)
            {
                preloader.Update();
            }
        }

        private sealed class TypePreloader
            : ITypePreloader
        {
            public TypePreloader(TypePreloadSettings settings)
            {
                _settings = settings;
            }

            private readonly TypePreloadSettings _settings;
            private readonly ICollection<Type> _cached = new List<Type>();

            public void Update()
            {
                _cached.Clear();
                _cached.AddRange(_settings
                    .Assemblies
                    .SelectMany(value => value.GetTypes())
                    .Where(value => _settings.Predicate.Invoke(value)));
            }
            
            public IEnumerable<Type> GetTypes()
            {
                return _cached;
            }
        }
    }
}