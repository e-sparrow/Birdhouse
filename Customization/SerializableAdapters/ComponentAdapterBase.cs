using System;
using Birdhouse.Abstractions.Adapters.Interfaces;
using UnityEngine;

namespace Birdhouse.Customization.SerializableAdapters
{
    public abstract class ComponentAdapterBase<TTo>
        : IAdapter<Component, TTo>
    {
        protected abstract bool TryGetAdapter(Type type, out IAdapter<TTo> adapter);
        
        public bool TryAdapt(Component from, out TTo result)
        {
            result = default;
            
            var hasAdapter = TryGetAdapter(from.GetType(), out var adapter);
            if (hasAdapter) 
            {
                var canAdapt = adapter.TryAdapt(from, out result);
                return canAdapt;
            }

            return false;
        }
    }
}