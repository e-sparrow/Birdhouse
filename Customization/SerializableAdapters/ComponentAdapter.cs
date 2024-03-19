using System;
using Birdhouse.Abstractions.Adapters.Interfaces;
using UnityEngine;

namespace Birdhouse.Customization.SerializableAdapters
{
    [Serializable]
    public class ComponentAdapter<TTo>
        : ComponentAdapterBase<TTo>
    {
        [SerializeField] private Component target;
        
        protected override bool TryGetAdapter(Type type, out IAdapter<TTo> adapter)
        {
            throw new NotImplementedException();
        }
    }
}