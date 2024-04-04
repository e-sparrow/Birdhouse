using System;
using System.Collections.Generic;
using Birdhouse.Abstractions.Interfaces;
using Birdhouse.Common.Extensions;
using Birdhouse.Features.Registries;
using Birdhouse.Features.Registries.Interfaces;

namespace Birdhouse.Tools.Features.Abstractions
{
    public abstract class FeatureFactoryBase
        : IFeatureFactory, IInitializable
    {
        private readonly IDictionary<Type, object> _featuresCache 
            = new Dictionary<Type, object>();

        private readonly IRegistryEnumerable<object> _parameters
            = new RegistryEnumerable<object>();

        private readonly IRegistryDictionary<Type, Func<object[], object>> _creators
            = new RegistryDictionary<Type, Func<object[], object>>();

        public IDisposable RegisterParameter(object parameter)
        {
            var result = _parameters.Register(parameter);
            return result;
        }

        public IDisposable RegisterFeature(Type type, Func<object[], object> creator)
        {
            var result = _creators.Register(type, creator);
            return result;
        }
        
        public bool TryGetOrCreateFeature(Type featureType, out object result)
        {
            result = default;
            
            var hasCached = _featuresCache.TryGetValue(featureType, out var cachedValue);
            if (hasCached)
            {
                result = cachedValue;
                return true;
            }

            var hasTargetType = _creators.ContainsKey(featureType);
            if (hasTargetType)
            {
                var canCreate = TryCreateFeature(featureType, out result);
                if (canCreate)
                {
                    return true;   
                }
            }

            return false;
        }

        private bool TryCreateFeature(Type featureType, out object result)
        {
            result = default;
            
            var hasCreator = _creators.TryGetValue(featureType, out var creator);
            if (hasCreator)
            {
                var hasParameters = true;
            
                var parameters = creator.Method.GetParameters();
                foreach (var parameter in parameters)
                {
            
                }
            
                var hasAssignable = _creators.TryGetFirst(pair => featureType.IsAssignableFrom(pair.Key), out var assignable);
                if (hasAssignable)
                {
                    var assignableCreator = _creators[assignable.Key];
                    result = assignableCreator.Invoke(input);
            
                    _featuresCache.Add(featureType, result);
                    return true;
                }
                
                result = creator.Invoke(input);
                _featuresCache.Add(featureType, result);
                return true;
            }
            
            return false;
        }

        public void Dispose()
        {
            _featuresCache.Clear();
            _creators.Dispose();
        }
    }
}